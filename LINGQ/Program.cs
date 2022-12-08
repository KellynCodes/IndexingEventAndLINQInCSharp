using LINGQ;
Console.WriteLine("Hello, World!");
FilteringOperator filteringOperator = new();

Indexer indexer = new();
indexer.ShowInfo(indexer.Count);

filteringOperator.LogIsTrue(CheckIfTrue);
filteringOperator.ConsoleResult();

static bool CheckIfTrue(int number1, int number2)
{
    if (number1 % number2 == 0)
    {
        Console.WriteLine(true);
        return true;
    }
    else
    {
        Console.WriteLine(false);
        return false;
    }
}
    indexer.ShowInfo(indexer[8]);
