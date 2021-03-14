using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace programme_1

{
    enum transportation
    {
        plane = 100,
        train = 50,
        bus = 30
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.go();
            Console.ReadKey();
        }
        public void go()
        {
            bool result = true;
            do
            {


                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR", true);
                Console.OutputEncoding = Encoding.UTF8;
                var names = Enum.GetNames(typeof(transportation));
                decimal total = 0;
                decimal avePrice = 0;
                decimal number = 0;
                decimal currentTotal= 0;
                decimal totalNumber = 0;

                foreach (string name in names)
                {
                    decimal price = (int)Enum.Parse(typeof(transportation), name);

                    do
                    {

                        Console.Write("Trip using {0}: ", name);
                    } while (!decimal.TryParse(Console.ReadLine(), out number));

                    totalNumber += number;
                    total += number * price;
                    currentTotal = number * price;
                    Console.WriteLine("Total of current trip {0}", currentTotal);
                    if (total == 0)
                    {
                        Console.WriteLine("You did not have any trip from Venice to Bergamo.Thus, your total is 0.");
                    }
                    
                }
                Console.WriteLine("Total amount spend by bruno in transporation is : {0}", total.ToString("c"));
                Console.WriteLine("total roundtrips are taken :{0}", totalNumber);
                Console.WriteLine("Enter 1 for average");

                string value;
                value = Console.ReadLine();
                int choice = int.Parse(value);
                try
                {
                    switch (choice)
                    {

                        case 1:

                            avePrice = total / totalNumber;
                            Console.WriteLine("Average price of the trips is {0}", avePrice.ToString("c"));
                            break;

                        default:
                            break;

                    }
                }catch (Exception)
                {
                    Console.WriteLine("Can not divide by zero ");
                }

                string answer = "N";
                do
                {
                    Console.Write("Do you want to continue? ");
                    answer = Console.ReadLine();
                } while (answer != "Y" && answer != "N");
                switch (answer)
                {
                    case "Y":
                        result = true;
                        break;
                    case "N":
                        result = false;
                        break;
                    default:
                        break;

                }
            } while (result);
          
        }
    }
}
