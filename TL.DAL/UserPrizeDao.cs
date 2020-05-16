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
    public class UserPrizeDao: IUserPrizeDao
    {
        private string _connectionString = "Data Source=DESKTOP-ERH7HNQ\\SQLEXPRESS;Initial Catalog=User_Prize;Integrated Security=True";
        public void Add(int value1, int value2)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "INSERT_User_Prize";

                var parameter = command.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = value1;
                parameter.ParameterName = "@UserId";
                command.Parameters.Add(parameter);

                var parameter2 = command.CreateParameter();
                parameter2.DbType = DbType.Int32;
                parameter2.Value = value2;
                parameter2.ParameterName = "@PrizeId";
                command.Parameters.Add(parameter2);

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
                command.CommandText = "Delete_User_Prize";

                var parameter = command.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = value;
                parameter.ParameterName = "@UserId";
                command.Parameters.Add(parameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        
        public IEnumerable<UserPrize> GetOnOne(int value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                List<UserPrize> products = new List<UserPrize>();
                var result = new List<UserPrize>();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetOnOne_User_Prize";

                var parameter = command.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = value;
                parameter.ParameterName = "@UserId";
                command.Parameters.Add(parameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new UserPrize
                    {
                        UserId = (int)reader["UserId"],
                        PrizeId = (int)reader["PrizeId"],
                    });
                }
                return result.ToList();
            }
        }
    }
}
