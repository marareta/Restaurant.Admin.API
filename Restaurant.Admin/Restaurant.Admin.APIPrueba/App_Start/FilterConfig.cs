﻿using System.Web;
using System.Web.Mvc;

namespace Restaurant.Admin.APIPrueba
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
