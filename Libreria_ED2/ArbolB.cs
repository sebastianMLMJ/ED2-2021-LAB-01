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
                PosicionarInsertar(ref hojaInsertar, dato);
                hojaInsertar.InsertarOrdenar(dato);
                if (EqualityComparer<T>.Default.Equals(hojaInsertar.datos[grado-1],default)==false)
                {
                    DividirRaiz(ref hojaInsertar);
                }
            }
        }

        private void PosicionarInsertar(ref Nodo buscarHojaref,T dato)
        {
            bool cambioNodo;
            int i;

            while (buscarHojaref.hijos[0]!=null)
            {
                i = 0;
                cambioNodo = false;

                while (cambioNodo == false)
                {
                    if (EqualityComparer<T>.Default.Equals(buscarHojaref.datos[i], default) == false)
                    {
                        if (dato.CompareTo(buscarHojaref.datos[i]) == -1)
                        {
                            buscarHojaref = buscarHojaref.hijos[i];
                            cambioNodo = true;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    else
                    {
                        buscarHojaref = buscarHojaref.hijos[i];
                        cambioNodo = true;
                    }
                }
            }
        }
        private void DividirRaiz(ref Nodo buscarHojaref)
        {
            Nodo nuevoHermano = new Nodo(grado);
            Nodo nuevaRaiz = new Nodo(grado);
            int valorMedio = grado / 2;
            
            //Pasando valor medio para nueva raiz
            nuevaRaiz.datos[0] = buscarHojaref.datos[valorMedio];
            buscarHojaref.datos[valorMedio] = default;

            //Pasando valores medios grandes a nuevo hermano
            int j = 0;
            for (int i = valorMedio+1; i < grado; i++)
            {
                nuevoHermano.datos[j] = buscarHojaref.datos[i];
                nuevoHermano.hijos[j] = buscarHojaref.hijos[i];
                buscarHojaref.datos[i] = default;
                buscarHojaref.hijos[i] = default;
                j++;
            }

            //Asignando apuntadores y la nueva raiz
            nuevaRaiz.hijos[0] = buscarHojaref;
            nuevaRaiz.hijos[1] = nuevoHermano;
            buscarHojaref.Padre = nuevaRaiz;
            nuevoHermano.Padre = nuevaRaiz;
            Raiz = nuevaRaiz;
        }
       

    }
}
