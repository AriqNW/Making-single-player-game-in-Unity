using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//memanggil UI

public class HealthUI : MonoBehaviour {

    Slider slider;
    Movement move;

	// Use this for initialization
	void Start () {
        move = GameObject.Find("Player").GetComponent<Movement>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = move.health;//merubah nilai value di slider
	}
}
