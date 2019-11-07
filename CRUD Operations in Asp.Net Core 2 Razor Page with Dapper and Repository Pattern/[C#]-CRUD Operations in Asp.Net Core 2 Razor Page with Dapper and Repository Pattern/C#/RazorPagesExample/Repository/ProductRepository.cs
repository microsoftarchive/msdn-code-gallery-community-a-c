using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesExample.Entity;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace RazorPagesExample.Repository
{
    public class ProductRepository : IProductRepository
    {
        IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Add(Product product)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "InSERT INTO Product(Name, Model, Price) VALUES(@Name, @Model, @Price); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public int DeleteProdcut(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Product WHERE Id =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public int EditProduct(Product product)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Product SET Name = @Name, Model = @Model, Price = @Price WHERE Id = @Id";
                    count = con.Execute(query, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public List<Product> GetList()
        {
            var connectionString = this.GetConnection();
            List<Product> products = new List<Product>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Product";
                    products = con.Query<Product>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return products;
            }
        }

        public Product GetProduct(int id)
        {
            var connectionString = this.GetConnection();
            Product product = new Product();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Product WHERE Id =" + id;
                    product = con.Query<Product>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return product;
            }
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
            return connection;
        }
    }
}
