using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] ShaffleRoom shaffleRoom;
    public GameObject player;
    public Vector3 playerPosition;//これもY軸抜き
    [SerializeField] GameObject[] rooms;
    [SerializeField] Vector3[] roomPositions;
    public float[] distance;
    public int nearNum;//現在最も近い部屋のIndex
    public int currentNum;//現在いる部屋のIndex
    public bool isShuffled = false;

    void Start()
    {
        distance = new float[rooms.Length];
        roomPositions = new Vector3[shaffleRoom.rooms.Length];
        playerPosition.y = 0;
        nearNum = currentNum;
    }

    void Update()
    {
        playerPosition.x = player.transform.position.x;
        playerPosition.z = player.transform.position.z;
        for (int i = 0; i < shaffleRoom.rooms.Length; i++)
        {
            roomPositions[i].x = rooms[i].transform.position.x;
            roomPositions[i].y = 0;
            roomPositions[i].z = rooms[i].transform.position.z;
            distance[i] = Mathf.Sqrt(Mathf.Pow(playerPosition.x - roomPositions[i].x, 2) + Mathf.Pow(playerPosition.z - roomPositions[i].z, 2));
        }
        nearNum = distance.ToList().IndexOf(distance.Min());
        if(!(nearNum == currentNum))
        {
            shaffleRoom.isShuffle = true;
        }
    }
}
