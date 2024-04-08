using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class WallGen
{
    public static void MakeWall(HashSet<Vector2Int> floorPos, TileVisual tileVisual) //responsible for placing walls on our tile map
    {
        //place some basic walls 
        var basicWallpos = LocWallDirect(floorPos, Direct_2D.directList);
        //place some appropriate corner tiles in pos
        var cornerWallpos = LocWallDirect(floorPos, Direct_2D.diagonaldirectList);
        //loop through each pos that was returned and paint
        makeBasicWall(tileVisual, basicWallpos, floorPos);
        makeCornerWalls(tileVisual, cornerWallpos, floorPos);
    }

    //check in which direction from our wall pos the floor tiles, save as a binary value
    //to tileVisual for process

    private static void makeCornerWalls(TileVisual tileVisual, HashSet<Vector2Int> cornerWallpos,
       HashSet<Vector2Int> floorPos)
    {
        //loop thorugh the pos of walls that have in its diagonal dir a floor tile
        //create an 8-bit binary value in string format that will represent the adjacentPos
        //in clockwise manner
        foreach (var pos in cornerWallpos)
        {
            string adjacentBinaryValue = "";
            foreach(var dir in Direct_2D.eightdirectList)
            {
                var adjacentPos = pos + dir;
                //check if floorPos that contain adjacentPos
                if (floorPos.Contains(adjacentPos))
                {
                    adjacentBinaryValue += "1";
                }
                else
                {
                    adjacentBinaryValue += "0";
                }
            }
            tileVisual.paintSingleCornerwall(pos, adjacentBinaryValue);
        }
    }

    private static void makeBasicWall(TileVisual tileVisual, HashSet<Vector2Int> basicWallPos, 
        HashSet<Vector2Int> floorPos)
    {
        foreach (var position in basicWallPos)//search for basicwallpos
        {
            string adjacentBinaryValue = "";
            foreach (var dir in Direct_2D.directList)
            {
                var adjacentPos = position + dir; //give pos of neighbor
                if (floorPos.Contains(adjacentPos))
                {
                    adjacentBinaryValue += "1";
                }
                else
                {
                    adjacentBinaryValue += "0";
                }
            }
            tileVisual.paintSinglewall(position, adjacentBinaryValue);
        }
    }

    //locate walls in the directions to the wall pos
    private static HashSet<Vector2Int> LocWallDirect(HashSet<Vector2Int> floorPos, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPos = new HashSet<Vector2Int>(); //remove duplibcates
        foreach (var position in floorPos)
        {
            foreach (var dir in directionList)
            {
                var adjacentPos = position + dir; //checking position
                if (floorPos.Contains(adjacentPos) == false) //consideers a pos near floortile that is not on floor tiles list, means it's a wall. false == wall
                    wallPos.Add(adjacentPos); //find all the pos near floor tiles that are not on the floorPos == wall positions
            }

        }
        return wallPos;
    }
}