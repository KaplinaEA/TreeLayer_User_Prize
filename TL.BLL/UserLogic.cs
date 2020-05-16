using System;
using System.Collections.Generic;
using System.Text;
using TL.BLL.Interface;
using TL.DAL;
using TL.DAL.Interface;
using TL.Entities;

namespace TL.BLL
{
    public class UserLogic: IUserLogic
    {
        public IUserDao userLogic;

        public UserLogic()
        {
            this.userLogic = new Userdao();
        }

        public void Add(string value1, DateTime value2)
        {
            this.userLogic.Add(value1, value2);
        }

        public void Delete(int value)
        {
            this.userLogic.Delete(value);
        }

        public IEnumerable<User> GetAll() 
        {
            return this.userLogic.GetAll();
        }

        
        public User Get(int value)
        {
            return userLogic.Get(value);
        }
    }
}
