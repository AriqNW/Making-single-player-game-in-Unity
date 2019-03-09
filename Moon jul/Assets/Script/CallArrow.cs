using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallArrow : MonoBehaviour {

    public GameObject arrowPrefab;
    public Transform callPoint;
    GameObject arrowInstance;
    private Quaternion rotate = Quaternion.identity;
    private float coolDown = 0f;

    Collider2D arrowcol;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z) && coolDown == 0f)
        {
            coolDown = 0.5f;

            if (gameObject.GetComponent<Movement>().facingRight)
            {
                rotate.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                rotate.eulerAngles = new Vector3(0, 180, 0);// mengeset rotasi 180 derajat
            }
            arrowInstance = Instantiate(arrowPrefab, callPoint.position, rotate) as GameObject;
            arrowcol = arrowInstance.GetComponent<Collider2D>();
            arrowcol.enabled = false;
            Destroy(arrowInstance, 1.5f);
        }

        if(coolDown > 0f)
        {
            coolDown = coolDown - Time.deltaTime;
        }
        if(coolDown < 0f)
        {
            coolDown = 0f;
        }
	}
}
