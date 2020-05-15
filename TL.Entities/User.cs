using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TL.Entities
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }

       
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}  Имя: {Name} Дата рождения: {DateOfBirth.ToShortDateString()} возраст: { Age} ";
        } 
    }

}




