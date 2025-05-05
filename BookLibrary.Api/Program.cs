using BookLibrary.Application.Services;
using BookLibrary.Domain.Interfaces;
using BookLibrary.Infrastructure.Data;
using BookLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Добавляем контроллеры и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Подключаем базу данных InMemory
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseInMemoryDatabase("BooksDb"));

// ✅ Регистрируем зависимости
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();

var app = builder.Build();

// ✅ Включаем Swagger в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Подключаем маршрутизацию и HTTPS
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();