using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.DAL.Interface
{
    public interface IUserDao
    {
        void Add(string value1, DateTime value2);
        void Delete(int value);
        IEnumerable<User> GetAll(); 
        User Get(int value);
    }
}
