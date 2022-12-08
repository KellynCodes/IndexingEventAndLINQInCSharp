using LINGQ.IndexingAndDelegate;
using LINGQ.LINQ;

DelegateExamples filteringOperator = new();

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
//=================================End of IndexingAndDelegate==================================


//=================================Beggining of LINQ==================================
//ProjectorOperator.UsingQuerySyntaxWithSelect();
//ProjectorOperator.UsingMethodsSyntaxWithSelect();
//ProjectorOperator.UsingQuerySyntaxWithCompoundFrom();
//ProjectorOperator.UsingMethodSyntaxWithCompoundFrom();

//FilteringOperator.UsingWhereQuerySyntax();
//FilteringOperator.UsingWhereMethodSyntax();
//FilteringOperator.UsingOfTypeMethodSyntax();
//FilteringOperator.UsingIsQuerySyntax();
//FilteringOperator.UsingWhereMethodSyntaxTest();

//Charles
//FilteringOperator.QueryRacers2();
//FilteringOperator.QueryUkRacers2();

//Stephen
FilteringOperator.LondonRacers();