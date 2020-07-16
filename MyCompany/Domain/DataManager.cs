﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public IServiceItemsRepository ServiceItems { get; set; }
        public ITextFieldsRepository TextFields { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository,IServiceItemsRepository serviceItemsRepository )
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
        }
    }
}
