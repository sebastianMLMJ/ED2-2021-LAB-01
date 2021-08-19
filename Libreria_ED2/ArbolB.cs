using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_ED2
{
    public class ArbolB<T> where T : IComparable
    {
        #region clase nodo
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
                Padre = null;
            }

            public void InsertarOrdenar(T valor)
            {
                int posicionInsertar = 0;
                bool posicionEncontrada = false;

                while (posicionEncontrada == false)
                {
                    if (EqualityComparer<T>.Default.Equals(datos[posicionInsertar],default)==false)
                    {
                        if (valor.CompareTo(datos[posicionInsertar])==-1)
                        {
                            posicionEncontrada = true;
                        }
                        else
                        {
                            posicionInsertar++;
                        }
                    }
                    else
                    {
                        posicionEncontrada = true;
                    }
                }

                for (int i = grado - 1; i > posicionInsertar; i--)
                {
                    datos[i] = datos[i - 1];
                }

                datos[posicionInsertar] = valor;
            }
        }

        #endregion

        private int grado;
        private Nodo Raiz=null;

        public ArbolB(int _grado)
        {
            grado = _grado;
        }
        

        public void insertar(T dato)
        {
            if (Raiz==null)
            {
                Nodo nuevaRaiz = new Nodo(grado);
                nuevaRaiz.InsertarOrdenar(dato);
                Raiz = nuevaRaiz;
            }
            else
            {
                Nodo hojaInsertar = Raiz;
                hojaInsertar.InsertarOrdenar(dato);

                
            }
        }


    }
}
