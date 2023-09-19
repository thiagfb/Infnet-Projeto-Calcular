using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Calcular.HealthCheck;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddHealthChecks()
//                .AddUrlGroup(new Uri("http://httpbin.org/status/200"), "Api Terceiro não autenticada")
//                .AddUrlGroup(uri: new Uri("https://economia.awesomeapi.com.br/json/last/USD-BRL"), "Api Publica de cotação não autenticada")
//                .AddCheck<HealthCheckRandom>(name: "Api Terceiro Autenticada");

builder.Services.AddHealthChecks()
                .AddCheck<HealthCheckRandom>(name: "Validando APIs");


builder.Services.AddHealthChecksUI(s =>
{
    s.AddHealthCheckEndpoint("API-healthz", "https://localhost:7247/healthz");

})
.AddInMemoryStorage();

builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPINSIGHTS_CONNECTIONSTRING"]);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting()
   .UseEndpoints(config =>
   {
       config.MapHealthChecks("/healthz", new HealthCheckOptions
       {
           Predicate = _ => true,
           ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
       });

       config.MapHealthChecksUI();
   });

app.Run();