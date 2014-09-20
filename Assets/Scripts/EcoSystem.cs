using UnityEngine;
using System.Collections;

public class EcoSystem : MonoBehaviour {

	private const float ENERGY_BEGIN = 50;
	private const float FLORE_BEGIN = 50;
	private const float OXYGENE_BEGIN = 50;
	private const float WATER_BEGIN = 50;
	
	public const float MIN_VALUE = 0;
	public const float MAX_VALUE = 100;
	
	private const float FACTOR = 0.5f;
	private const float THRESHOLD = 0.01f;	
	
	public delegate void EcoSystem_ChangedEventHandler(EcoSystem sender, float newValue);
	
	public event EcoSystem_ChangedEventHandler EnergyChanged;
	public event EcoSystem_ChangedEventHandler FloreChanged;
	public event EcoSystem_ChangedEventHandler OxygeneChanged;
	public event EcoSystem_ChangedEventHandler WaterChanged;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private bool locked = false;
	public bool Locked
	{
		get { return locked; }
		set { locked = value; }
	}
	
	private float energy = ENERGY_BEGIN;
	public float Energy
	{
		get { return energy; }
		set 
		{
			float diff = value - energy;
			if ((value < MIN_VALUE || value >MAX_VALUE) || (diff > -THRESHOLD && diff < THRESHOLD))
				return;
			
			energy = value;
			if(EnergyChanged!=null)
				EnergyChanged(this, energy);

			float newValue = flore + diff * FACTOR;
			if (locked || newValue < MIN_VALUE || newValue > MAX_VALUE)
				return;
			
			Flore = newValue;
		}
	}
	
	private float flore = FLORE_BEGIN;
	public float Flore
	{
		get { return flore; }
		set 
		{
			float diff = value - flore;
			if ((value < MIN_VALUE || value > MAX_VALUE) || (diff > -THRESHOLD && diff < THRESHOLD))
				return;
			
			flore = value;
			if(FloreChanged!=null)
				FloreChanged(this, flore);
			
			float newValue = oxygene + diff * FACTOR;
			if (locked || newValue < MIN_VALUE || newValue > MAX_VALUE)
				return;
			
			Oxygene = newValue;                             
		}
	}
	
	private float oxygene = OXYGENE_BEGIN;
	public float Oxygene
	{
		get { return oxygene; }
		set 
		{
			float diff = value - oxygene;
			if ((value < MIN_VALUE || value > MAX_VALUE) || (diff > -THRESHOLD && diff < THRESHOLD))
				return;
			
			oxygene = value;
			if(OxygeneChanged!=null)
				OxygeneChanged(this, value);

			float newValue = water + diff * FACTOR;
			if (locked || newValue < MIN_VALUE || newValue > MAX_VALUE)
				return;
			
			Water = newValue;
		}
	}
	
	private float water = WATER_BEGIN;
	public float Water
	{
		get { return water; }
		set
		{
			float diff = value - water;
			if ((value < MIN_VALUE || value > MAX_VALUE) || (diff > -THRESHOLD && diff < THRESHOLD))
				return;
			
			water = value;
			if(WaterChanged!=null)
				WaterChanged(this, water);
			
			float newValue = energy + diff * FACTOR;
			if (locked || newValue < MIN_VALUE || newValue > MAX_VALUE)
				return;
			
			Energy = newValue;
		}
	}
}
