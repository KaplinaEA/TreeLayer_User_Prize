using System;
using System.Collections.Generic;
using System.Text;
using TL.BLL.Interface;
using TL.DAL;
using TL.DAL.Interface;
using TL.Entities;

namespace TL.BLL
{
    public class PrizeLogic : IPrizeLogic
    {
        public IprizeDao prizeLogic;

        public PrizeLogic()
        {
            this.prizeLogic = new PrizeDao();
        }

        public int Add(string value)
        {
            return this.prizeLogic.Add(value);
        }

        public IEnumerable<Prize> GetAll()
        {
            return this.prizeLogic.GetAll();
        }

        public void Serialize()
        {
            this.prizeLogic.Serialize();
        }

        public void Deserialize()
        {
            this.prizeLogic.Deserialize();
        }


        public Prize Get(int value)
        {
            return this.prizeLogic.Get(value);
        }
    }
}
