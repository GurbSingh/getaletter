using System;
using System.Collections.Generic;
using System.Text;

using GetALetterForANumber;
using GetALetterForANumber.Interfaces;
using GetALetterForANumber.Concrete;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GetALetterForANumber.StartUp))]

namespace GetALetterForANumber
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services
                .AddTransient<IIntegerRequest, IntegerRequest>();


            _ = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }

    }
}

