using AZVMTest01.Models;
using System.Data.SqlClient;

namespace AZVMTest01.Services
{
    public class ProductService
    {
        public string db_source = "azdbserverin01.database.windows.net";
        public string db_user = "azdb01";
        public string db_pwd = "TestServer@987654321";
        public string db_database = "azdb01";

        public List<Product> GetProducts()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_pwd;
            _builder.InitialCatalog = db_database;

            List<Product> products = new List<Product>(); 
            SqlConnection connection = new SqlConnection(_builder.ConnectionString);
            connection.Open();
            string statement = "SELECT ProductId, ProductName, Quantity FROM products";

            SqlCommand command = new SqlCommand(statement, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    products.Add(product);
                }
            }
            connection.Close();
            return products;
        }
    }
}
