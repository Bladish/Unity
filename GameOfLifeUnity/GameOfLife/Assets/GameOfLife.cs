using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour {

    public GameObject cellPrefab;
    public float tick;
    float nextTick = 0;
    GameObject[] cells;
	// Use this for initialization
	void Start () {
        cells = new GameObject[10];

        for(int i = 0; i < cells.Length; i++)
        {
            Vector3 spawnOffset = new Vector3(i, 0, 0);
            cells[i] = Instantiate(cellPrefab, transform.position + spawnOffset, transform.rotation, transform);
            if(Random.Range(0, 100) > 10)
            {
                cells[i].GetComponent<Cell>().SetState(false);
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(nextTick > tick)
        {
            nextTick -= tick;
        }

        nextTick += Time.deltaTime;
	}
}
