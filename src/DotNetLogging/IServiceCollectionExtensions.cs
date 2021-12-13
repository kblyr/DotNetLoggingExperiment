namespace DotNetLogging;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDotNetLogger(this IServiceCollection services) => services.AddSingleton<IDotNetLogger>(serviceProvider => new DotNetLogger(serviceProvider.GetRequiredService<ILogger<DotNetLoggingInternalSourceContext>>()));
}