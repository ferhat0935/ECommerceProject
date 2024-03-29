﻿using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<bool> CanDeleteCategory(int categoryId);
        int TGetCategoryCount();
    }
}
