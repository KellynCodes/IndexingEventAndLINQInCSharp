using System.Collections;
using static LINGQ.LINQ.DataStore;

namespace LINGQ.LINQ
{
        internal class FilteringOperator
        {
            //Where , Is, OfType
            public static void UsingWhereQuerySyntax()
            {
                var result = from racer in Formula1.GetChampions()
                             where
                             racer.Cars.Contains("Ferrari") || racer.Cars.Contains("Alfa Romeo")
                             select racer;

                foreach (var racer in result)
                {
                    Console.WriteLine(racer);
                }
            }
            public static void UsingWhereMethodSyntax()
            {
                var result = Formula1.GetChampions()
                    .Where(x => x.Cars.Contains("Ferrari") || x.Cars.Contains("Alfa Romeo"));

                foreach (var racer in result)
                {
                    Console.WriteLine(racer);
                }

            }
            public static void UsingOfTypeMethodSyntax()
            {
                ArrayList arrayList = new ArrayList()
            {
                1, 2,"Alex", true, 3,5, "Alexa"
            };

                var result = arrayList.OfType<int>();

                foreach (var number in result)
                {
                    Console.WriteLine(number);
                }
            }

            public static void UsingIsQuerySyntax()
            {
                List<object> list = new()
            {
                1, 2,"Alex", true, 3,5, "Alexa"
            };

                var result = from item in list
                             where item is int
                             select item;

                foreach (var number in result)
                {
                    Console.WriteLine(number);
                }
            }


            public static void UsingWhereQuerySyntaxTest()
            {
                var result = from racer in Formula1.GetChampions()
                             where
                             racer.Country == "UK"
                             select racer;

                foreach (var racer in result)
                {
                    Console.WriteLine(racer);
                }
            }


            public static void UsingWhereMethodSyntaxTest()
            {
                var result = Formula1.GetChampions()
                    .Where(x => x.Country == "UK");

                foreach (var racer in result)
                {
                    Console.WriteLine(racer);
                }

            }

            //Charles
            public static void QueryRacers2()
            {
                var result = from racer in Formula1.GetChampions()
                             from years in racer.Years
                             where years > 1960
                             select racer;

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }

            public static void QueryUkRacers2()
            {
                var result = Formula1.GetChampions().Where(racer => racer.Country.Contains("UK"));

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }

            //Stephen
            public static void LondonRacers()
            {
                var racers = Formula1.GetChampions();
                var racer = racers.Where(x => x.Country.Contains("UK"));
                foreach (var racerM in racers)
                {
                    Console.WriteLine(racerM);
                }
                int minYear = 1960;
                var racerYear = racers.SelectMany(racer => racer.Years, (x, y) => new { Racer = x, year = y })
                    .Where(x => x.year.Equals(minYear));
                foreach (var racerY in racerYear)
                {
                    Console.WriteLine(racerY.Racer.FirstName);
                }
            }

            public static void Template()
            {
                var racers = Formula1.GetChampions();
            var ChangeTypeOfRacer = racers.OfType<string>();
            Console.WriteLine(ChangeTypeOfRacer);
        }
    }
    }
