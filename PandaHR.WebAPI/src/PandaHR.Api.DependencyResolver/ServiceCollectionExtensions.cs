﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PandaHR.Api.DAL;
using PandaHR.Api.DAL.EF.Context;
using PandaHR.Api.DAL.Repositories.Contracts;
using PandaHR.Api.DAL.Repositories.Implementation;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.Services.Implementation;

namespace PandaHR.Api.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration["ConnectionString"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepositoryAsync<>));
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<ISkillService, SkillService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<PandaHR.Api.Common.Contracts.IMapper, PandaHR.Api.Common.PandaHRAutoMapper>();
        }
    }
}