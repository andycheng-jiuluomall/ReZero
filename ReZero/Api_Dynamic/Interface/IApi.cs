﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ReZero 
{
    public interface IDynamicApi
    {
        bool IsApi(string url);
        Task WriteAsync(HttpContext context);
    }
}