﻿using eAppointment.Infrastructure.Context;
using eAppointment.Infrastructure.Repositories;
using eAppointment.Infrastructure.Services;
using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eAppointment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequiredLength = 1;
            action.Password.RequireUppercase = false;
            action.Password.RequireLowercase = false;
            action.Password.RequireNonAlphanumeric = false;
            action.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();


   

        services.AddScoped<IUnitOfWork>(srv=>srv.GetRequiredService<ApplicationDbContext>());

        services.Scan(action =>
        {
            action
            .FromAssemblies(typeof(DependencyInjection).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });

      


        return services;
    }
}