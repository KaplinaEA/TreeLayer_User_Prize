using System;
using System.Collections.Generic;
using System.Text;
using TL.Entities;

namespace TL.BLL.Interface
{
    public interface IPrizeLogic
    {
        void Add(string value);
        IEnumerable<Prize> GetAll();

        Prize Get(int value);
    }
}
