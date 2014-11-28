using UnityEngine;

namespace Assets.Graph
{
    class Edge
    {
        /*
         *  The particule (may be replaced by anything !)
         */
        private GameObject entity;
        private static int ID = 0;

        public Vector3 Position
        {
            get { return entity.transform.position; }
        }

        public Edge(GameObject entityToClone, Vector3 position)
        {
            entityToClone.name = "Edges: " + ++ID + " clones";
            GameObject parent = new GameObject("Edge clone (" + ID + ") ");

            float x = entityToClone.transform.position.x + position.x;
            float y = entityToClone.transform.position.y + position.y;
            float z = entityToClone.transform.position.z + position.z;

            entity = (GameObject)Object.Instantiate(entityToClone, new Vector3(x, y, z), new Quaternion());
            entity.transform.parent = parent.transform;
        }

        public void Destroy()
        {
            Object.DestroyImmediate(entity);
            ID--;
        }
    }
}
