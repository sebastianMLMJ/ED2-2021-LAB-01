using System;
using Libreria_ED2;
namespace ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolB<int> tester = new ArbolB<int>(3);

            tester.insertar(10);
            tester.insertar(20);
            tester.insertar(30);
            tester.insertar(40);
            tester.insertar(50);
            tester.insertar(60);
            //tester.insertar(60);
            
            Console.Read();
            
          

           
            

        }
    }
}
