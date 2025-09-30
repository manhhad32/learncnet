
using co_lib;
using Coffeshop.Data;
using Coffeshop.Mapping;
using Coffeshop.Repositories;
using Coffeshop.Service;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore; // Thêm using này
using Npgsql.EntityFrameworkCore.PostgreSQL; // Thêm using này


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddedServices(builder.Configuration);


// 3. Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 5. Add Dependency Injection cho Service và Repository
//builder.Services.AddScoped<IProductService, ProductService>();
//uilder.Services.AddScoped<IProductRepository, ProductRepository>();

//builder.Services.AddDbContext<AppDbContext>(options => (builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ILoginService, LoginService>();

var app = builder.Build();

// 6. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

