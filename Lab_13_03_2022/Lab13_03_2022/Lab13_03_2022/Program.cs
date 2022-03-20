// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;


var cstring =
    @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
using var connectionString = new SqlConnection(cstring);


    connectionString.Open();

using var Regiony = new SqlCommand("SELECT * FROM Region",connectionString);

var reader = Regiony.ExecuteReader();

    while(reader.Read())

