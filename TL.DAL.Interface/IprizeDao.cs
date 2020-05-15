using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.DAL.Interface
{
    public interface IprizeDao
    {
        int Add(string value);
        IEnumerable<Prize> GetAll();
        void Serialize();
        void Deserialize();
        Prize Get(int value);
    }
}
