using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Fiters
{
    using Repository;
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly IGenericRepository<Key> keyRepository;

        public AuthorizationFilter(IGenericRepository<Key> keyRepository)
        {
            this.keyRepository = keyRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            StringValues key;
            if(context.HttpContext.Request.Headers.TryGetValue("key", out key))
            {
                Guid keyGuid;
                if(!Guid.TryParse(key.FirstOrDefault(), out keyGuid))
                {
                    HasNotAccess(context);
                    return;
                }
                if(this.keyRepository.GetQuery().FirstOrDefault(k => k.KeyGUID.Equals(keyGuid)) == null)
                {
                    HasNotAccess(context);
                    return;
                }
            }
            else
            {
                HasNotAccess(context);
            }
        }
        private void HasNotAccess(AuthorizationFilterContext context)
        {
            context.Result = new ContentResult { StatusCode = (int)HttpStatusCode.Forbidden };
        }
    }
}
