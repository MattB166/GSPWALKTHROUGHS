using NUnit.Compatibility;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject[,] Tiles;
    
    
    public GameObject GridPiece;
    public int Gridwidth;
    public int Gridheight;

    public GameObject RefObj;
    public float offset;
    public float margin;
    public float tileSize;
    public float ScaleDownValue;

    public GameObject selectionBoxPrefab;
    protected GameObject selectionBox;

    public Sprite selectionBoxSpr; 


    protected int X = 0;
    protected int Y = 0;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GenerateGrid();
        GenerateGameGrid();
        ScaleandCentreGrid(Gridheight);
    }

    protected virtual void ScaleandCentreGrid(int Gridheight)
    {
        //1. scale only if height greater than 6
        int amt = Gridheight - 6;

        //2. get all child tiles

        List<GameObject> TilesToScale = new List<GameObject>();
        for (int i = 0; i < RefObj.transform.childCount; i++)
        {
            TilesToScale.Add(RefObj.transform.GetChild(i).gameObject);
        }

        //3.de parenting them!!
        foreach(var item in TilesToScale)
        {
            item.transform.parent = null;   
        }

        //4. find centre of mass 
        Vector3 VEC = Vector3.zero;
        foreach(var item in TilesToScale)
        {
            VEC += item.transform.position;
        }    
        VEC /= TilesToScale.Count;

        //5. Move the now empty ref obj to that centroid

        RefObj.transform.position = VEC;

        //6. reparent them all

        foreach(var item in TilesToScale)
        {
            item.transform.parent = RefObj.transform;
        }

        //7. scale parent, so can scale all
        Vector3 ScaleVec = RefObj.transform.localScale;
        if(amt>0)
        {
            for(int i = 0;i<amt;i++)
            {
                ScaleVec.x /= ScaleDownValue;
                ScaleVec.y /= ScaleDownValue; 
                ScaleVec.z /= ScaleDownValue;
            }
        }
        RefObj.transform.localScale = ScaleVec;

        //8. put parent at centre 

        RefObj.transform.position = new Vector3(Camera.main.transform.position.x,
            Camera.main.transform.position.y, RefObj.transform.position.z);
    }

    internal virtual void Regenerate()
    {
        print("Regen");
        Destroygrid();
        GenerateGrid();
        GenerateGameGrid();
        ScaleandCentreGrid(Gridheight);
    }

    protected void Destroygrid()
    {
        for (int i = 0; i < Gridwidth; i++)
        {
          for (int j = 0; j < Gridheight; j++)
            {
                Destroy(Tiles[i, j]);
            }
        }
        Destroy(selectionBox);

            
    }

    protected virtual void GenerateGameGrid()
    {

    }
    
    
    protected virtual void GenerateGrid()
    {
        //creation of actual grid
        Tiles = new GameObject[Gridwidth, Gridheight];

        Vector3 SpawnPoint = RefObj.transform.position;

        for(int i = 0; i < Gridwidth; i++)
        {

            for (int j = 0; j < Gridheight; j++)
            {
                GameObject GO = Instantiate(GridPiece,SpawnPoint, Quaternion.identity);
                GO.transform.SetParent(RefObj.transform);

                GO.name = "TILE [" + i + "," + j +"]";

                GO.transform.Translate(new Vector3(
                    (i * offset) + (i * margin),
                    (j * offset) + (j * margin),
                    0), Space.Self);

                GO.transform.localScale = new Vector3(tileSize, tileSize, tileSize);
                Tiles[i,j] = GO;
            }
        }

        //creation of actual selection box
        X = 0;
        Y = 0;

        selectionBox = Instantiate(selectionBoxPrefab, Tiles[X,Y].transform.position,RefObj.transform.rotation);
        selectionBox.transform.SetParent(RefObj.transform);
        selectionBox.name = "Selection Box";
        selectionBox.transform.localScale = new Vector3(tileSize,tileSize,tileSize);

        SpriteRenderer SelectionBoxSprComp  = selectionBox.GetComponent<SpriteRenderer>();
        SelectionBoxSprComp.sprite = selectionBoxSpr;
        SelectionBoxSprComp.color = Color.green;
        SelectionBoxSprComp.sortingOrder = +10;

    }

    // Update is called once per frame
    void Update()
    {
        InputHandling();
    }

    private void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) Input_Up();
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) Input_Down();
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) Input_Left();
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) Input_Right();
        

    }

    protected virtual void Input_Up()
    {
        if(Y<Gridheight -1)
        {
            ++Y;
            SnapToTile();
        }
    }
    protected virtual void Input_Down()
    {
        if (Y > 0)
        {
            --Y;
            SnapToTile();
        }

    }
    protected virtual void Input_Left()
    {
        if (X > 0)
        {
            --X;
            SnapToTile();
        }
    }

    protected virtual void Input_Right()
    {
        if(X < Gridwidth)
        {
            ++X;
            SnapToTile();
        }
    }
    private void SnapToTile()
    {
        selectionBox.transform.position = Tiles[X,Y].transform.position;
    }

    public virtual GridPieceInfo[,] CreateItemAt(int i,int j, Sprite S, GridPieceInfo[,] TileInfos)
    {
        GameObject GO = Instantiate(GridPiece, Tiles[0, 0].transform.position, RefObj.transform.rotation);
        GO.transform.parent = Tiles[i,j].transform;
        GO.transform.localPosition = Vector3.zero;
        GO.name = S.name + "[" + i + "," + j + "]";
        GO.transform.localScale = new Vector3 (1,1,1);

        GO.GetComponent<SpriteRenderer>().sprite = S;
        ++GO.GetComponent<SpriteRenderer>().sortingOrder;

        TileInfos[i,j].GO = GO;
        return TileInfos; 
    }
    public virtual GridPieceInfo[,] DeleteItemAt(int i, int j, GridPieceInfo[,] TileInfos)
    {
        Destroy(TileInfos[i,j].GO);
        TileInfos[i,j].GO = null;
        return TileInfos;
    }
    public virtual GridPieceInfo[,] AddLayerItemAt(int i, int j, Sprite S, GridPieceInfo[,] TileInfos)
    {
        GameObject GO = Instantiate(GridPiece, Tiles[0, 0].transform.position, RefObj.transform.rotation);
        GO.transform.parent = Tiles[i, j].transform;
        GO.transform.localPosition = Vector3.zero;
        
        GO.name = S.name + "[" + i + "," + j + "]";
        GO.transform.localScale = new Vector3(1, 1, 1);

        GO.GetComponent<SpriteRenderer>().sprite = S;

        TileInfos[i, j].AdditionalLayeredGOs.Add(GO);
        GO.GetComponent<SpriteRenderer>().sortingOrder += 2 + TileInfos[i, j].AdditionalLayeredGOs.Count; 
        
        return TileInfos;
    }
}

public class GridPieceInfo
{

    public int X;
    public int Y;
    public GameObject GO;
    public GameObject Tile;


    public List<GameObject> AdditionalLayeredGOs;

    public GridPieceInfo UpNeighbour;
    public GridPieceInfo DownNeighbour;
    public GridPieceInfo LeftNeighbour;
    public GridPieceInfo RightNeighbour;


    

}

