using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TL.DAL.Interface;
using TL.Entities;

namespace TL.DAL
{
    public class PrizeDao: IprizeDao 
    {
        private List<Prize> prizes;

        public PrizeDao() => this.prizes = new List<Prize>();
        public IEnumerable<Prize> GetAll()
        {
            return this.prizes.ToList();
        }

        public int Add(string Value)
        {
            Prize prize = new Prize { Title = Value, Id = prizes.Count()+1 };
            prizes.Add(prize);
            return prize.Id;
        }

        public void Delete(int value)
        {
            prizes.RemoveAt(value);
        }

        public void Serialize()
        {
            FileStream fs1 = new FileStream("PrizeFile.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter1 = new BinaryFormatter();
            try
            {
                formatter1.Serialize(fs1, prizes);
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
            FileStream fs = new FileStream("PrizeFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                prizes = (List<Prize>)formatter.Deserialize(fs);

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

        public Prize Get(int value)
        {
            return prizes.Find(item => item.Id == value);
        }
    }
}
