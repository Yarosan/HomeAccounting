﻿using System;
using HomeAccountingSystem_WebUI.Models;
using DomainModels.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HomeAccountingSystem_WebUI.Abstract
{
    public interface ICategoryHelper
    {
        Task<CategoriesViewModel> CreateCategoriesViewModel(int page, int itemsPerPage, Func<Category, bool> predicate);
        Task<IEnumerable<Category>> GetCategoriesToShowOnPage(int page, int itemsPerPage, Func<Category, bool> predicate);
    }
}
