using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject tileGO;

    public List <GameObject> Tiles = new List <GameObject>();

    public int rows;
    public int cols;

    public float origin_X;
    public float origin_Y;

    public float offset_X;
    public float offset_Y;

    public static GridGenerator grid;

    internal tileScript ActiveTile;

    [System.Serializable]

    public struct STileStruct
    {
        public int x;
        public int y;
        public bool bPlantOnMe;

    }




    // Start is called before the first frame update
    void Start()
    {
        grid = this; 

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject go = Instantiate(tileGO, new Vector2(origin_X + (offset_X * i),origin_Y + (offset_Y * j)),Quaternion.identity);

                STileStruct T = new STileStruct();
                T.x = i + 1;
                T.y = j + 1;

                //once create tile, make sure give it reference 

                go.GetComponent<tileScript>().myTile = T;

                Tiles.Add(go);


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetCurrentTile(tileScript T = null)
    {
        if(T)
        {
            ActiveTile = T;
        }
        else
        {
            ActiveTile = null;
        }
    }
}
