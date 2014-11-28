using UnityEngine;
using System.Collections;

public class Graph : MonoBehaviour {

	[Range(10, 100)]
	public int resolution = 10;
    private int currentResolution;

    [Range(0.1f, 10f)]
    public float pointsSize = 0.1f;


    private ParticleSystem.Particle[] points;

    // Use this for initialization
    void Start()
    {
        CreatePoints();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentResolution != resolution || points==null)
            CreatePoints();

        particleSystem.SetParticles(points, points.Length);
	}


    private void CreatePoints()
    {
        if (resolution < 10 || resolution > 100)
        {
            Debug.LogWarning("Grapher resolution out of bounds, resetting to minimum.", this);
            resolution = 10;
        }
        currentResolution = resolution;
        points = new ParticleSystem.Particle[resolution];
        float increment = 1f / (resolution - 1);
        for (int i = 0; i < resolution; i++)
        {
            float x = i * increment;
            points[i].position = new Vector3(x, 0f, 0f);
            points[i].color = new Color(x, 0f, 0f);
            points[i].size = pointsSize;
        }
    }
}
