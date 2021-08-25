using System;
using Concessionario.Entities;
using Concessionario.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.ThirdMethodRepository
{
    class BusTMRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                      "Initial Catalog = Magazzino3;" +
                                      "Integrated Security = true;";
        const string discriminator = "Bus";
        public void Delete(Bus bus)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "delete from Vehicle where Id = @id";
            command.Parameters.AddWithValue("@id", bus.Id);

            command.ExecuteNonQuery();
        }

        public List<Bus> Fetch()
        {
            List<Bus> buss = new List<Bus>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Vehicle where Discriminator = @discriminator";
                command.Parameters.AddWithValue("@discriminator", discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var seats = (int)reader["SeatsNumber"];
                    var id = (int)reader["id"];

                    Bus bus = new Bus(brand, model, seats, id);
                    buss.Add(bus);
                }
            }
            return buss;
        }

        public Bus GetById(int? id)
        {
            Bus bus = new Bus();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var seats = (int)reader["SeatsNumber"];
                    

                    bus = new Bus(brand, model, seats, id);
                }

            }
            return bus;
        }

        public void Insert(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into Vehicle values (@brand, @model, @year, @supply, @doors, @seats, @discriminator)";
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);
                command.Parameters.AddWithValue("year", "");
                command.Parameters.AddWithValue("@supply", "");
                command.Parameters.AddWithValue("@doors", "");
                command.Parameters.AddWithValue("seats", bus.SeatsNumber);
                command.Parameters.AddWithValue("@discriminator", discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Vehicle set Brand = @brand, Model = @model, ProductionYear = @year, Supply = @supply" +
                                      "DoorsNumenber=@doors, SeatsNumber=@seats, Discriminato=@discriminator where Id = @id";
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);
                command.Parameters.AddWithValue("@year", "");
                command.Parameters.AddWithValue("supply", "");
                command.Parameters.AddWithValue("doors", "");
                command.Parameters.AddWithValue("seats", bus.SeatsNumber);
                command.Parameters.AddWithValue("@discriminator", discriminator);
                command.ExecuteNonQuery();
            }
        }
    }
}
