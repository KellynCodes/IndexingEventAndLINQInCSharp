namespace LINGQ.LINQ
{
    internal class DataStore
    {
        public class Team
        {
            public Team(string name, params int[] years)
            {
                Name = name;
                Years = years != null ? new List<int>(years) : new List<int>();
            }
            public string Name { get; }
            public IEnumerable<int> Years { get; }
        }

        public class Championship
        {
            public Championship(int year, string first, string second, string third)
            {
                Year = year;
                First = first;
                Second = second;
                Third = third;
            }
            public int Year { get; }
            public string First { get; }
            public string Second { get; }
            public string Third { get; }
        }

        public class Racer : IComparable<Racer>, IFormattable
        {
            public Racer(string firstName, string lastName, string country,
            int starts, int wins)
            : this(firstName, lastName, country, starts, wins, null, null) { }
            public Racer(string firstName, string lastName, string country,
            int starts, int wins, IEnumerable<int> years, IEnumerable<string> cars)
            {
                FirstName = firstName;
                LastName = lastName;
                Country = country;
                Starts = starts;
                Wins = wins;
                Years = years != null ? new List<int>(years) : new List<int>();
                Cars = cars != null ? new List<string>(cars) : new List<string>();
            }
            public string FirstName { get; }
            public string LastName { get; }
            public int Wins { get; }
            public string Country { get; }
            public int Starts { get; }
            public IEnumerable<string> Cars { get; }
            public IEnumerable<int> Years { get; }
            public override string ToString() => $"{FirstName} {LastName}";
            public int CompareTo(Racer other) => LastName.CompareTo(other?.LastName);
            public string ToString(string format) => ToString(format, null);
            public string ToString(string format, IFormatProvider formatProvider)
            {
                switch (format)
                {
                    case null:
                    case "N":
                        return ToString();
                    case "F":
                        return FirstName;
                    case "L":
                        return LastName;
                    case "C":
                        return Country;
                    case "S":
                        return Starts.ToString();
                    case "W":
                        return Wins.ToString();
                    case "A":
                        return $"{FirstName} {LastName}, {Country}; starts: {Starts}, wins: {Wins}";
                    default:
                        throw new FormatException($"Format {format} not supported");
                }
            }
        }

        public static class Formula1
        {
            private static List<Racer> s_racers;
            public static IList<Racer> GetChampions() => s_racers ?? (s_racers = InitializeRacers);
            private static List<Racer> InitializeRacers =>
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

            private static List<Team> s_teams;
            public static IList<Team> GetContructorChampions()
            {
                if (s_teams == null)
                {
                    s_teams = new List<Team>()
                {
                     new Team("Vanwall", 1958),
                     new Team("Cooper", 1959, 1960),
                     new Team("Ferrari", 1961, 1964, 1975, 1976, 1977, 1979, 1982, 1983, 1999, 2000, 2001, 2002, 2003, 2004, 2007, 2008),
                     new Team("BRM", 1962),
                     new Team("Lotus", 1963, 1965, 1968, 1970, 1972, 1973, 1978),
                     new Team("Brabham", 1966, 1967),
                     new Team("Matra", 1969),
                     new Team("Tyrrell", 1971),
                     new Team("McLaren", 1974, 1984, 1985, 1988, 1989, 1990, 1991, 1998),
                     new Team("Williams", 1980, 1981, 1986, 1987, 1992, 1993, 1994, 1996,1997),
                     new Team("Benetton", 1995),
                     new Team("Renault", 2005, 2006),
                     new Team("Brawn GP", 2009),
                     new Team("Red Bull Racing", 2010, 2011, 2012, 1013),
                     new Team("Mercedes", 2014, 2015, 2016, 2017)
                };
                }
                return s_teams;
            }

            private static List<Championship> s_championships;
            public static IEnumerable<Championship> GetChampionships()
            {
                if (s_championships == null)
                {
                    s_championships = new List<Championship>
                {
                    new Championship(1950, "Nino Farina", "Juan Manuel Fangio", "Luigi Fagioli"),
                    new Championship(1951, "Juan Manuel Fangio", "Alberto Ascari", "Froilan Gonzalez"),
                    new Championship(1952,  "Alberto Ascari", "Juan Manuel Fangio", "Froilan Gonzalez"),
                    new Championship(1953,  "Alberto Ascari", "Juan Manuel Fangio", "Froilan Gonzalez"),
                    new Championship(1954, "Juan Manuel Fangio", "Alberto Ascari", "Froilan Gonzalez"),

                };
                }
                return s_championships;
            }
        }
    }
}
