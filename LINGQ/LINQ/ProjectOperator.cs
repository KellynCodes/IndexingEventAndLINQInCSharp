using static LINGQ.LINQ.DataStore;

namespace LINGQ.LINQ
{
    internal class ProjectorOperator
        {
            static IList<Racer> racers = Formula1.GetChampions();
            //Select
            //Using Query Syntax
            public static void UsingQuerySyntaxWithSelect()
            {


                IEnumerable<Racer> racersTwo = from racer in racers
                                               where racer.FirstName.StartsWith('J')
                                               select racer;

                IEnumerable<string> racersThree = from racer in racers
                                                  where racer.FirstName.StartsWith('J')
                                                  select racer.LastName;

                //Applies to DbS: The query is not executed unless we iterate over its result
                foreach (var item in racersThree)
                {
                    Console.WriteLine(item);
                }
            }
            public static void UsingMethodsSyntaxWithSelect()
            {
                IList<Racer> racers = Formula1.GetChampions();

                IEnumerable<Racer> racersTwo = from racer in racers
                                               where racer.FirstName.StartsWith('J')
                                               select racer;

                // var result = racers.Select(x => x.FirstName.StartsWith('J'));
                var result = racers.Where(x => x.FirstName.StartsWith('J'));

                var _result = racers.Where(x => x.FirstName.StartsWith('J'))
                    .Select(x => x.LastName);

                //The query is not executed unless we iterate over its result
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

            }

            //SelectMany or Compound From
            public static void UsingQuerySyntaxWithCompoundFrom()
            {
                var cars = from racer in racers
                           from car in racer.Cars
                           select new
                           {
                               CarName = car,
                               Racer = racer.FirstName
                           };

                foreach (var car in cars)
                {
                    Console.WriteLine($"Name:{car.Racer} ,Car: {car.CarName}");
                }
            }


            public static void UsingMethodSyntaxWithCompoundFrom()
            {
                var result = racers.SelectMany(
                    _racer => _racer.Cars,
                    (racer, car) => new
                    {
                        CarName = car,
                        Racer = racer.FirstName,
                        Years = racer.Years
                    }
                );
                foreach (var car in result)
                {
                    Console.WriteLine($"Name:{car.Racer} ,Car: {car.CarName}");
                    foreach (var year in car.Years)
                    {
                        Console.WriteLine($"Championship: {year}");
                    }
                    Console.WriteLine();
                }
            }



        }
}
