using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{

    [SerializeField]
    public GridGenerator.STileStruct myTile;

    private void OnMouseEnter()
    {
        GridGenerator.grid.SetCurrentTile(this);
    }

    private void OnMouseExit()
    {
        
    }
}
