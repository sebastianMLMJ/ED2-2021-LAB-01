using System;
using Libreria_ED2;
namespace ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolB<int> tester = new ArbolB<int>(3);


            tester.insertar(4);
            tester.insertar(10);
            tester.insertar(6);
            tester.insertar(1);
            tester.insertar(15);
            Console.Read();
          

           
            

        }
    }
}
