using System.Data;
using System.Data.SqlClient;
using Dapper;

var connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
using var connection = new SqlConnection(connectionString);


//var insertResult = connection.Execute("INSERT INTO Region(RegionID, RegionDescription) VALUES (@Id,'@Description)",
//    new
//    {
//        id = 8,
//        Description = "Test 2"

//    });

//var nowyRegion = new Region()
//{
//    RegionId = 9,
//    RegionDescription = "TestRegion"
//};

//var insertResult = connection.Execute("INSERT INTO Region(RegionID, RegionDescription) VALUES (@RegionID,@RegionDescription)",nowyRegion);

var regions = connection.Query<Region>("Select * from Region");


foreach (var item in regions)
{
    Console.WriteLine($"{item.RegionId}: {item.RegionDescription}");
}

//var joinResult = connection.Query<Product, Category, Product>("SELECT * FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID",
//    (product, category) =>
//    {
//        product.Category = category;
//        return product;
//    },
//    splitOn: "CategoryID");


//foreach (var item in joinResult)
//{
//    Console.WriteLine($"{ item.ProductName}: {item.Category.CategoryName }");
//}


var joinResult = connection.Query<Territories, Region, Territories>(@"SELECT * FROM Territories t JOIN Region r  ON t.RegionID = r.RegionID
                                                                        WHERE t.TerritoryDescription LIKE @PierwszaLitera",
    (territories, region) =>
    {
        territories.Region = region;
        return territories;
    },
    new { PierwszaLitera = "T%" },
    splitOn: "RegionID") ;


foreach (var item in joinResult)
{
    Console.WriteLine($"{ item.territoryDescription }: {item.Region.RegionId}");
}






