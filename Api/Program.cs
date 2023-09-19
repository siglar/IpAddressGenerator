using Api.Services.IpAddressService;
using Common.Services.IpapiClient;
using Common.Services.RestCountriesClient;
using Database;
using Database.Repositories.LangaugeRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILanguageSpeakerService, LanguageSpeakerService>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddHttpClient<IIpapiClient, IpapiClient>();
builder.Services.AddHttpClient<IRestCountriesClient, RestCountriesClient>();

builder.Services.AddDbContext<PopulationContext>((optionsBuilder) =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"), options => options.EnableRetryOnFailure());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();