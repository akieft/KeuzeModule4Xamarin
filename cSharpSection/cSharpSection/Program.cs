using System;

namespace cSharpSection
{
    class Program
    {
        static float n1 = 432, n2 = 543;
        private static void Main(string[] args)
        {
            var addition = Add();
            var substraction = Substract();
            var multiplication = Multiply();
            var division = Divide();

            Console.WriteLine(addition);
            Console.WriteLine(substraction);
            Console.WriteLine(multiplication);
            Console.WriteLine(division);

            Console.ReadLine();
        }

        private static float Add()
        {
            float result;
            result = n1 + n2;

            return result;
        }

        private static float Substract()
        {
            return n1 - n2;
        }

        private static float Multiply()
        {
            return n1 * n2;
        }

        private static float Divide()
        {
            return n1 / n2;
        }




        /*  private static void Main(string[] args)
          {
              Console.WriteLine("Hello World!");

              //  Console.WriteLine(Add(432, 543));
              Add(432, 543);

              Console.ReadLine();
          }

          private static void Add(int n1, int n2)
          {
              int result;
              result = n1 + n2;

              Console.WriteLine(result);
          }*/
    }
}
