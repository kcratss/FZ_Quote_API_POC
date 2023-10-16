using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Manager;
using FloorzapTestAPI.Model;
using FloorzapTestAPI.Quotes;
using FloorzapTestAPI.Repository;
using FloorzapTestAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICompanySettingManager, CompanySettingManager>();
builder.Services.AddScoped<IDiscountManager, DiscountManager>();
builder.Services.AddScoped<ICommissionManager, CommissionManager>();
builder.Services.AddScoped<ITaxManager, TaxManager>();
builder.Services.AddScoped<IProfitManager, ProfitManager>();
builder.Services.AddScoped<IQuoteManager, QuoteManager>();
builder.Services.AddScoped<ILineItemService, LineItemService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FZCors", policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("FZCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
