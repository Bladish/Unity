using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    public float speed;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = 0;
        float z = Input.GetAxis("Vertical")  * speed;

        if (Input.GetKey(KeyCode.Q)) y--;
        if (Input.GetKey(KeyCode.E)) y++;

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.Translate(x, y, z);
	}
}
