using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Graph
{
    class Arcs
    {
        private List<Arc> arcs;

        public Arcs(ParticleSystem particleSystem, Edges edges)
        {
            foreach(Edge edge in edges.EdgesList){
                arcs.Add(new Arc(particleSystem, edge.Position));
            }
        }

        public void Render()
        {
            foreach (Arc arc in arcs)
            {
                arc.Render();
            }
        }

        public void Clear()
        {
            while (arcs.Count > 0)
            {
                arcs.RemoveAt(0);
            }
        }
    }
}
