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
    class VehicleFMRepository: IVehicleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = Magazzino;" +
                                         "Integrated Security = true;";

        public void Delete(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> Fetch()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vehicle)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Vehicle values(@brand, @model)";

                command.Parameters.AddWithValue("@brand", vehicle.Brand);
                command.Parameters.AddWithValue("@model", vehicle.Model);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "update Vehicle set Brand = @brand, Model = @model where Id = @id";
                command.Parameters.AddWithValue("@brand", vehicle.Brand);
                command.Parameters.AddWithValue("@model", vehicle.Model);
                command.Parameters.AddWithValue("@id", vehicle.Id);

                command.ExecuteNonQuery();
            }
        }

        internal void DeleteById(int idVehicleToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", idVehicleToDelete);

                command.ExecuteNonQuery();
            }
        }

        internal int GetId(Vehicle vehicle)
        {
            int idVehicle = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from vehicle where Brand = @brand and Model = @model";
                command.Parameters.AddWithValue("@brand", vehicle.Brand);
                command.Parameters.AddWithValue("@model", vehicle.Model);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    idVehicle = (int)reader["Id"];
                }
            }

            return idVehicle;
        }
    }
}
