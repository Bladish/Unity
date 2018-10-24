using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{

    public GameObject cellPrefab;
    int numberOfColums = 100;
    int numberOfRows = 100;
    public float tick;
    float nextTick = 0;
    GameObject[,] cells;
    int fillPrecentage = 30;
    // Use this for initialization
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGame();
    }


    void GameSetup()
    {
        cells = new GameObject[numberOfColums, numberOfRows];

        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                Vector3 spawnOffset = new Vector3(x, y, 0);
                cells[x, y] = Instantiate(cellPrefab, transform.position + spawnOffset, transform.rotation, transform);
                if (Random.Range(0, 100) > fillPrecentage)
                {
                    cells[x, y].GetComponent<Cell>().alive = true;
                }
            }
        }
    }


    void UpdateGame()
    {
        if (nextTick > tick)
        {
            CalculateNextGen();
            SetNextGen();
            nextTick -= tick;
        }

        nextTick += Time.deltaTime;
    }


    void CalculateNextGen()
    {
        bool currentState = false;
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                int neighbours = CalculateNeighours(x, y);
                cells[x, y].GetComponent<Cell>().nextGenAlive = CheckAgainstRules(neighbours, cells[x, y].GetComponent<Cell>().alive);
            }
        }
    }


    void SetNextGen()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                int neighbours = CalculateNeighours(x, y);
                cells[x, y].GetComponent<Cell>().alive = cells[x, y].GetComponent<Cell>().nextGenAlive;
            }
        }
    }


    bool CheckAgainstRules(int neighbours, bool currentState)
    {
        if (neighbours == 3) return true;
        else if (neighbours < 2 || neighbours > 3) return false;
        return currentState;
    }


    int CalculateNeighours(int x, int y)
    {
        int neighbours = 0;
        for (int deltaX = -1; deltaX <= 1; deltaX++)
        {
            for (int deltaY = -1; deltaY <= 1; deltaY++)
            {
                if (deltaX == 0 && deltaY == 0)
                {
                    continue;
                }
                try
                {
                    if (cells[x + deltaX, y + deltaY].GetComponent<Cell>().alive) neighbours++;
                }
                catch (System.IndexOutOfRangeException e)
                {

                }

            }
        }
        return neighbours;
    }
}
