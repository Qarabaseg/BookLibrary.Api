using BookLibrary.Application.Services;
using BookLibrary.Domain.Interfaces;
using BookLibrary.Infrastructure.Data;
using BookLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Domain.Entities;


var builder = WebApplication.CreateBuilder(args);

// ✅ Добавляем контроллеры и Swagger
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Подключаем базу данных InMemory
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite("Data Source=library.db"));

// ✅ Регистрируем зависимости
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<IEditionRepository, EditionRepository>();

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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

    // Убедись, что база существует
    context.Database.EnsureCreated();

    // Если уже есть данные — не заполняем
    if (!context.Authors.Any())
    {
        var author = new Author { Name = "George Orwell" };
        var book = new Book { Title = "1984", Year = 1949, Author = author };
        var edition = new Edition { Name = "First Edition", Book = book };

        context.Authors.Add(author);
        context.Books.Add(book);
        context.Editions.Add(edition);

        await context.SaveChangesAsync();
    }
}
app.Run();