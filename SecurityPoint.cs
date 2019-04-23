using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12_04
{
    public class SecurityPoint
    {
        private const string COMPANY_NAME = "GearBox software";

        private List<Visitor> visitors;
        private List<Visitor> allVisitors;

        public void Run()
        {
            visitors = new List<Visitor>();
            allVisitors = new List<Visitor>();

            using(var context = new AppContext())
            {
                visitors = context.Visitors.ToList();
            }

            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine($"Система управления учета КПП в компании {COMPANY_NAME}");
            Console.WriteLine("version 1.0.0");
            while (true)
            {
                Console.WriteLine("\nВыберите действие: ");
                Console.WriteLine("1) Новый посетитель");
                Console.WriteLine("2) Посетитель вышел");
                Console.WriteLine("3) Посмотреть всех");
                Console.WriteLine("4) Закрыть приложениe");

                if(int.TryParse(Console.ReadLine(), out int menu))
                {
                    if(menu == 1)
                    {
                        VisitorAdd();
                    }
                    else if(menu == 2)
                    {
                        if(visitors.Count > 0)
                        {
                            VisitorOut();
                        }
                        else
                        {
                            Console.WriteLine("Посетителей нет!");
                        }
                    }
                    else if(menu == 3)
                    {
                        Console.WriteLine();
                        PrintAllVisitors();                      
                    }
                    else if(menu == 4)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Неверное действие!");
                    }
                }
            }
        }

        private void VisitorAdd()
        {
            Visitor newVisitor = new Visitor();
            Console.WriteLine("Введите имя: ");
            newVisitor.Name = Console.ReadLine();
            Console.WriteLine("Введите номер удостоверения: ");
            newVisitor.PassportId = Console.ReadLine();
            Console.WriteLine("Введите цель посещения: ");
            newVisitor.VisitPurpose = Console.ReadLine();
            newVisitor.EntryTime = DateTime.Now;

            visitors.Add(newVisitor);
            allVisitors.Add(newVisitor);
            using(var context = new AppContext())
            {
                context.Visitors.Add(newVisitor);
                context.SaveChanges();
            }
        }

        private void VisitorOut()
        {
            PrintVisitors();
            string exitVisitorId;

            Console.WriteLine("Введите номер удостоверения посетителя: ");
            exitVisitorId = Console.ReadLine();

            if(visitors.Where(v => v.PassportId == exitVisitorId).FirstOrDefault() != null)
            {
                using (var context = new AppContext())
                {
                    var exitVisitorContext = context.Visitors.Where(v => v.PassportId == exitVisitorId).FirstOrDefault();
                    exitVisitorContext.ExitTime = DateTime.Now;

                    context.SaveChanges();
                }
                var exitVisitor = visitors.Where(v => v.PassportId == exitVisitorId).FirstOrDefault();
                visitors.Remove(exitVisitor);
                exitVisitor.ExitTime = DateTime.Now;
                allVisitors.Where(v => v.PassportId == exitVisitorId).FirstOrDefault().ExitTime = DateTime.Now;

                Console.WriteLine("Успешно");
            }
            else
            {
                Console.WriteLine("Такого посетителя нет!");
            }
            
        }
        private void PrintVisitors()
        {
            foreach(var visitor in visitors)
            {
                visitor.Print();
                Console.WriteLine();
            }
        }
        private void PrintAllVisitors()
        {
            foreach(var visitor in allVisitors)
            {
                visitor.Print();
                Console.WriteLine();
            }
        }
    }
}
