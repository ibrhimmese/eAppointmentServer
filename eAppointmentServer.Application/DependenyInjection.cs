using Microsoft.Extensions.DependencyInjection;

namespace eAppointmentServer.Application;

public static class DependenyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependenyInjection).Assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependenyInjection).Assembly);
        });

        return services;
    }
}
