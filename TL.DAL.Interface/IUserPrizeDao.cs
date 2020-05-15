using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.DAL.Interface
{
    public interface IUserPrizeDao
    {
        void Add(int value1, int value2); 
        void Delete(int value); 
        void Serialize();
        void Deserialize();
        IEnumerable<UserPrize> GetOnOne(int value);

    }
}
