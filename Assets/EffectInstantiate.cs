using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EffectInstantiate : MonoBehaviour {


    public ParticleSystem rain;
    public ParticleSystem snow;
    public ParticleSystem fog;
	public GameObject controller;
	private String returnValue;
	public String weatherType;


	public GameObject dog;
	private Animator anim;


    // Use this for initialization
    void Start (){
		//Debug.Log (controller.GetComponent<WeatherController> ().returnvalue);
		//Debug.Log (controller.GetComponent<WeatherController> () + "fjjgjgj");
//		if (controller.GetComponent<WeatherController> ().returnvalue != null) {
//			
//			returnValue = controller.GetComponent<WeatherController> ().returnvalue.ToString ();
//		}
		//Debug.Log (returnValue);
		anim = dog.GetComponent<Animator> ();

    }

	public void makeHappyDog() {
		anim.SetTrigger ("isHappy");
		//anim.SetBool ("isHappy", false);
		if (rain.isPlaying)
			rain.Stop ();
		if (fog.isPlaying)
			fog.Stop ();
		if (snow.isPlaying)
			snow.Stop ();
	}

	public void makeSadDog() {
		anim.SetTrigger ("isSad");

		if (!rain.isPlaying)
			rain.Play ();
		if (fog.isPlaying)
			fog.Stop ();
		if (snow.isPlaying)
			snow.Stop ();
	}

	public void makeSnowDog() {
		if (rain.isPlaying)
			rain.Stop ();
		if (fog.isPlaying)
			fog.Stop ();
		if (!snow.isPlaying)
			snow.Play ();
	}
	
	// Update is called once per frame
	public void changeScene (string returnValue){
		string trim = returnValue.Trim('"');
		string[] split = trim.Split ('.');
		string x = (string) split.GetValue (0);
		int num = int.Parse (x);
		weatherType = "";

		// Set String variable based on filename number
		for (int i = 0; i <= 33; i++) {
			if (num <= 4) {
				weatherType = "Sunny";
			} else if (num > 4 && num <= 13) {
				weatherType = "Rain";
			} else if (num > 13 && num <= 16) {
				weatherType = "Snow";
			} else if (num > 16 && num <= 21) {
				weatherType = "Cloud";
			} else if (num > 21 && num <= 24) {
				weatherType = "Rain";
			} else if (num > 27 && num <= 33) {
				weatherType = "Snow";
			}
		}

		if (weatherType.Equals ("Sunny")) {
			if (rain.isPlaying)
				rain.Stop ();
			if (fog.isPlaying)
				fog.Stop ();
			if (snow.isPlaying)
				snow.Stop ();
			
		}
		else if (weatherType.Equals ("Rain")) {
			if (!rain.isPlaying)
				rain.Play ();
			if (fog.isPlaying)
				fog.Stop ();
			if (snow.isPlaying)
				snow.Stop ();
			//makeHappyDog ();
		}
		else if (weatherType.Equals ("Snow")) {
			if (rain.isPlaying)
				rain.Stop ();
			if (fog.isPlaying)
				fog.Stop ();
			if (!snow.isPlaying)
				snow.Play ();
			//makeSadDog ();
		}
		else if (weatherType.Equals ("Cloud")) {
			if (rain.isPlaying)
				rain.Stop ();
			if (!fog.isPlaying)
				fog.Play ();
			if (!snow.isPlaying)
				snow.Stop ();
			//makeHappyDog ();
			
		}
	}
}
