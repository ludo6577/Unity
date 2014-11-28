using UnityEngine;
using System.Collections;
using Assets.Graph;

public class Graph : MonoBehaviour
{
    public GameObject EdgeEntity;
    public ParticleSystem ArcEntity;

    [Range(1, 100)]
    public int edgeCount = 2;
    private int currentEdgeCount;

    [Range(1, 100)]
    public int size = 10;
    private int currentSize;

    private Edges edges;
    //private Arcs arcs;

    // Use this for initialization
    void Start()
    {
        CreateEdges();
        //CreateArcs();
    }

    // Update is called once per frame
    void Update()
    {
        if (paramsChanged())
        {
            CreateEdges();
            CreateArcs();
        }
        //if(arcs!=null)
        //    arcs.Render();
    }

    public void CreateEdges()
    {
        setParams();
        if (edges != null)
            edges.Clear();
        edges = new Edges(EdgeEntity, edgeCount, size);
    }

    public void CreateArcs()
    {
        setParams();
        //if (arcs != null)
        //    arcs.Clear();
        //arcs = new Arcs(ArcEntity, edges);
    }



    private void setParams()
    {
        currentEdgeCount = edgeCount;
        currentSize = size;
    }

    private bool paramsChanged()
    {
        return edges == null || currentEdgeCount != edgeCount || currentSize != size;
    }

    //private void CreateGraph()
    //{
    //    currentResolution = resolution;
    //    points = new ParticleSystem.Particle[resolution, resolution];
    //    float increment = 1f / (resolution - 1);
    //    for (int i = 0; i < resolution; i++)
    //    {
    //        float x = i * increment;
    //        points[i, 1].position = new Vector3(x, 0f, 0f);
    //        points[i].color = new Color(x, 0f, 0f);
    //        points[i].size = pointsSize;
    //    }
    //}
}
