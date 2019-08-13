using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Services
{
    using Services;

    public static class ServicesExtensions
    {
        /// <summary>
        /// Registrate all services. If you add create new service, add here too.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlogServices(this IServiceCollection services)
        {
            services.AddScoped<BlogService>();
            services.AddScoped<CommentService>();

            return services;
        }
    }
}
