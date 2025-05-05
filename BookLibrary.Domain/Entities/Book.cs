namespace BookLibrary.Domain.Entities;

public class Book
{
    public int Id { get; set; }                     // Первичный ключ
    public string Title { get; set; } = string.Empty;   // Название книги
    public string Author { get; set; } = string.Empty;  // Автор
    public int Year { get; set; }                   // Год выпуска
}