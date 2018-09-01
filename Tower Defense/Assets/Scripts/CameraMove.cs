using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float speed=15;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = -Input.GetAxis("Mouse ScrollWheel");

        //Debug.Log(mouse);

        transform.Translate(new Vector3(-h, mouse*40, -v) * speed * Time.deltaTime,Space.World);
	}
}
