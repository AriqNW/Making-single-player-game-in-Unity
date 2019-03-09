using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private Transform cam;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMin;

    [SerializeField]
    private float yMax;

    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(Mathf.Clamp(cam.position.x, xMin, xMax),
        Mathf.Clamp(cam.position.y, yMin, yMax), transform.position.z);
    }
}
