﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TL.Entities
{
    [Serializable]
    public class Prize
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Наименование: {Title}";
        }
    }
}
