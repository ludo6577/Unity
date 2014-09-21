using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlidersControl : MonoBehaviour {
		
	EcoSystem ecoSystem;

	public bool Locked = false;

	public Slider sliderEnergy;
	public Slider sliderFlore;
	public Slider sliderOxygene;
	public Slider sliderWater;

	public Slider sliderEnergyUI;
	public Slider sliderFloreUI;
	public Slider sliderOxygeneUI;
	public Slider sliderWaterUI;

	// Use this for initialization
	void Start () {
		ecoSystem = GetComponent<EcoSystem> ();

		ecoSystem.EnergyChanged += EcoSystem_EnergyChanged;
		ecoSystem.FloreChanged += EcoSystem_FloreChanged;
		ecoSystem.OxygeneChanged += EcoSystem_OxygeneChanged;
		ecoSystem.WaterChanged += EcoSystem_WaterChanged;

		sliderEnergy.onValueChanged.AddListener(SliderEnergy_ValueChanged);
		sliderFlore.onValueChanged.AddListener(SliderFlore_ValueChanged);
		sliderOxygene.onValueChanged.AddListener(SliderOxygene_ValueChanged);
		sliderWater.onValueChanged.AddListener(SliderWater_ValueChanged);

		ecoSystem.Locked = Locked;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void EcoSystem_EnergyChanged(EcoSystem sender, float newValue){
		sliderEnergy.value = newValue;
		sliderEnergyUI.value = newValue;
	}
	private void EcoSystem_FloreChanged(EcoSystem sender, float newValue){
		sliderFlore.value = newValue;
		sliderFloreUI.value = newValue;
	}
	private void EcoSystem_OxygeneChanged(EcoSystem sender, float newValue){
		sliderOxygene.value = newValue;
		sliderOxygeneUI.value = newValue;
	}
	private void EcoSystem_WaterChanged(EcoSystem sender, float newValue){
		sliderWater.value = newValue;
		sliderWaterUI.value = newValue;
	}


	private void SliderEnergy_ValueChanged(float val){
		ecoSystem.Energy = val;
//		sliderEnergyUI.value = val;
	}
	private void SliderFlore_ValueChanged(float val){
		ecoSystem.Flore = val;
//		sliderFloreUI.value = val;
	}
	private void SliderOxygene_ValueChanged(float val){
		ecoSystem.Oxygene = val;
//		sliderOxygeneUI.value = val;
	}
	private void SliderWater_ValueChanged(float val){
		ecoSystem.Water = val;
//		sliderWaterUI.value = val;
	}
}
