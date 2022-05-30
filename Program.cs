#region 1: Imports and variable declarations

using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;

var serviceName = "DappRadar.DotNetServices.OpenTelemetryDemo";
var serviceVersion = "1.0.0";

#endregion 1: Imports and variable declarations

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region 2: Builder configurations
builder.Services.AddOpenTelemetryTracing(b =>
{
    b
    .AddOtlpExporter(opt =>
    {
        opt.Endpoint = new Uri("http://localhost:4317");
        opt.Protocol = OtlpExportProtocol.Grpc;
    })
    .AddSource(serviceName)
    .SetResourceBuilder(
        ResourceBuilder.CreateDefault()
            .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
    .AddHttpClientInstrumentation()
    .AddAspNetCoreInstrumentation()
    .AddSqlClientInstrumentation();
});
#endregion 2: Builder configurations

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
