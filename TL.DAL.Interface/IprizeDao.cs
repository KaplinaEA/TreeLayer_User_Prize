using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.DAL.Interface
{
    public interface IprizeDao
    {
        void Add(string value);
        IEnumerable<Prize> GetAll();
        Prize Get(int value);
    }
}
