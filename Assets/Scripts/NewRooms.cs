using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewRooms : MonoBehaviour
{
    public bool moreSpace;
    public bool doorLeft, doorRight, doorUp, doorDown;
    public Vector2 coords;
    public GameObject OdoorLeft, OdoorRight, OdoorUp, OdoorDown;
    public GameObject junk;
    void Start()
    {
    }

    void Update()
    {
        OdoorLeft.SetActive(doorLeft);
        OdoorRight.SetActive(doorRight);
        OdoorUp.SetActive(doorUp);
        OdoorDown.SetActive(doorDown);
        if (moreSpace)
        {
            moreSpace = false;
            doorLeft = doorRight = doorUp = doorDown = false;
            bool IsUpperRoom = ExistingRooms.Coords.Contains(new Vector2(coords.x, coords.y + 1));
            bool IsDownerRoom = ExistingRooms.Coords.Contains(new Vector2(coords.x, coords.y - 1));
            bool IsRighterRoom = ExistingRooms.Coords.Contains(new Vector2(coords.x + 1, coords.y));
            bool IsLefterRoom = ExistingRooms.Coords.Contains(new Vector2(coords.x - 1, coords.y));
            if (!IsUpperRoom)
            {
                ScoreSystem.score += 100;
                NewRooms Room = GameObject.Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + 9, 0), new Quaternion()).GetComponent<NewRooms>();
                Room.doorLeft = Room.doorUp = Room.doorRight = true;
                Room.doorDown = false;
                Room.coords = new Vector2(coords.x, coords.y + 1);
                ExistingRooms.Coords.Add(new Vector2(coords.x, coords.y + 1));
                ExistingRooms.Rooms.Add(Room.gameObject);
                JunkGenerator(Room.coords);
            }
            else
            {
                Predicate<Vector2> test = FindIndUp;
                NewRooms coor = ExistingRooms.Rooms[ExistingRooms.Coords.FindIndex(test)].GetComponent<NewRooms>();
                coor.doorDown = false;
            }
            if (!IsDownerRoom)
            {
                ScoreSystem.score += 100;
                NewRooms Room = GameObject.Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y - 9, 0), new Quaternion()).GetComponent<NewRooms>();
                Room.doorLeft = Room.doorDown = Room.doorRight = true;
                Room.doorUp = false;
                Room.coords = new Vector2(coords.x, coords.y - 1);
                ExistingRooms.Coords.Add(new Vector2(coords.x, coords.y - 1));
                ExistingRooms.Rooms.Add(Room.gameObject);
                JunkGenerator(Room.coords);
            }
            else
            {
                Predicate<Vector2> test = FindIndDown;
                NewRooms coor = ExistingRooms.Rooms[ExistingRooms.Coords.FindIndex(test)].GetComponent<NewRooms>();
                coor.doorUp = false;
            }
            if (!IsRighterRoom)
            {
                ScoreSystem.score += 100;
                NewRooms Room = GameObject.Instantiate(gameObject, new Vector3(transform.position.x + 15, transform.position.y, 0), new Quaternion()).GetComponent<NewRooms>();
                Room.doorDown = Room.doorUp = Room.doorRight = true;
                Room.doorLeft = false;
                Room.coords = new Vector2(coords.x + 1, coords.y);
                ExistingRooms.Coords.Add(new Vector2(coords.x + 1, coords.y));
                ExistingRooms.Rooms.Add(Room.gameObject);
                JunkGenerator(Room.coords);
            }
            else
            {
                Predicate<Vector2> test = FindIndRight;
                NewRooms coor = ExistingRooms.Rooms[ExistingRooms.Coords.FindIndex(test)].GetComponent<NewRooms>();
                coor.doorLeft = false;
            }
            if (!IsLefterRoom)
            {
                ScoreSystem.score += 100;
                NewRooms Room = GameObject.Instantiate(gameObject, new Vector3(transform.position.x - 15, transform.position.y, 0), new Quaternion()).GetComponent<NewRooms>();
                Room.doorLeft = Room.doorUp = Room.doorDown = true;
                Room.doorRight = false;
                Room.coords = new Vector2(coords.x - 1, coords.y);
                ExistingRooms.Coords.Add(new Vector2(coords.x - 1, coords.y));
                ExistingRooms.Rooms.Add(Room.gameObject);
                JunkGenerator(Room.coords);
            }
            else
            {
                Predicate<Vector2> test = FindIndLeft;
                NewRooms coor = ExistingRooms.Rooms[ExistingRooms.Coords.FindIndex(test)].GetComponent<NewRooms>();
                coor.doorRight = false;
            }
        }
    }
    private bool FindIndUp(Vector2 obj)
    {
        return ((obj.x == coords.x) && (obj.y - 1 == coords.y));
    }
    private bool FindIndDown(Vector2 obj)
    {
        return ((obj.x == coords.x) && (obj.y + 1 == coords.y));
    }
    private bool FindIndRight(Vector2 obj)
    {
        return ((obj.x - 1 == coords.x) && (obj.y == coords.y));
    }
    private bool FindIndLeft(Vector2 obj)
    {
        return ((obj.x + 1 == coords.x) && (obj.y == coords.y));
    }
    void JunkGenerator(Vector2 junkRoom)
    {
        for (int i = 0; i != 10; i++)
        {
            Vector2 room = new Vector2(junkRoom.x * 15, junkRoom.y * 9);
            Vector2 cd = new Vector2(UnityEngine.Random.Range(room.x - 6f, room.x + 6f), UnityEngine.Random.Range(room.y - 3f, room.y + 3f));
            GameObject.Instantiate(junk, cd, new Quaternion());
        }
    }
}
