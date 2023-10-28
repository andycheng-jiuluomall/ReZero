﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReZero 
{
    public interface IReZeroApi 
    {
        bool IsApi(string url);
        Task WriteAsync(HttpContext context);
    }
}
