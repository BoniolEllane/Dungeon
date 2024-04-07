using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileVisual : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTileDungeon, wallTileMap;
    [SerializeField]
    private TileBase floorTile, wallTop, wallRightSide, wallLeftSide, 
        wallDown, wallAll, wallInnerCornerDownLeft, wallInnerCornerDownRight,
        wallDiagonalCornerDownLeft, wallDiagonalCornerDownRight, 
        wallDiagonalCornerUpLeft, wallDiagonalCornerUpRight;


    public void paintFloor(IEnumerable<Vector2Int> floorPos)
    {
        paintTile(floorPos, floorTileDungeon, floorTile);
    }

    private void paintTile(IEnumerable<Vector2Int> pos, Tilemap dungeon, TileBase tile)
    {
        foreach (var position in pos)
        {
            paintEachtile(dungeon, tile, position);
        }
    }

    //paints the wallTop
    internal void paintSinglewall(Vector2Int position, string binaryValue)
    {
        //convert the binary value from string to int
        int typeAsInt = Convert.ToInt32(binaryValue, 2);

        //check or set tile base
        TileBase tile = null;
        if (WallTypesNew.wallTop.Contains(typeAsInt)){
            tile = wallTop;
        }
        else if (WallTypesNew.wallSideRight.Contains(typeAsInt))
        {
            tile = wallRightSide;
        }
        else if (WallTypesNew.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallLeftSide;

        }
        else if (WallTypesNew.wallBottom.Contains(typeAsInt))
        {
            tile = wallDown;

        }
        else if (WallTypesNew.wallFull.Contains(typeAsInt))
        {
            tile = wallAll;

        }
        if (tile != null)
        {
            paintEachtile(wallTileMap, tile, position);
        }
        
    }

    internal void paintSingleCornerwall(Vector2Int position, string binaryValue)
    {
        int typeAsInt = Convert.ToInt32(binaryValue, 2);
        TileBase tile = null;

        if (WallTypesNew.wallInnerCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallTypesNew.wallInnerCornerDownRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if (WallTypesNew.wallDiagonalCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallTypesNew.wallDiagonalCornerDownRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallTypesNew.wallDiagonalCornerUpRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if (WallTypesNew.wallDiagonalCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallTypesNew.wallFullEightDirections.Contains(typeAsInt))
        {
            tile = wallAll;
        }
        else if (WallTypesNew.wallBottmEightDirections.Contains(typeAsInt))
        {
            tile = wallDown;
        }
        if (tile != null)
        {
            paintEachtile(wallTileMap, tile, position);
        }
    }

    private void paintEachtile(Tilemap dungeon, TileBase tile, Vector2Int position)
    {
        var tilePos = dungeon.WorldToCell((Vector3Int)position);
        dungeon.SetTile(tilePos, tile);
    }
    public void Clear()
    {
        floorTileDungeon.ClearAllTiles();
        wallTileMap.ClearAllTiles();
    }
}
