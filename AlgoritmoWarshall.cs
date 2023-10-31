using System;
using System.Collections.Generic;

class AlgoritmoWarshall
{
    // Encontra o fecho transitivo de um grafo
    static void Warshall(List<List<int>> grafo)
    {
        int vertices = grafo.Count;

        // Percorre os vertices para identificar seus respectivos fechos
        for (int verticeAuxiliar = 0; verticeAuxiliar < vertices; verticeAuxiliar++)
        {
            for (int origem = 0; origem < vertices; origem++)
            {
                for (int destino = 0; destino < vertices; destino++)
                {
                    // Se tiver um caminho direto da origem para o destino OU um caminho da origem para o verticeAuxiliar e um caminho de verticeAuxiliar para o destino,
                    // então quer dizer que existe um caminho da origem até o destino.
                    var existeFechoTransitivo = grafo[origem][destino] != 0 ||
                                                (grafo[origem][verticeAuxiliar] != 0 &&
                                                grafo[verticeAuxiliar][destino] != 0);
                    if (existeFechoTransitivo)
                        grafo[origem][destino] = 1;
                }
            }
        }

        Mostrar(grafo, vertices);
    }

    // Imprime matriz com os fechos transitivos.
    static void Mostrar(List<List<int>> grafo, int vertices)
    {
        Console.WriteLine("A matriz de fecho transitivo é:");
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                Console.Write(grafo[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        // Foi utilizado listas ao invés de vetores para que a didática fique melhor.
        List<List<int>> grafo = new List<List<int>> {
            new List<int> { 1, 0, 0, 1 },
            new List<int> { 0, 0, 0, 1 },
            new List<int> { 0, 0, 0, 0 },
            new List<int> { 0, 0, 1, 0 }
        };

        Warshall(grafo);
    }
}
