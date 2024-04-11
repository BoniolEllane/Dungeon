using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RWalkDungeon : AbstractDungeon
{
    [SerializeField]
    /*private int iterations = 10;
    [SerializeField]
    public int wLength = 10;
    [SerializeField]
    public bool randIteration = true;*/
    protected DungeonData randWalkParam; //protected so CorridorGen script can access

    protected override void runProcdungeon()
    {
        HashSet<Vector2Int> floorPos = runRand(randWalkParam, startPos);
        tiledungeonvis.Clear();
        tiledungeonvis.paintFloor(floorPos);
        WallGen.MakeWall(floorPos, tiledungeonvis);
    }

    protected HashSet<Vector2Int> runRand(DungeonData parameters, Vector2Int position)
    {
        var recentPos = position;
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < randWalkParam.iterations; i++)
        {
            var path = ProcDungeonAlgo.RWalk(recentPos, randWalkParam.wLength);
            floorPos.UnionWith(path);
            if (randWalkParam.randIteration)
             recentPos = floorPos.ElementAt(Random.Range(0,floorPos.Count));
        }
        return floorPos;
    }
}