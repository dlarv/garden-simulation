using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Neighbors neighborCells;
    public Color color;
    public Color[] colors;
    public Color nextColor;
    public bool startWhite;
    public bool switchColor;
    public bool switchColor2;

    // Start is called before the first frame update
    void Start()
    {
        if(startWhite)
        {
            color = Color.white;
            this.GetComponent<Renderer>().material.color = color;
        }
        else
        {
            color = Color.black;
            this.GetComponent<Renderer>().material.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(switchColor)
        {
            switchColor = false;

            if(color == Color.black)
            {
                color = Color.white;
                this.GetComponent<Renderer>().material.color = color;
            }
            else
            {
                nextColor = colors[0];
                this.GetComponent<Renderer>().material.color = nextColor;
            }
        }

        if (switchColor2)
        {
            switchColor2 = false;

            nextColor = colors[6];
        }
    }
    public void SetColor(Color col)
    {   
        nextColor = col;
    }
    public Color GetColor()
    {
        return color;
    }
    public void SetNeighbors(Neighbors n) 
    {
        neighborCells = n;
    }

    public void change()
    {
        color = nextColor;

        this.GetComponent<Renderer>().material.color = color;
    }
  
    public void calculate() {
        Cell[] neighbors = neighborCells.cells;
        if (neighbors[0].GetColor() == colors[0] || neighbors[2].GetColor() == colors[0])
        {
            if (neighbors[0].GetColor() == colors[0])
            {
                neighbors[0].SetColor(colors[4]);
            }
            nextColor = colors[1];
        }

        if (color == colors[1])
        {
            nextColor = colors[3];

            switch(Random.Range(1,3))
            {
                case 1:
                    neighbors[5].SetColor(colors[2]);
                    break;
                case 2:
                    neighbors[7].SetColor(colors[2]);
                    break;
            }
        }

        if (neighbors[0].GetColor() == colors[2] || neighbors[2].GetColor() == colors[2])
        {
            if (neighbors[0].GetColor() == colors[0])
            {
                //neighbors[0].nextColor = colors[4];
            }
            nextColor = colors[5];
        }

        if (color == colors[5] && neighbors[5].GetColor() == colors[6])
        {
            Debug.Log("asd");
            neighbors[5].SetColor(colors[1]);
        }

        if (color == colors[5] && neighbors[6].GetColor() == colors[6])
        {
            Debug.Log("asd");
            neighbors[6].SetColor(colors[1]);
        }

        if (color == colors[5] && neighbors[7].GetColor() == colors[6])
        {
            Debug.Log("asd");
            neighbors[7].SetColor(colors[1]);
        }    

    }
}
