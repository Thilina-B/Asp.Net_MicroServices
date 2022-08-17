using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

//IConfiguration configuration = new ConfigurationBuilder()
//                            .AddJsonFile("ocelot.Local.json")
//                            .Build();

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
//builder.Services.AddOcelot();
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);
//builder.Services.AddOcelot(configuration);

//builder.Configuration.AddJsonFile("ocelot.Local.json");
builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.UseOcelot().Wait();
app.Run();
