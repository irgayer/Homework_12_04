using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12_04
{
    public class Visitor : Entity
    {
        public string Name { get; set; }
        public string PassportId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public string VisitPurpose { get; set; }

        public void Print()
        {
            Console.WriteLine($"Имя                 : {Name}");
            Console.WriteLine($"Номер удостоверения : {PassportId}");
            Console.WriteLine($"Время входа         : {EntryTime}");
            Console.WriteLine($"Время выхода        : {ExitTime}");
            Console.WriteLine($"Цель посещения      : {VisitPurpose}");
        }
    }
}
