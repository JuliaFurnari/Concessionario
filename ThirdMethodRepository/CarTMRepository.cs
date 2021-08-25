using System;
using Concessionario.Entities;
using Concessionario.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

//Da modificare con gli inserimenti
namespace Concessionario.ThirdMethodRepository
{
    class CarTMRepository : ICarDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                       "Initial Catalog = Magazzino3;" +
                                       "Integrated Security = true;";
        const string discriminator = "Car";
        public void Delete(Car car)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "delete from Vehicle where Id = @id";
            command.Parameters.AddWithValue("@id", car.Id);

            command.ExecuteNonQuery();
        }

        public List<Car> Fetch()
        {
            List<Car> cars = new List<Car>();

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
                    var supply = (int)reader["Supply"];
                    var door = (int)reader["DoorsNumber"];
                    var id = (int)reader["id"];

                    Car car = new Car(brand, model, (PowerSupply)supply, door, id);
                    cars.Add(car);
                }
            }
            return cars;
        }

        public Car GetById(int? id)
        {
            Car car = new Car();
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
                    var supply = (int)reader["Supply"];
                    var door = (int)reader["DoorsNumber"];

                    car = new Car(brand, model, (PowerSupply)supply, door, id);
                }

            }
            return car;
        }

        public void Insert(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into Vehicle values (@brand, @model, @year, @supply, @doors, @seats, @discriminator)";
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("year", "");
                command.Parameters.AddWithValue("@supply", car.Supply);
                command.Parameters.AddWithValue("@doors", car.DoorsNumber);
                command.Parameters.AddWithValue("seats", "");
                command.Parameters.AddWithValue("@discriminator", discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Vehicle set Brand = @brand, Model = @model, ProductionYear = @year, Supply = @supply" +
                                      "DoorsNumenber=@doors, SeatsNumber=@seats, Discriminato=@discriminator where Id = @id";
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@year", "");
                command.Parameters.AddWithValue("supply", car.Supply);
                command.Parameters.AddWithValue("doors", car.DoorsNumber);
                command.Parameters.AddWithValue("seats", "");
                command.Parameters.AddWithValue("@discriminator", discriminator);
                command.ExecuteNonQuery();
            }
        }
    }
}
