using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_ED2
{
    public class ArbolB<T> where T : IComparable
    {
        private class Nodo
        {
            public T[] datos;
            public Nodo[] hijos;
            public Nodo Padre;
            int grado;

            public Nodo(int _grado)
            {
                grado = _grado;
                datos = new T[_grado];
                hijos = new Nodo[_grado + 1];
            }
            public void InsertarOrdenar(T valor)
            {
                int posicionInsertar = 0;
                bool posicionEncontrada = false;

                while (posicionEncontrada == false)
                {
                    if (datos[posicionInsertar].CompareTo(valor) == -1)
                    {
                        posicionEncontrada = true;
                    }
                    else
                    {
                        posicionInsertar++;
                    }
                }

                for (int i = grado - 1; i > posicionInsertar; i--)
                {
                    datos[i] = datos[i - 1];
                }

                datos[posicionInsertar] = valor;


            }
        }
    }
}
