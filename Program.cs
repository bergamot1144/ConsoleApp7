using Microsoft.Data.SqlClient;

namespace ConsoleApp7
{
    class ProgramconnectionString
    {
        static async Task Main(string[] args)
        {


            string connectionString = @"Data Source=working; Initial Catalog=OnlineStore; Trusted_Connection=True; TrustServerCertificate=True";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    await connection.OpenAsync();
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = "CREATE DATABASE OnlineStore";
            //    command.Connection = connection;
            //    await command.ExecuteNonQueryAsync();
            //    Console.WriteLine("DB created");
            //}


            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    await connection.OpenAsync();
            //    Console.WriteLine("Connection open");
            //    Console.WriteLine(connection.Database);
            //    Console.WriteLine(connection.DataSource);
            //    Console.WriteLine(connection.State);
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = "CREATE TABLE Products (ProductId INT PRIMARY KEY IDENTITY, Name nvarchar(50) not null, Description nvarchar(50), Price decimal(18,2), Stock int )";
            //    command.Connection = connection;
            //    await command.ExecuteNonQueryAsync();
            //    Console.WriteLine("Table Products created");
            //}


            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    await connection.OpenAsync();
            //    Console.WriteLine("Connection open");
            //    Console.WriteLine(connection.Database);
            //    Console.WriteLine(connection.DataSource);
            //    Console.WriteLine(connection.State);
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = "CREATE TABLE Categories (CategoryId INT PRIMARY KEY IDENTITY, CategoryName nvarchar(50) not null)";
            //    command.Connection = connection;
            //    await command.ExecuteNonQueryAsync();
            //    Console.WriteLine("Table Categories created");
            //}
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    await connection.OpenAsync();
            //    Console.WriteLine("Connection open");
            //    Console.WriteLine(connection.Database);
            //    Console.WriteLine(connection.DataSource);
            //    Console.WriteLine(connection.State);
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = @"
            //        CREATE TABLE ProductCategories (
            //            ProductId INT NOT NULL,
            //            CategoryId INT NOT NULL,
            //            PRIMARY KEY (ProductId, CategoryId),
            //            FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
            //            FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
            //        )";
            //    command.Connection = connection;
            //    await command.ExecuteNonQueryAsync();
            //    Console.WriteLine("Table ProductCategories created");
            //}
            //Console.WriteLine("Connection Close");
            //Console.ReadLine();



            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    await connection.OpenAsync();
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = "CREATE TABLE Products (ProductId INT PRIMARY KEY IDENTITY, Name nvchar(50) not null, Description nvchar(50), Price decimal(18,2), Stock int )";
            //    command.Connection = connection;
            //    await command.ExecuteNonQueryAsync();
            //    Console.WriteLine("Table Products created");
            //}


            //ПРИМЕР ДОБАВЛЕНИЯ
            var ps=new ProductStage(connectionString);
            await ps._addProduct("KEYBOARD", "75% kgaming with LED", 8000, 15);

        }
    }

    public class ProductStage
    {
        private string _connectionString;

        public ProductStage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task _addProduct(string name, string description, decimal price, int stock)
        {
            // Вставляем данные непосредственно в строку запроса
            string query = $@"
            INSERT INTO Products (Name, Description, Price, Stock)
            VALUES ('{name}', '{description}', {price}, {stock})";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Выполняем запрос
                    int number = await command.ExecuteNonQueryAsync();
                    Console.WriteLine($"Добавлено {name} продукт(ов)");
                }
            }
        }



    }



}
