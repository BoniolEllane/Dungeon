using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class AbstractDungeon : MonoBehaviour
{
    [SerializeField]
    protected TileVisual tiledungeonvis = null;
    [SerializeField]
    protected Vector2Int startPos = Vector2Int.zero;

    public void createDungeon()
    {
        tiledungeonvis.Clear();
        runProcdungeon();
    }
    protected abstract void runProcdungeon();
}
