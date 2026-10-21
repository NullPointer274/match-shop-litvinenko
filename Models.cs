// Классы таблиц: Customer, Product, Order (шаги 1–2).
public class Customer
{
    public int Id { get; set; }              // первичный ключ: EF узнаёт его по имени Id
    public string Name { get; set; } = "";   // имя
    public string Phone { get; set; } = "";  // телефон
    public string City { get; set; } = "";   // город
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";          // название
    public decimal Price { get; set; }               // цена коробка
    public int MatchCount { get; set; }              // сколько спичек в коробке
    public int Stock { get; set; }                   // сколько коробок на складе

    public string? Description { get; set; }
    // "Name" - NOT NULL, "Description" - NULL разрешён.
    // Почему: string - EF ставит NOT NULL, string? - не ставит.
    // = "" не важно, EF смотрит только на ?
}