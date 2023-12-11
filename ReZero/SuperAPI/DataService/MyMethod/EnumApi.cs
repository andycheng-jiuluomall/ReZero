﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReZero.SuperAPI 
{
    public class EnumApi
    {
        public List<EnumItemInfo> GetDbTypeSelectDataSource()
        {
            List<EnumItemInfo> enumItemInfos= new List<EnumItemInfo>();
            var dts=UtilMethods.EnumToDictionary<DbType>();
            foreach (var item in dts)
            {
                enumItemInfos.Add(new EnumItemInfo() { Name = item.Key, Value = Convert.ToInt32(item.Value) + "" });
            }
            return enumItemInfos;
        }
    }
}