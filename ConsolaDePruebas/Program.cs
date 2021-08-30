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
            tester.insertar(70);
            tester.insertar(80);
            tester.insertar(90);
            tester.insertar(5);
            tester.insertar(15);
            tester.insertar(25);
            tester.insertar(35);
            tester.insertar(45);
            tester.insertar(55);
            tester.insertar(65);
            tester.insertar(75);
            tester.insertar(85);
            tester.insertar(95);
            //19


            tester.eliminar(60);
            tester.eliminar(20);
            tester.eliminar(10);
            tester.InOrden();
            
            
            
            tester.eliminar(50);
            tester.eliminar(70);
            tester.eliminar(30);
            tester.eliminar(65);
            tester.eliminar(35);
            tester.eliminar(45);
            tester.eliminar(55);
            tester.eliminar(75);
            tester.eliminar(85);
            tester.eliminar(95);
            tester.eliminar(90);
            tester.eliminar(80);
            tester.eliminar(5);
            tester.eliminar(15);
            tester.eliminar(25);
            














            Console.Read();






           
            
          

           
            

        }
    }
}
