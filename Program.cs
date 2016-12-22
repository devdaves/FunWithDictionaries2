using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunWithDictionaries2.Stratagies;

namespace FunWithDictionaries2
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionFactory = new OptionFactory();
            var strategyTest1 = optionFactory.CreateFromIfs("1", "A");
            var strategyTest2 = optionFactory.CreateFromSwitch("2", "C");
            var strategyTest3 = optionFactory.CreateFromDictionary("1", "C");
            
            strategyTest1.Execute();
            strategyTest2.Execute();
            strategyTest3.Execute();

            Console.WriteLine("===============");
            Console.WriteLine("Done, press Enter");
            Console.ReadLine();
        }
    }
}
