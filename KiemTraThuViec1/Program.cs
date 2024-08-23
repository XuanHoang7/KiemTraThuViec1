using KiemTraThuViec1.Data;
using KiemTraThuViec1.Data.Entities;
using KiemTraThuViec1.Repository;
using KiemTraThuViec1.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add scoped repository
builder.Services.AddScoped<ILoiVatTuRepository, LoiVatTuRepository>();
builder.Services.AddScoped<IVatTuRepository, VatTuRepository>();
builder.Services.AddScoped<IDonViTinhRepository, DonViTinhRepository>();
builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<ISanPhamVatTuRepository, SanPhamVatTuRepository>();
//// Add scoped services
builder.Services.AddScoped<ILoaiVatTuService, LoaiVatTuService>();
builder.Services.AddScoped<IVatTuService, VatTuService>();
builder.Services.AddScoped<IDonViTinhService, DonViTinhService>();
builder.Services.AddScoped<ISanPhamService, SanPhamService>();
///
//builder.Services.AddScoped<IEmpoyeeServices, EmployeeServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
