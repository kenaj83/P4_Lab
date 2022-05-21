using Lab5;

var context = new MyDBContext();
context.Database.EnsureCreated();

//context.Clients.Add(
//    new Client()
//    {
//        Name = "Jan Kowalski"
//    }
//    );


var client = new Client()

{ Name = "Jan Nowak" };

client.Orders.Add(new Orders()
    {
    Price = 10m
    });

context.Clients.Add(client);
context.SaveChanges();


//foreach (var item in context.Clients
//    .Include(x => x.Orders)
//    .ToList())
//{
//    Console.WriteLine(item);
//}