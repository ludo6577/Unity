using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Graph
{
    class Edges
    {
        private List<Edge> edges;
        public List<Edge> EdgesList
        {
            get { return edges; }
        }

        public Edges(GameObject entityToDuplicate, int edgesCount, int scale)
        {
            edges = new List<Edge>(edgesCount * edgesCount * edgesCount);

            for (int i = 0; i < edgesCount; i++)
            {
                for (int j = 0; j < edgesCount; j++)
                {
                    for (int k = 0; k < edgesCount; k++)
                    {
                        Vector3 position = new Vector3(i * scale, j * scale, k * scale);
                        Edge edge = new Edge(entityToDuplicate, position);
                        edges.Add(edge);
                    }
                }
            }
        }

        public void Clear()
        {
            while (edges.Count > 0)
            {
                edges[0].Destroy();
                edges.RemoveAt(0);
            }
        }
    }
}