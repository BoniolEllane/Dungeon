using UnityEngine;

[CreateAssetMenu(fileName = "New Scene Parameters", menuName = "Scene Parameters")]
public class SceneParameters : ScriptableObject
{
    public int minRoomW = 10;
    public int minRoomH = 10;
    public int dungeonW = 70;
    public int dungeonH = 70;
    public int offset = 3;
}
