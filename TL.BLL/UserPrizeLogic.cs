using System;
using System.Collections.Generic;
using System.Text;
using TL.BLL.Interface;
using TL.DAL;
using TL.DAL.Interface;
using TL.Entities;

namespace TL.BLL
{
    public class UserPrizeLogic : IUserPrizeLogic
    {

        public IUserPrizeDao userPrizeLogic;

        public UserPrizeLogic()
        {
            this.userPrizeLogic = new UserPrizeDao(); 
        }
        public void Add(int value1, int value2)
        {
            this.userPrizeLogic.Add(value1, value2);
        }

        public void Delete(int value)
        {
            this.userPrizeLogic.Delete(value);
        }

        public void Serialize()
        {
            this.userPrizeLogic.Serialize();
        }

        public void Deserialize()
        {
            this.userPrizeLogic.Deserialize();
        }

        public IEnumerable<UserPrize> GetOnOne(int value)
        {
            return this.userPrizeLogic.GetOnOne(value);
        }

     
    }
}
