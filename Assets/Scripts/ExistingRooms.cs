using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistingRooms : MonoBehaviour
{
    public List<Vector2> startingCoords;
    public List<GameObject> startingRooms;
    static public List<Vector2> Coords;
    static public List<GameObject> Rooms;
    private void Awake()
    {
        Rooms = new List<GameObject>();
        Rooms.AddRange(startingRooms);
        Coords = new List<Vector2>();
        Coords.AddRange(startingCoords);
    }
}
