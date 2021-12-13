Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Creating application builder");
    var builder = WebApplication.CreateBuilder(args);

    // builder.Host.ConfigureLogging((context, logging) => {
    //     logging.AddSerilog();
    // });

    Log.Information("Adding services to container");
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDotNetLogger();

    Log.Information("Building the application");
    var app = builder.Build();

    Log.Information("Configuring the application pipeline");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    Log.Information("Running the application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to start web api");
}
finally
{
    Log.Information("Exiting program");
    Log.CloseAndFlush();
}