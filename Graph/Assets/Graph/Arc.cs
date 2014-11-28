using UnityEngine;

namespace Assets.Graph
{
    class Arc
    {
        private ParticleSystem particleSystem;
        private static int ID = 0;


        private ParticleSystem.Particle[] arc;

        private static Color color = new Color(0f, 0f, 0f);
        private static int resolution = 1;
        private static int size = 1;

        public Arc(ParticleSystem particleSystem, Vector3 position)
        {
            particleSystem.name = "Particle: " + ++ID + " clones";
            GameObject parent = new GameObject("Arc clone (" + ID + ") ");

            particleSystem = (ParticleSystem)Object.Instantiate(particleSystem, position, new Quaternion());
            particleSystem.transform.parent = parent.transform;


            arc = new ParticleSystem.Particle[resolution * resolution * resolution];
            float increment = 1f / (resolution - 1);
            int i = 0;
            for (int x = 0; x < resolution; x++)
            {
                for (int z = 0; z < resolution; z++)
                {
                    for (int y = 0; y < resolution; y++)
                    {
                        Vector3 p = new Vector3(x, y, z) * increment;
                        arc[i].position = p;
                        arc[i].color = new Color(p.x, p.y, p.z);
                        arc[i++].size = 0.1f;
                    }
                }
            }
        }

        public void Render()
        {
            particleSystem.SetParticles(arc, arc.Length);
        }
        
    }
}
