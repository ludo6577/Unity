using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironnementControl : MonoBehaviour {

	private EcoSystem ecoSystem;

	public AnimationCurve energy;
	public AnimationCurve oxygene;
	public AnimationCurve water;

	public GameObject waterObject;
	private float initialHeight;

	// Use this for initialization
	void Start () {
		ecoSystem = GetComponent<EcoSystem> ();
		ecoSystem.EnergyChanged += EnergyChanged;
		ecoSystem.FloreChanged += FloreChanged;
		ecoSystem.OxygeneChanged += OxygeneChanged;
		ecoSystem.WaterChanged += WaterChanged;

		initialHeight = waterObject.transform.position.y;

		//Init values
		EnergyChanged (ecoSystem, ecoSystem.Energy);
		OxygeneChanged (ecoSystem, ecoSystem.Oxygene);
		WaterChanged (ecoSystem, ecoSystem.Water);
	}

	// Update is called once per frame
	void Update () {
		
	}


	void EnergyChanged (EcoSystem sender, float newValue)
	{		
		Color ambientLightColor = RenderSettings.ambientLight;
		//ambientLightColor.b = (newValue/EcoSystem.MAX_VALUE)*0.1f;
		ambientLightColor.b = energy.Evaluate(newValue/100f);
		RenderSettings.ambientLight = ambientLightColor;
		RenderSettings.fogColor = ambientLightColor;
	}

	void FloreChanged (EcoSystem sender, float newValue)
	{
		/*
		//See: http://answers.unity3d.com/questions/12504/how-can-i-automatically-place-grass-and-other-deta.html
		// read all layers of the alphamap (the splatmap) into a 3D float array:
		float[][] alphaMapData = TerrainData.GetAlphamaps(x, y, width, height);
		
		
		// read all detail layers into a 3D int array:
		int numDetails = TerrainData.detailPrototypes.Length;
		int [][][] detailMapData = new int[TerrainData.detailWidth][TerrainData.detailHeight][numDetails];
		for (int layerNum=0; layerNum < numDetails; layerNum++) {
			int[][] detailLayer = TerrainData.GetDetailLayer(x, y, width, height, layerNum);
		}
		
		
		// write all detail data to terrain data:
		for (int n = 0; n < detailMapData.Length; n++)
		{
			TerrainData.SetDetailLayer(0, 0, n, detailMapData[n]);
		}
		
		// write alpha map data to terrain data:
		TerrainData.SetAlphamaps(x, y, alphaMapData);
		*/
	}
	
	void OxygeneChanged (EcoSystem sender, float newValue)
	{
		//RenderSettings.fogDensity = (EcoSystem.MAX_VALUE - newValue)/10000f;
		RenderSettings.fogDensity = oxygene.Evaluate((EcoSystem.MAX_VALUE - newValue)/100f);
	}

	void WaterChanged (EcoSystem sender, float newValue)
	{
		waterObject.transform.position = new Vector3(waterObject.transform.position.x, initialHeight + water.Evaluate (newValue / 100f), waterObject.transform.position.z);
	}

}
