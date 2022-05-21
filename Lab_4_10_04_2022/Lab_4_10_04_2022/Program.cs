using Microsoft.EntityFrameworkCore;
using Lab_4_10_04_2022;

var context = new MyDbContext();
context.Database.EnsureCreated();
context.Database.Migrate();

using var transaction = context.Database.BeginTransaction();

context.Clients.Add(new Client()
{
    Name = "Jan Głuch",
    Address = " Zielona 27 , Pszczyna",
    Balance = 0


});


context.SaveChanges();
transaction.Rollback();

var result = context.Clients
    .Where(Client => Client.Balance == 0)
    .ToArray();

//var result = context.Products
//    .Where(Client => Client.Price > 0)
//    .ToArray();



foreach (var item in result)
{
    Console.WriteLine(item.Name);
}