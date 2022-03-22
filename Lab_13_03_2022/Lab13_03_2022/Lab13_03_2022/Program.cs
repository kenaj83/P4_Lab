using System.Data;
using System.Data.SqlClient;


var connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
using var connection = new SqlConnection(connectionString);


string zapytanieString = "SELECT * FROM Region";
connection.Open();
using var cmd = new SqlCommand(zapytanieString, connection);
using var reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine("ID:{0}, Value:{1}",reader[0],reader[1]);

}
reader.Close();



var command = new SqlCommand();
command.CommandType = CommandType.Text;
command.Connection = connection;
command.CommandText = " INSERT INTO Region Values(@RegionID,@RegionDescription)";
command.Parameters.AddWithValue("@RegionID", 6);
command.Parameters.AddWithValue("@RegionDescription", "Slask");
var sqlexit = command.ExecuteNonQuery();


connection.Close();