using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public bool alive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(bool alive)
    {
        if (alive)
        {
            GetComponent<MeshRenderer>().enabled = true; 
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
