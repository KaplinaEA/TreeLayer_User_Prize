using System;
using System.Collections.Generic;
using System.Text;

namespace TL.Entities
{
    [Serializable]
    public class UserPrize
    {
        public int UserId { get; set; }
        public int PrizeId { get; set; }
    }
}
