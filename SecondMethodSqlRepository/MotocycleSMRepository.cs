using Concessionario.Entities;
using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.SecondMethodSqlRepository
{
    class MotocycleSMRepository : IMotocycleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = Magazzino2;" +
                                         "Integrated Security = true;";
        public void Delete(Motocycle motocycle)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Motocycle where Id = @id";
                command.Parameters.AddWithValue("@id", motocycle.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Motocycle> Fetch()
        {
            List<Motocycle> motocycles = new List<Motocycle>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Motocycle";

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var year = (int)reader["ProductionYear"];
                    var id = (int)reader["Id"];

                    Motocycle motocycle = new Motocycle(brand, model, year, id);

                    motocycles.Add(motocycle);
                }
            }
            return motocycles;
        }

        public Motocycle GetById(int? id)
        {
            Motocycle motocycle = new Motocycle();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Motocycle where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var year = (int)reader["ProductionYear"];

                    motocycle = new Motocycle(brand, model, year, id);
                }
            }
            return motocycle;
        }

        public void Insert(Motocycle motocycle)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Motocycle values (@brand, @model, @year)";
                command.Parameters.AddWithValue("@brand", motocycle.Brand);
                command.Parameters.AddWithValue("@model", motocycle.Model);
                command.Parameters.AddWithValue("@year", motocycle.ProductionYear);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Motocycle motocycle)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Motocycle set Brand = @brand, Model = @model, ProductionYear = @year where Id = @id";
                command.Parameters.AddWithValue("@brand", motocycle.Brand);
                command.Parameters.AddWithValue("@model", motocycle.Model);
                command.Parameters.AddWithValue("@year", motocycle.ProductionYear);
                command.Parameters.AddWithValue("@id", motocycle.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
