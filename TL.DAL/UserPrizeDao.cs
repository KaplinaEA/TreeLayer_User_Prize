using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TL.DAL.Interface;
using TL.Entities;

namespace TL.DAL
{
    public class UserPrizeDao: IUserPrizeDao
    {
        private List<UserPrize> userPrizes;

        public UserPrizeDao() => this.userPrizes = new List<UserPrize>();

        public void Add(int value1, int value2) 
        {
            userPrizes.Add(new UserPrize { UserId = value1, PrizeId = value2});
        }
        public void Delete(int value) 
        {
            userPrizes.RemoveAll(item => item.UserId == value);
        }

        public void Serialize()
        {
            FileStream fs1 = new FileStream("UserPrizeFile.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter1 = new BinaryFormatter();
            try
            {
                formatter1.Serialize(fs1, userPrizes);
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
            FileStream fs = new FileStream("UserPrizeFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                userPrizes = (List<UserPrize>)formatter.Deserialize(fs);

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

        public IEnumerable<UserPrize> GetOnOne(int value)
        {
            return userPrizes.FindAll(item => item.UserId == value);
        }
    }
}
