using Microsoft.Extensions.DependencyInjection;
using RepeatedWord.Backend.WebApi.Interfaces;
using RepeatedWord.Backend.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.WebApi
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCustomizedServices(this IServiceCollection services)
        {
            services.AddTransient<ISentenceService, SentenceService>();
            services.AddTransient<IWordService, WordService>();

            return services;
        }
    }
}
