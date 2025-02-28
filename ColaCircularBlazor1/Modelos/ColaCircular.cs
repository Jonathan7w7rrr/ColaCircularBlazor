using System;

namespace ColaCircularBlazor.Modelos
{
    public class ColaCircular<T>
    {
        private T[] elementos;
        private int frente, final, capacidad;

        public ColaCircular(int tamaño)
        {
            capacidad = tamaño;
            elementos = new T[capacidad];
            frente = -1;
            final = -1;
        }

        public bool EstaVacia() => frente == -1;

        public bool EstaLlena() => (final + 1) % capacidad == frente;

        public void Encolar(T elemento)
        {
            if (EstaLlena())
                throw new InvalidOperationException("La cola está llena.");

            if (EstaVacia())
                frente = 0;

            final = (final + 1) % capacidad;
            elementos[final] = elemento;
        }

        public T Desencolar()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La cola está vacía.");

            T elemento = elementos[frente];

            if (frente == final)
            {
                frente = -1;
                final = -1;
            }
            else
            {
                frente = (frente + 1) % capacidad;
            }

            return elemento;
        }

        public T[] ObtenerElementos()
        {
            if (EstaVacia())
                return Array.Empty<T>();

            int count = (final >= frente) ? (final - frente + 1) : (capacidad - frente + final + 1);
            T[] resultado = new T[count];
            int index = 0;
            for (int i = frente; i != final; i = (i + 1) % capacidad)
            {
                resultado[index++] = elementos[i];
            }
            resultado[index] = elementos[final];
            return resultado;
        }
    }
}

