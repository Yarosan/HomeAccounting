﻿using System;
using System.Collections.Generic;
using DomainModels.Model;

namespace WebUI.Models
{
    public class PayItemForView
    {
        public string CategoryName { get; set; }
        public  List<Category> Items { get; set; }
        public DateTime DateFrom { get; set; } 
        public DateTime DateTo { get; set; }
    }
}