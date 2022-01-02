using BethanysPieShopHRM.ApiNet6.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddMvcOptions(o => 
    { 
        o.EnableEndpointRouting = false; 
        o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()); 
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration["connectionStrings:DefaultConnection"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICountryRepository, CountryRepository>();  
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();  
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();  

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
