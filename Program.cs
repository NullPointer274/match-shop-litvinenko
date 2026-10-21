using Microsoft.EntityFrameworkCore;

Console.WriteLine("Магазин спичек «Чирк»: проект запущен!");

// Дальше — код по шагам задания.
using var db = new ShopContext();
db.Database.EnsureDeleted();   // удалить базу, если она осталась с прошлого запуска
db.Database.EnsureCreated();   // создать базу и таблицы по классам

Console.WriteLine("=== Шаг 3 ===");

var ivan = new Customer { Name = "Иван Петров", Phone = "+7 900 111-22-33", City = "Омск" };
var olga = new Customer { Name = "Ольга Смирнова", Phone = "+7 900 444-55-66", City = "Томск" };
var dmitry = new Customer { Name = "Дмитрий Соколов", Phone = "+7 913 123-45-67", City = "Новосибирск" };
var elena = new Customer { Name = "Елена Попова", Phone = "+7 921 987-65-43", City = "Санкт-Петербург" };
var alexey = new Customer { Name = "Алексей Спичкин", Phone = "+7 903 555-11-22", City = "Омск" };

db.Customers.Add(ivan);
db.Customers.Add(olga);
db.Customers.Add(dmitry);
db.Customers.Add(elena);
db.Customers.Add(alexey);

var kam = new Product { Name = "Каминные", Price = 150m, MatchCount = 50, Stock = 20, Description = "Горят даже под дождём" };
var hos = new Product { Name = "Хозяйственные", Price = 45m, MatchCount = 100, Stock = 50 };
var tur = new Product { Name = "Туристические", Price = 80m, MatchCount = 40, Stock = 15, Description = "Ветроустойчивые" };
var pod = new Product { Name = "Подарочные", Price = 350m, MatchCount = 30, Stock = 5, Description = "В подарочной коробке" };
var ban = new Product { Name = "Банные", Price = 60m, MatchCount = 60, Stock = 0 };

db.Products.Add(kam);
db.Products.Add(hos);
db.Products.Add(tur);
db.Products.Add(pod);
db.Products.Add(ban);

db.SaveChanges();   // только здесь данные уходят в базу

Console.WriteLine("=== Шаг 3. Усложнение ===");

var order1 = new Order { Customer = dmitry, Product = kam, Quantity = 3, OrderDate = DateTime.UtcNow.AddDays(-6) };
var order2 = new Order { Customer = dmitry, Product = hos, Quantity = 2, OrderDate = DateTime.UtcNow.AddDays(-5) };
var order3 = new Order { Customer = elena, Product = tur, Quantity = 1, OrderDate = DateTime.UtcNow.AddDays(-4) };
var order4 = new Order { Customer = ivan, Product = pod, Quantity = 1, OrderDate = DateTime.UtcNow.AddDays(-3) };

db.Orders.Add(order1);
db.Orders.Add(order2);
db.Orders.Add(order3);
db.Orders.Add(order4);

db.SaveChanges();

// DateTime.Now берет время с компьютера (местное время),
// а DateTime.UtcNow - это всемирное координированное время (UTC).
// База данных PostgreSQL требует время именно в UTC, поэтому мы используем UtcNow