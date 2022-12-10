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

        public static void CheckIfItemHaveWhiteSpace()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset =
            from g in currentVideoGames
            where g.Contains(" ")
            orderby g
            select g;
            // Print out the results.
            foreach (string s in subset)
            {
                Console.WriteLine(s);
            }
        }

        public static void QueryOverStringsWithExtensionMethods()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset =
            currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            // Print out the results.
            foreach (string s in subset)
            {
                Console.WriteLine($"Item: {s}");
            }
        }

        /// <summary>
        ///  Once Again, Without LINQ
        ///To be sure, LINQ is never mandatory.If you so choose, you could have found the same result set by forgoing
        ///LINQ altogether and making use of programming primitives such as if statements and for loops.Here is a
        ///method that yields the same result as the QueryOverStrings() method but in a much more verbose manner:
        /// </summary>
        public static void QueryOverStringsLongHand()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            string[] gamesWithSpaces = new string[5];
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                {
                    gamesWithSpaces[i] = currentVideoGames[i];
                }
            }
            // Now sort them.
            Array.Sort(gamesWithSpaces);
            // Print out the results.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                {
                    Console.WriteLine("Item: {0}", s);
                }
            }

        }

        ///<summary>
        ///While I am sure you can think of ways to tweak the previous method, the fact remains that LINQ queries 
        ///  can be used to radically simplify the process of extracting new subsets of data from a source.Rather than
        /// building nested loops, complex if/else logic, temporary data types, and so on, the C# compiler will perform 
        ///the dirty work on your behalf, once you create a fitting LINQ query.
        /// </summary>
        

        /*=======================================================*/
        ///<summary>
        ///Set Default for [First/Last/Single]OrDefault Methods (New 10)
        /// The FirstOrDefault(), SingleOrDefault(), and LastOrDefault() methods have been updated in .NET 
        ///6/C# 10 to allow specification of the default value when the query doesn’t return any elements. The base 
        ///version of these methods automatically sets the default value(0 for a number, null for class, etc.). Now you
        ///can programmatically set the default when no record is returned.
        ///Chapter 13 ■ LINQ to Objects
        ///Take the following trivial example.The sample LINQ query doesn’t return any records.Instead of
        ///returning the default value of zero, each of the methods returns a different negative number
        /// </summary>
        public static void SettingDefaults()
        {
            int[] numbers = Array.Empty<int>();
            var query = from i in numbers where i > 100 select i;
            var number = query.FirstOrDefault(-1);
            Console.WriteLine(number);
            number = query.SingleOrDefault(-2);
            Console.WriteLine(number);
            number = query.LastOrDefault(-3);
            Console.WriteLine(number);
        }

        /// <summary>
        /// This Method below returns the total count of the list without going through the whole list to know the count, which is increases performance.
        /// <return param="GetUnenumeratedCount"></return>
        /// </summary>
        public static void GetUnenumeratedCount()
        {
     List<Racer> InitializeRacers =
            new List<Racer>
            {
             new Racer("Nino", "Farina", "Italy", 33, 5, new int[] { 1950 },new string[] { "Alfa Romeo" }),
             new Racer("Alberto", "Ascari", "Italy", 32, 10, new int[] { 1952, 1953 },new string[] { "Ferrari" }),
             new Racer("Juan Manuel", "Fangio", "Argentina", 51, 24, new int[] { 1951, 1954, 1955, 1956, 1957 }, new string[] { "Alfa Romeo", "Maserati", "Mercedes", "Ferrari" }),
             new Racer("Mike", "Hawthorn", "UK", 45, 3, new int[] { 1958 }, new string[] { "Ferrari" }),
             new Racer("Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }),
             new Racer("John", "Surtees", "UK", 111, 6, new int[] { 1964 }, new string[] { "Ferrari" }),
             new Racer("Jim", "Clark", "UKARAIN", 72, 25, new int[] { 1963, 1965 }, new string[] { "Lotus" }),
             new Racer("Jack", "Brabham", "Australia", 125, 14,new int[] { 1959, 1960, 1966 }, new string[] { "Coper", "Brabham" }),
             new Racer("Denny", "Hulme", "New Zealand", 112, 8, new int[] { 1967 }, new string[] { "Brabham" }),
             new Racer("Graham", "Hill", "UK", 176, 14, new int[] { 1962, 1968 }, new string[] { "BRM", "Lotus" }),
             new Racer("Jochen", "Rindt", "Austria", 60, 6, new int[] { 1970 }, new string[] { "Lotus" }),
             new Racer("Jackie", "Stewart", "UK", 99, 27,  new int[] { 1969, 1971, 1973 }, new string[] { "Matra", "Tyrrell" })
            };
        Console.WriteLine("Get Unenumeratord Count");
           var query = from p in InitializeRacers select p;
            var result = query.TryGetNonEnumeratedCount(out int count);
            if (result)
            {
                Console.WriteLine($"Total count:{count}");
            }
            else
            {
                Console.WriteLine("Try Get Count Failed");
            }
        }

    }
}
