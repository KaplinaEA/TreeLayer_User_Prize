﻿using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.BLL.Interface
{
    public interface IUserLogic
    {
        void Add(string value1, DateTime value2);
        void Delete(int value);
        IEnumerable<User> GetAll();
        User Get(int value);
    }
}
