using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.BLL.Interface
{
    public interface IUserPrizeLogic
    {
        void Add(int value1, int value2);
        void Delete(int value);
        IEnumerable<UserPrize> GetOnOne(int value);

    }
}
