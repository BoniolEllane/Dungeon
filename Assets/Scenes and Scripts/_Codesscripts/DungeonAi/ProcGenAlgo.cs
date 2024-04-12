using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public static class ProcDungeonAlgo
{
    public static HashSet<Vector2Int> RWalk(Vector2Int startPos, int wLength)

    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;

        for (int i = 0; i < wLength; i++)
        {
            var newPos = prevPos + Direct_2D.randDirect();
            path.Add(newPos);
            prevPos = newPos;
        }
        return path;
    }
    public static List<Vector2Int> Corridor(Vector2Int startPos, int corLength)
    {
        /*algo selects and walk in single direction through the corLength; 
         * returns the created path; pass the last position on our path to get the 
         * next start position (no repetition)*/
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direct_2D.randDirect();
        var recentPos = startPos;//new startPosition
        corridor.Add(recentPos);

        for (int i = 0; i < corLength; i++)
        {
            recentPos += direction;
            corridor.Add(recentPos);
        }
        return corridor;
    }
    public static List<BoundsInt> BSP(BoundsInt splitSpace, int minWidth, int minHeight) //bounding box represents the rooms
    {
        Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>(); //take room for queue for to split
        List<BoundsInt> roomsList = new List<BoundsInt>();//result saved and will be returned
        roomsQueue.Enqueue(splitSpace);
        //if we have rooms to split, perform bsp, and split the rooms
        while (roomsQueue.Count > 0)
        {
            var room = roomsQueue.Dequeue();

            if (room.size.y >= minHeight && room.size.x >= minWidth)
            {
                //can be split to multiple room
                if (Random.value < 0.5f)
                {
                    if (room.size.y >= minHeight *2)
                    {
                        SplitHorizontally(minHeight, roomsQueue, room);
                    }
                    else if (room.size.x >= minWidth *2)
                    {
                        SplitVertically(minWidth, roomsQueue, room);
                    }
                    else
                    {
                        roomsList.Add(room);
                    }
                }
                else
                {
                    if (room.size.x >= minWidth *2)
                    {
                        SplitVertically(minWidth, roomsQueue, room);
                    }
                    else if (room.size.y >= minHeight *2)
                    {
                        SplitHorizontally(minHeight, roomsQueue, room);
                    }
                    else
                    {
                        roomsList.Add(room);
                    }
                }
            }
        }
  
        return roomsList;
    }
    private static void SplitVertically(int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var xSplit = Random.Range(1, room.size.x);
        //starting point; defined the two rooms
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z),
            new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));

        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);


    }
   private static void SplitHorizontally(int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var ySplit = Random.Range(1, room.size.y);
        //starting point; defined the two rooms
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z),
            new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }
}
public static class Direct_2D
{
    public static List<Vector2Int> directList = new List<Vector2Int>
    {
        new Vector2Int(0,1), //UP
        new Vector2Int(1,0), //RIGHT
        new Vector2Int(0,-1), //DOWN
        new Vector2Int(-1,0) //LEFT
        
    };

    //corner
    public static List<Vector2Int> diagonaldirectList = new List<Vector2Int>
    {
        new Vector2Int(1,1), //UP-RIGHT
        new Vector2Int(1,-1), //RIGHT-DOWN
        new Vector2Int(-1,-1), //DOWN-LEFT
        new Vector2Int(-1,1) //LEFT-UP
    };

    //both directions to find neighbors or adjacent in eight direction to locate
    //what exact wall type should be placed

    public static List<Vector2Int> eightdirectList = new List<Vector2Int>
    {
        new Vector2Int(0,1), //UP
        new Vector2Int(1,1), //UP-RIGHT
        new Vector2Int(1,0), //RIGHT
        new Vector2Int(1,-1), //RIGHT-DOWN
        new Vector2Int(0, -1), // DOWN
        new Vector2Int(-1, -1), // DOWN-LEFT
        new Vector2Int(-1, 0), //LEFT
        new Vector2Int(-1, 1) //LEFT-UP
    };

    public static Vector2Int randDirect()
    {
        return directList[Random.Range(0, directList.Count)];
    }
}