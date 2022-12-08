namespace LINGQ.IndexingAndDelegate
{
    internal static class DelegateAndExtensionMethod
    {
        /// <summary>
        /// Remember extension methods must be declared at the top level statement and the class must be a static class.
        /// </summary>
        /// <param name="knowlegde"></param>
            public static void UsingExtensionMethod(this KnowledgeCheck knowlegde)
            {

            }

            public static void UsingLambdaExpression(this KnowledgeCheck knowlegde)
            {
                Console.WriteLine("In extension");
            }

            public static void UsingExtensionMethodOne(this KnowledgeCheck knowlegde, string name)
            {

            }

            public static bool UsingExtensionMethodTwo(this KnowledgeCheck knowlegde, string name, int number)
            {
                return name.Length == number;
            }

            public static bool IsEven(this int number) => number % 2 == 0;

        }

        public class KnowledgeCheck
        {
            //Lambda Expression
            public static void UsingLambdaExpression()
            {
                Console.WriteLine("Native method");

                Func<string, bool> methodOne = delegate (string name)
                {
                    return name.Length > 2;
                };

                Func<string, bool> methodTwo = (string name) => name.Length > 2;
            }

            //Extension Method
            public static void ExtensionMethods()
            {
                KnowledgeCheck knowledgeCheck = new();

                //One
                knowledgeCheck.UsingExtensionMethod();

                //Two
                knowledgeCheck.UsingExtensionMethodOne("Alexa");

                //Three
                knowledgeCheck.UsingExtensionMethodTwo("Alexa", 4);
                //Using IsEven from the extension class
                int number = 31;
                number.IsEven();

                //Trying to see what happens when we declare a extension method
                //That has the same method name and signature a native method
                knowledgeCheck.UsingLambdaExpression(); //Calls extension
                                                        //Ebube tells us how to call 
                                                        //the native version
            }
            //Anonymous Type 
            public static void UsingAnonymousTypes()
            {
                //Creating an anonymous type
                var anonymousType = new
                {
                    Name = "Alex",
                    Age = 98,
                    IsATechie = true
                };

                //How to replicate the above using an actual type
                Person person = new()
                {
                    Name = "Alex",
                    Age = 98,
                    IsATechie = true
                };
            }


            public class Person
            {
                public int Age { get; set; }
                public string Name { get; set; }
                public bool IsATechie { get; set; }
            }
        }
    }
