using Concessionario.Entities;
using Concessionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionario.FirstMethodSqlRepository
{
    class BusFMRepository : IDbManager<Bus>
    {
        static VehicleFMRepository vehicleRepository = new VehicleFMRepository();


        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = Magazzino;" +
                                          "Integrated Security = true;";
        public void Delete(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idBusToDelete = GetIdVehicle(bus.Id);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Bus where Id = @id";
                command.Parameters.AddWithValue("@id", bus.Id);

                command.ExecuteNonQuery();

                vehicleRepository.DeleteById(idBusToDelete);

            }
        }

        private int GetIdVehicle(int? id)
        {
            int idVehicleToDelete = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "select * from Bus where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicleToDelete = (int)reader["IdVehicle"];
                }

            }
            return idVehicleToDelete;
        }

        public List<Bus> Fetch()
        {
            List<Bus> buses = new List<Bus>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select Vehicle.Brand, Vehicle.Model, Bus.Id, Bus.SeatsNumber from Vehicle join Bus on Vehicle.Id = Bus.IdVehicle";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var seats = (int)reader["SeatsNumber"];
                    var id = (int)reader["Id"];

                    Bus bus = new Bus(brand, model, seats, id);

                    buses.Add(bus);
                }
            }
            return buses;
        }

        public Bus GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Vehicle vehicle = new Vehicle(bus.Brand, bus.Model, null);
                vehicleRepository.Insert(vehicle);
                int idVehicle = vehicleRepository.GetId(vehicle);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Bus values (@seats, @idVehicle)";
                command.Parameters.AddWithValue("@seats", bus.SeatsNumber);
                command.Parameters.AddWithValue("@idVehicle", idVehicle);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Bus bus)
        {
            throw new NotImplementedException();
        }
    }
}
