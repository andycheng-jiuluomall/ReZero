﻿using ReZero.SuperAPI;
using System.Diagnostics;

namespace SuperAPITest
{
    public class JwtAop : DefaultSuperApiAop
    {
        public async override Task OnExecutingAsync(InterfaceContext aopContext)
        {
            //// 尝试验证JWT  
            //var authenticateResult = await aopContext.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
            //if (!authenticateResult.Succeeded)
            //{ 
            //    throw new Expception("Unauthorized"); 
            //}
            await base.OnExecutingAsync(aopContext);
        } 
    }
}
