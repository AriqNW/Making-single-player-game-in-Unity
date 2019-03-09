using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Transform cam;

    [SerializeField]//untuk bisa diisi dalam unity
    private float xMin;//untuk bisa bergerak sejauh xMin

    [SerializeField]
    private float xMax;//untuk bisa bergerak sejauh xMax

    [SerializeField]
    private float yMin;//untuk bisa bergerak sejauh yMin

    [SerializeField]
    private float yMax;//untuk bisa bergerak sejauh yMax

    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Player").transform;//mencari gameObject bernama Player dan mengikutinya
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(cam.position.x, xMin, xMax),
        Mathf.Clamp(cam.position.y, yMin, yMax), transform.position.z);//untuk merubah posisi
    }
}
