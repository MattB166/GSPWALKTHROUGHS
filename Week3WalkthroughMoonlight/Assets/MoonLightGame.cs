using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLightGame : GridGenerator
{

    public Sprite Spr_Cloud;
    public Sprite Spr_Star;
    public Sprite Spr_MoonHalf;
    public Sprite Spr_MoonDark;

    public MoonLightGridPiece[,] CustomTileInfos;

    public int MaxMoons;

    private MoonTile[] FinalSolution;
    private MoonTile[] Attempt;

    protected override void GenerateGameGrid()
    {
        FinalSolution = new MoonTile[MaxMoons];
        Attempt = new MoonTile[MaxMoons];

        //create and populate the custom tiles with empty info

        //attempt at placing one cloud and one star per row and column randomly

        // attempt at spawning required number of moons from designers in vacant spots 

        //foreach moon place, generate final solution based on their pos's and pos of random clouds and stars

        // validate solution

        // if solution valid, cleanup 
    }


    private void PuzzleValidation(bool isPlayer)
    {

        //satisfaction criteria 1 - stars and clouds (rows and cols)


       //2. moons
       //







    }

    



    public class MoonLightGridPiece : GridPieceInfo
    {
        public enum EMoonLight_TileState
        {
            None,
            Star,
            Moon,
            Cloud
        }
        public EMoonLight_TileState TileState;
    }

    public class MoonTile
    {
        public int x; public int y;

        public bool UP;
        public bool DOWN;
        public bool LEFT;
        public bool RIGHT;

        public int LightOnMe;

        public bool IsFullMoon
        {
            get
            {
                return (LEFT && RIGHT || UP && DOWN);
            }


        }


    }
}
