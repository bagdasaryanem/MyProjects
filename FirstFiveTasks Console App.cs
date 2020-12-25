using System;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Solutions sln = new Solutions();

            Console.WriteLine("Task 1: IsPalindrome");
            Console.WriteLine(sln.IsPalindrome("Level"));

            Console.WriteLine("Task 2: MinSplit");
            Console.WriteLine(sln.MinSplit(29));
            
            Console.WriteLine("Task 3: NotContains");
            Console.WriteLine(sln.NotContains(new[] {5, 10, 15, 20}));

            Console.WriteLine("Task 4: IsProperly");
            Console.WriteLine(sln.IsProperly("()"));

            Console.WriteLine("Task 5: CountVariants");
            Console.WriteLine(sln.CountVariants(3));
        }
    }
}
