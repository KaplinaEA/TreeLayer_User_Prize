using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TL.BLL;
using TL.BLL.Interface;

namespace TL.PL
{
    public class LogicPL
    {
        public static IUserLogic userLogic = new UserLogic();
        public static IUserPrizeLogic userPrizeLogic = new UserPrizeLogic();
        public static IPrizeLogic prizeLogic = new PrizeLogic();

        public static void AddUser()
        {
            try
            {
                Console.WriteLine("Введите: Имя");
                string name = Console.ReadLine();
                Console.WriteLine("Введите: Дату рождения(дд/мм/гггг или дд.мм.гггг)");
                string[] date = Console.ReadLine().Split('/', '.');
                DateTime dat = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                if (dat > DateTime.Now) throw new ArgumentOutOfRangeException();
                userLogic.Add(name, dat);
                Console.WriteLine("Пользователь добавлен.");   
            }
            catch(ArgumentOutOfRangeException e)
            {
               Console.WriteLine("Неправильно указана дата");
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine("Пользователь с таким именем уже существует");
            }

        }
        public static void AddPrize()
        {
            try
            {
                Console.WriteLine("Введите: Наименование");
                prizeLogic.Add(Console.ReadLine());
                Console.WriteLine("Награда добавлена.");
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine("Такая награда уже существует");
            }
        }
        public static void AddUserPrize()
        {
            Console.WriteLine("Введите: Id_user, Id_prize");
            string[] id = Console.ReadLine().Split(' ');
            if (userLogic.Get(int.Parse(id[0])) == null || prizeLogic.Get(int.Parse(id[1])) == null) Console.WriteLine("Введены некорректные данные");
            else
            {
                bool no = true;
                foreach (var item in userPrizeLogic.GetOnOne(int.Parse(id[0])))
                {
                    if (item.PrizeId == int.Parse(id[1]))
                    {
                        Console.WriteLine("У пользователя есть такая награда");
                        no = false;
                    }
                }
                if (no)
                {
                    userPrizeLogic.Add(int.Parse(id[0]), int.Parse(id[1]));
                    Console.WriteLine("Пользователь получил награду");
                }
            }
        }
        public static void DeleteUser()
        {
            Console.WriteLine("Введите: id");
            int id =int.Parse( Console.ReadLine());
            if (userLogic.Get(id) != null)
            {
                userLogic.Delete(id);
                userPrizeLogic.Delete(id);
                Console.WriteLine("Пользователь удален, весе награды сброшены");
               
            }
            else Console.WriteLine("Данного пользователя нет в базе");
        }
        public static void GetAllUser()
        {
            foreach (var item in userLogic.GetAll())
            {
                Console.WriteLine(item);
                foreach (var item2 in userPrizeLogic.GetOnOne(item.Id))
                {
                    Console.WriteLine("\t" + prizeLogic.Get(item2.PrizeId));
                }
            }
        }
        public static void GetAllPrize()
        {
            foreach (var item in prizeLogic.GetAll())
                Console.WriteLine(item);
        }
    }
}
