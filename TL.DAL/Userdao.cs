using System;
using System.Collections.Generic;
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
        private List<User> users;

        public Userdao() => this.users = new List<User>();
        public IEnumerable<User> GetAll()
        { 
            return this.users.ToList();
        }

        public int Add(string value1, DateTime value2)
        {
            DateTime now = DateTime.Now;
            int age = (now.Year - value2.Year - 1) + (((now.Month > value2.Month) 
                || ((now.Month == value2.Month) && (now.Day >= value2.Day))) ? 1 : 0);
            User user = new User { Name = value1, DateOfBirth = value2, Age = age, Id = users[users.Count()-1].Id+1};
            users.Add(user);
            return user.Id;
        }

        public void Delete(int value)
        {
            users.RemoveAll(item => item.Id == value);
        }

        public void Serialize()
        {
            FileStream fs1 = new FileStream("UserFile.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter1 = new BinaryFormatter();
            try
            {
                formatter1.Serialize(fs1, users);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs1.Close();
            }
        }

        public void Deserialize()
        {
            FileStream fs = new FileStream("UserFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                users = (List<User>)formatter.Deserialize(fs);

            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public User Get(int value)
        {
            return users.Find(item => item.Id == value);
        }
    }
}
