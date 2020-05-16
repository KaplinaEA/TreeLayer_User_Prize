using System;

namespace TL.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            bool A = true;
            while (A)
            {
                Console.WriteLine("Введите действие: " +
                    "\n 1- Добавить пользователя " +
                    "\n 2- Добавить награду" +
                    "\n 3- Добавить награду пользователю" +
                    "\n 4- Удалить пользователя" +
                    "\n 5- Вывести всех пользователей" +
                    "\n 6- Вывести все награды");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        LogicPL.AddUser();
                        break;
                    case "2":
                        LogicPL.AddPrize();
                        break;
                    case "3":
                        LogicPL.AddUserPrize();
                        break;
                    case "4":
                        LogicPL.DeleteUser();
                        break;
                    case "5":
                        LogicPL.GetAllUser();
                        break;
                    case "6":
                        LogicPL.GetAllPrize();
                        break;
                    default:
                        A = false;
                        break;
                }

            }

        }
        
    }
}
