﻿using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.DAL.Interface
{
    public interface IUserDao
    {
        int Add(string value1, DateTime value2);
        void Delete(int value);
        IEnumerable<User> GetAll(); 
        void Serialize();
        void Deserialize();
        User Get(int value);
    }
}
