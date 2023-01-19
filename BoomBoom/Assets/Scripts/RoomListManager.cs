using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;


public class RoomListManager : MonoBehaviourPunCallbacks
{
    public Transform grid;
    public GameObject roomNamePrefab;


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo room in roomList)
        {
            if (room.RemovedFromList)
            {
                DeleteRoom(room);
            }
            else
            {
                AddRoom(room);
            }
        }

    }

    void AddRoom(RoomInfo room)
    {
        print("Add Room: " + room.Name);
        GameObject obj = Instantiate(roomNamePrefab, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(grid.transform, false);
        obj.GetComponentInChildren<Text>().text = room.Name;
    }

    void DeleteRoom(RoomInfo room)
    {
        print("Delete Room: " + room.Name);

        int roomCounts = grid.childCount;
        for (int i = 0; i < roomCounts; ++i)
        {
            if (grid.GetChild(i).gameObject.GetComponentInChildren<Text>().text == room.Name)
            {
                Destroy(grid.GetChild(i).gameObject);
            }
        }
    }
}
    



