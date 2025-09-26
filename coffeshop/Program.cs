
using Coffeshop.Mapping;
using Coffeshop.Repositories;
using Coffeshop.Service;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container
builder.Services.AddControllers();

// 2. Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();   


// 3. Add DbContext (ví dụ dùng SQLite)
/*
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

*/
// 4. Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 5. Add Dependency Injection cho Service và Repository
//builder.Services.AddScoped<IProductService, ProductService>();
//uilder.Services.AddScoped<IProductRepository, ProductRepository>();

//builder.Services.AddDbContext<AppDbContext>(options => (builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// 6. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // for swagger
    app.UseSwagger();
    app.UseSwaggerUI();
    // end for swagger
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

