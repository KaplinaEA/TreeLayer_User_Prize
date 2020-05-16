using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TL.DAL.Interface;
using TL.Entities;

namespace TL.DAL
{
    public class Userdao: IUserDao 
    {
        private string _connectionString = "Data Source=DESKTOP-ERH7HNQ\\SQLEXPRESS;Initial Catalog=User_Prize;Integrated Security=True";
        public IEnumerable<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                List<User> products = new List<User>();
                var result = new List<User>();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAll_User";
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new User
                    {
                        Id = (int)reader["UserID"],
                        Name = (string)reader["UserName"],
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"]
                    });
                }
                return result.ToList();
            }

        }

        public void Add(string value1, DateTime value2)
        {
            DateTime now = DateTime.Now;
                int age = (now.Year - value2.Year - 1) + (((now.Month > value2.Month) 
                    || ((now.Month == value2.Month) && (now.Day >= value2.Day))) ? 1 : 0);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "INSERT_User";

                var parameter = command.CreateParameter();
                parameter.DbType = DbType.String;
                parameter.Value = value1;
                parameter.ParameterName = "@UserName";
                command.Parameters.Add(parameter);

                var parameter2 = command.CreateParameter();
                parameter2.DbType = DbType.DateTime;
                parameter2.Value = value2;
                parameter2.ParameterName = "@DateOfBirth";
                command.Parameters.Add(parameter2);

                var parameter3 = command.CreateParameter();
                parameter3.DbType = DbType.Int32;
                parameter3.Value = age;
                parameter3.ParameterName = "@Age";
                command.Parameters.Add(parameter3);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Delete_User";


                var parameter = command.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = value;
                parameter.ParameterName = "@id";
                command.Parameters.Add(parameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public User Get(int value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetById_User";
                connection.Open();

                var parametrDescription = command.CreateParameter();
                parametrDescription.DbType = DbType.Int32;
                parametrDescription.Value = value;
                parametrDescription.ParameterName = "@UserID";
                command.Parameters.Add(parametrDescription);

                var reader = command.ExecuteReader();
                User result = new User();

                while (reader.Read())
                {
                    result = new User
                    {
                        Id = (int)reader["UserID"],
                        Name = (string)reader["UserName"],
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"]
                    };
                }
                return result;
            }
        }
    }
}
