using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    internal class Dijkstra
    {
        private int rango = 0;
        private int[,] L; //Matriz de adyacencia
        private int[] C; //Arreglo de nodos 
        public int[] D; //Arreglo de distancais
        private int trango = 0;

        Dijkstra(int pRango, int[,] pArreglo)
        {
            L = new int[pRango, pRango];
            C = new int[pRango];
            D = new int[pRango];

            for (int i = 0; i < rango; i++)
            {
                for (int j = 0; j < rango; i++)
                {
                    L[i, j] = pArreglo[i, j];
                }
            }
            for (int i = 0; i < rango; i++)
            {
                C[i] = i;
            }
            C[0] = -1;

            for (int i = 0; i < rango; i++)
            {
                D[i] = L[0, i];
            }
        }
        public void solDijkstra()
        {
            int minValor = Int32.MaxValue;
            int minNodo = 0;

            for (int i = 0; i < rango; i++)
            {
                if (C[i] == -1)
                    continue;
                
                if (D[i] > 0 && D[i] < minValor)
                {
                    minValor = D[i];
                    minNodo = i;
                }
            }
            C[minNodo] = -1;

            for (int i = 0; i < rango; i++)
            {
                if (L[minNodo, i] < 0) //Si no existe arista
                    continue;

                if (D[i] < 0) //Si no hay un peso asignado
                {
                    D[i] = minValor + L[minNodo, i];
                    continue;
                }

                if ((D[minNodo] + L[minNodo, i]) < D[i])
                    D[i] = minValor + L[minNodo, i];
            }
        }
        public void CorrerDijkstra()
        {
            for (trango = 1; trango < rango; trango++)
            {
                solDijkstra();
                Console.WriteLine($"Iteración N° {trango}");
                Console.WriteLine($"Matriz de distancia: ");

                for (int i = 0; i < rango; i++)
                    Console.Write(i + " ");
                
                Console.WriteLine();

                for (int i = 0; i < rango; i++)
                    Console.Write(D[i] + " ");

                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            //Definicion de la matriz de adyacencia de digrafo
            int[,] L = {
                { -1, 10, 18, -1, -1, -1, -1 },
                { -1, -1, 6, -1, 3, -1, -1 },
                { -1, -1, -1, 3, -1, 20, -1 },
                { -1, -1, 2, -1, -1, -1, 2 },
                { -1, -1, -1, 6, -1, -1, 10 },
                { -1, -1, -1, -1, -1, -1, -1 },
                { -1, -1, 10, -1, -1, 5, -1 }, 
            };

            Dijkstra prueba = new Dijkstra((int)Math.Sqrt(L.Length), L);
            prueba.CorrerDijkstra();

            Console.WriteLine("La solución de la ruta más corta " +
                              "tomando como nodo inicial el NODO 1 es: ");

            int nodo = 1;
            foreach (int i in prueba.D)
            {
                Console.WriteLine($"Distancia minima a nodo {nodo} es ");
                Console.WriteLine(i);
                nodo++;
            }

            Console.ReadKey();
        }
    }
}
