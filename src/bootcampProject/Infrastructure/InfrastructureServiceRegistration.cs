using Application.Common.Services;
using Application.Services.ImageService;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Servicess;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string wwwrootPath)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();

        services.AddSingleton<IEmailTemplateFillerService>(new EmailTemplateFillerManager(wwwrootPath));

        return services;
    }
}
