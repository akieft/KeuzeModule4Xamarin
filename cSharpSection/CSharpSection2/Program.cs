using System;
using CSharpSection2.Classes;

namespace CSharpSection2
{
    class Program
    {
        static IOperations am;
        static void Main(string[] args)
        {
            /*Console.WriteLine(SimpleMath.Division(432.23f, 54523.2f));

            am = new AdvancedMath();
            Console.WriteLine(am.Remainder(7, 3));

            BankAccount bankAccount1 = new BankAccount(124321.32f, "Jane Doe");
            Console.WriteLine(bankAccount1.Balance);

            ChildBankAccount bankAccount2 = new ChildBankAccount(1321.43f, "John Doe", "Jane Doe");

            Console.WriteLine(bankAccount1.AddBalance(100f));
            Console.WriteLine(bankAccount2.AddBalance(-1421.43f, true));*/

            GetData();

            Console.ReadLine();
        }

        async static void GetData()
        {
            BankAcount bankAccount = new BankAcount(543543, "Jane");

            Console.WriteLine("Log in");
            var task = await bankAccount.GetData();
            Console.WriteLine(task);
        }
    }

    interface IOperations
    {
        float Remainder(float dividend, float divisor);
    }

    class SimpleMath
    {
        public static float Add(float n1, float n2)
        {
            return n1 + n2;
        }

        public static float Substract(float n1, float n2)
        {
            return n1 - n2;
        }

        public static float Multiplication(float n1, float n2)
        {
            return n1 * n2;
        }

        public static float Division(float n1, float n2)
        {
            return n1 / n2;
        }
    }

    class AdvancedMath : SimpleMath, IOperations
    {
        public float Remainder(float dividend, float divisor)
        {
            return dividend % divisor;
        }
    }
}
}
 
