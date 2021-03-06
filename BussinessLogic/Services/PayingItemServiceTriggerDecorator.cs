﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Model;
using Services;
using Services.Exceptions;
using Services.Triggers;

namespace BussinessLogic.Services
{
    public class PayingItemServiceTriggerDecorator:IPayingItemService
    {
        private readonly IPayingItemService _payingItemService;
        private readonly IServiceTrigger<PayingItem> _serviceTrigger;
        private readonly ICategoryService _categoryService;
        private readonly ITypeOfFlowService _typeOfFlowService;

        public PayingItemServiceTriggerDecorator(IPayingItemService payingItemService, 
            IServiceTrigger<PayingItem> serviceTrigger, 
            ICategoryService categoryService,
            ITypeOfFlowService typeOfFlowService)
        {
            _payingItemService = payingItemService;
            _serviceTrigger = serviceTrigger;
            _categoryService = categoryService;
            _typeOfFlowService = typeOfFlowService;
        }

        public IEnumerable<PayingItem> GetList()
        {
            return _payingItemService.GetList();
        }

        public async Task<PayingItem> GetItemAsync(int id)
        {
            return await _payingItemService.GetItemAsync(id);
        }

        public async Task<IEnumerable<PayingItem>> GetListAsync()
        {
            return await _payingItemService.GetListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var deletedItem = await _payingItemService.GetItemAsync(id);
                await _payingItemService.DeleteAsync(id);
                await _serviceTrigger.Delete(deletedItem);
            }
            catch (ServiceException e)
            {
                throw new ServiceException($"Ошибка в декораторе сервиса {nameof(PayingItemServiceTriggerDecorator)} в методе {nameof(DeleteAsync)}", e);
            }
        }

        public async Task UpdateAsync(PayingItem item)
        {
            var typeOfFlowId = (await _categoryService.GetItemAsync(item.CategoryID)).TypeOfFlowID;
            var categories = (await _typeOfFlowService.GetCategoriesAsync(typeOfFlowId)).Where(x => x.UserId == item.UserId);
            var oldCategoryId = await GetCategoryIdAsync(categories, item.ItemID);
            var oldCategory = await _categoryService.GetItemAsync(oldCategoryId);
            var oldPayingItem = oldCategory.PayingItem.FirstOrDefault(x => x.ItemID == item.ItemID);
            var newItem = new PayingItem()
            {
                Category = oldCategory,
                AccountID = item.AccountID,
                Summ = item.Summ
            };
            await _payingItemService.UpdateAsync(item);
            await _serviceTrigger.Update(oldPayingItem, newItem);
        }

        public async Task<PayingItem> CreateAsync(PayingItem item)
        {
            var insertedItem = await _payingItemService.CreateAsync(item);
            await _serviceTrigger.Insert(insertedItem);
            return insertedItem;
        }

        public IEnumerable<PayingItem> GetListByTypeOfFlow(IWorkingUser user, int typeOfFlow)
        {
            return _payingItemService.GetListByTypeOfFlow(user, typeOfFlow);
        }

        private Task<int> GetCategoryIdAsync(IEnumerable<Category> categories, int itemId)
        {
            return Task.Run(() =>
            {
                var categoryId = 0;
                foreach (var category in categories)
                {
                    foreach (var payingItem in category.PayingItem)
                    {
                        if (payingItem.ItemID == itemId)
                        {
                            categoryId = payingItem.CategoryID;
                            break;
                        }
                        if (categoryId != 0)
                        {
                            break;
                        }
                    }
                }
                return categoryId;
            });
        }
    }
}