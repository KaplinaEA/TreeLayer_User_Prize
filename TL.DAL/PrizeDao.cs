using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TL.DAL.Interface;
using TL.Entities;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TL.DAL
{
    public class PrizeDao : IprizeDao
    {

        private string _connectionString = "Data Source=DESKTOP-ERH7HNQ\\SQLEXPRESS;Initial Catalog=User_Prize;Integrated Security=True";
        public void Add(string Value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "INSERT_Prize";

                var parameter = command.CreateParameter();
                parameter.DbType = DbType.String;
                parameter.Value = Value;
                parameter.ParameterName = "@Title";
                command.Parameters.Add(parameter);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        

        public IEnumerable<Prize> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                List<Prize> products = new List<Prize>();


                var result = new List<Prize>();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAll_Prize";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Prize
                    {
                        Id = (int)reader["PrizeId"],
                        Title = (string)reader["Title"]
                    });
                }
                return result.ToList();
            }

        }

        public Prize Get(int value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetById_Prize";
                connection.Open();

                var parametrDescription = command.CreateParameter();
                parametrDescription.DbType = DbType.Int32;
                parametrDescription.Value = value;
                parametrDescription.ParameterName = "@ID";
                command.Parameters.Add(parametrDescription);

                var reader = command.ExecuteReader();
                Prize result = new Prize();

                while (reader.Read())
                {
                    result = new Prize
                    {
                        Id = (int)reader["PrizeId"],
                        Title = (string)reader["Title"]
                    };
                }
                return result;
            }


        }
    }   
}
