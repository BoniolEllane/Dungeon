using UnityEngine;

public class TileMapVisSelector : MonoBehaviour
{
    public GameObject tileMapVis1;
    public GameObject tileMapVis2;
    public GameObject tileMapVis3;

    public RoomFirst roomFirst;

    public void SelectTileMapVis1()
    {
        roomFirst.SetTileMapVis(tileMapVis1.GetComponent<TileVisual>());
    }

    public void SelectTileMapVis2()
    {
        roomFirst.SetTileMapVis(tileMapVis2.GetComponent<TileVisual>());
    }

    public void SelectTileMapVis3()
    {
        roomFirst.SetTileMapVis(tileMapVis3.GetComponent<TileVisual>());
    }
}
