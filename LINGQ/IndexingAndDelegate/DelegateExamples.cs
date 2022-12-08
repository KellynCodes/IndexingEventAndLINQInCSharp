namespace LINGQ.IndexingAndDelegate
{
    internal class DelegateExamples
    {
        event Func<int, int, bool> TrueOrFalse;

        public void LogIsTrue(Func<int, int, bool> result) => TrueOrFalse += result;

        void IsTrue(int number, int number1) => TrueOrFalse(number, number1);

        public void ConsoleResult()
        {
            IsTrue(9, 2);
            ActionBool("Kelechi Amos", 24);
        }
        Action<string, int> ActionBool = delegate (string name, int age)
        {
            Console.WriteLine($"The name of the buyer is {name} and his age is {age}");
        };
    }
}
