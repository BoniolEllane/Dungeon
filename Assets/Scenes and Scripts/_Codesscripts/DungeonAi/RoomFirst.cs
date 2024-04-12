using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomFirst : RWalkDungeon
{
    private TileVisual tileVisual;

    public void SetTileMapVis(TileVisual tileVisual)
    {
        this.tileVisual = tileVisual;
    }

   public SceneParameters dungeonSize;
    private bool randRooms = true; //checking if implements RW or square rooms

    
    protected override void runProcdungeon()
    {
        makeRooms();
    }

    private void makeRooms()
    {
        //call bsp
        var roomList = ProcDungeonAlgo.BSP(new BoundsInt((Vector3Int)startPos, 
            new Vector3Int(dungeonSize.dungeonW, dungeonSize.dungeonH, 0)),  dungeonSize.minRoomW,  dungeonSize.minRoomH);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();

        if (randRooms)
        {
            floor = makeRoomsRand(roomList);

        }
        else
        {
            floor = makeSimpleRooms(roomList);
        }
        
        List<Vector2Int> roomCen = new List<Vector2Int>();//list the center pos of the rooms to be connected

        foreach (var room in roomList)
        {
            roomCen.Add((Vector2Int)Vector3Int.RoundToInt(room.center)); //add vector points to roomCen list
         
        }

        //spawn floortiles for those corridors
        HashSet<Vector2Int> corridors = linkRooms(roomCen);
        floor.UnionWith(corridors);

        tiledungeonvis.paintFloor(floor);
        WallGen.MakeWall(floor, tiledungeonvis);
    }
    private HashSet<Vector2Int> linkRooms(List<Vector2Int> roomCen)
    {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        var recentRoomCen = roomCen[Random.Range(0, roomCen.Count)]; //select rand room from roomCen

        roomCen.Remove(recentRoomCen);

        //find closest room
        while(roomCen.Count > 0)
        {
            Vector2Int closetCen = LocClosePoint(recentRoomCen, roomCen);
            roomCen.Remove(closetCen);//remove to avoid finding it again
            HashSet<Vector2Int> newCor = makeCor(recentRoomCen, closetCen);
            recentRoomCen = closetCen;
            corridors.UnionWith(newCor);
        }
        return corridors;
    }
    private HashSet<Vector2Int> makeCor(Vector2Int recentRoomCen, Vector2Int destination)
    {
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var pos = recentRoomCen;//start pos for corridor
        corridor.Add(pos);

        //travel in each direction until reach the closest point
        while (pos.y != destination.y)
        {
            if(destination.y > pos.y)
            {
                pos += Vector2Int.up;
            }
            else if (destination.y < pos.y)
            {
                pos += Vector2Int.down;
            }
            corridor.Add(pos);
        }
        //reached the y param of the dest
        while (pos.x != destination.x)
        {
            if (destination.x > pos.x)
            {
                pos += Vector2Int.right;
            }
            else if(destination.x < pos.x)
            {
                pos += Vector2Int.left;
            }
            corridor.Add(pos);
        }
        return corridor;
    }

    private Vector2Int LocClosePoint(Vector2Int recentRoomCen, List<Vector2Int> roomCen)
    {
        //loop through each roomCen and find the dist betw. recentRoomCen and roomCen that is checked
        //length < Maxvalue; set the new length as length and the closest as the recentRoomCen
        Vector2Int closest = Vector2Int.zero;
        float dist = float.MaxValue;

        //iterate each roomCen; if dist betw recentRoomCen and iteratedCen is closest, set it as
        //closest point and return it
        foreach (var pos in roomCen)
        {
            //check distance betw recent iterated roomCen and recentRoomCen
            float recentDist = Vector2.Distance(pos, recentRoomCen);
            if (recentDist < dist)
            {
                dist = recentDist;
                closest = pos;
            }
        }
        return closest;
    }

    private HashSet<Vector2Int> makeSimpleRooms(List<BoundsInt> roomList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();

        //floor posiiton, add floorpos to hashshet, loop through room.
        //hashset contains all the floors for all rooms
        foreach (var room in roomList) //looping through each BoundsInt
        {
            for (int col =  dungeonSize.offset; col < room.size.x -  dungeonSize.offset; col++)
            {
                for (int row =  dungeonSize.offset; row < room.size.y -  dungeonSize.offset; row++)
                {
                    Vector2Int pos = (Vector2Int)room.min + new Vector2Int(col, row);
                    floor.Add(pos);
                }
            }
        }
        return floor;
    }
    private HashSet<Vector2Int> makeRoomsRand(List<BoundsInt> roomList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        for (int i =  0; i < roomList.Count; i++)
        {
            var roomBounds = roomList[i];
            //calculate Center point; and generate random pos

            var roomCen = new Vector2Int (Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));
            var roomFloor = runRand(randWalkParam, roomCen);

            foreach (var pos in roomFloor) 
            {
                if(pos.x >= (roomBounds.xMin +  dungeonSize.offset) && pos.x <= (roomBounds.xMax -  dungeonSize.offset) && pos.y >= (roomBounds.yMin -  dungeonSize.offset)
                    && pos.y <= (roomBounds.yMax -  dungeonSize.offset))
                {
                    floor.Add(pos);
                }
            }
        }
        return floor;
    }
}
