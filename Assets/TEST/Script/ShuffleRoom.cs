using UnityEngine;
using System.Collections;

public class ShaffleRoom : MonoBehaviour
{
    public GameObject[] rooms;
    [SerializeField] Vector3[] initialTransForms;
    public Vector3[] initialTatamiTransForms;
    [SerializeField] int[] roomIndexs;
    [SerializeField] int nearIndex;
    [SerializeField] PlayerPosition playerPosition;
    public bool isShuffle;
    [SerializeField] GameObject cameraObject;
    //public bool isShuffleForFusuma = false;//FusumaManager.csでしか読み取らない => X

	void Start()
	{
        initialTransForms = new Vector3[rooms.Length];
        initialTatamiTransForms = new Vector3[rooms.Length];
        roomIndexs = new int[rooms.Length];
        for(int i = 0;i<rooms.Length;i++)
        {
            initialTransForms[i] = rooms[i].transform.position;
            initialTatamiTransForms[i] = rooms[i].transform.GetChild(0).transform.position;
        }
        for(int i = 0; i < rooms.Length; i++)
        {
            roomIndexs[i] = int.Parse(rooms[i].name);
        }
	}

	void Update()
	{
	    if(isShuffle)
        {
            playerPosition.player.transform.parent = rooms[playerPosition.nearNum].transform;
            cameraObject.transform.parent = rooms[playerPosition.nearNum].transform;
            for (int i = 0; i < rooms.Length; i++)
            {
                roomIndexs[i] = int.Parse(rooms[i].name);
            }
            Shuffle(rooms);
            for(int i = 0;i<rooms.Length;i++)
            {
                rooms[i].transform.position = initialTransForms[i];
            }
            isShuffle = false;
            playerPosition.currentNum = playerPosition.nearNum;
            playerPosition.isShuffled = true;
            playerPosition.playerPosition.x = playerPosition.player.transform.position.x;
            playerPosition.playerPosition.z = playerPosition.player.transform.position.z;
            playerPosition.player.transform.parent = null;
            cameraObject.transform.parent = rooms[playerPosition.nearNum].transform;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            isShuffle = true;
        }
	}
    public void Shuffle(GameObject[] num)//https://naoyu.dev/%E3%80%90unity%E3%80%91%E9%85%8D%E5%88%97%E3%81%AE%E8%A6%81%E7%B4%A0%E3%82%92%E3%82%B7%E3%83%A3%E3%83%83%E3%83%95%E3%83%AB%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95%EF%BC%88%E5%9B%B3%E8%A7%A3%EF%BC%89/
    {
        for (int i = 0; i < num.Length; i++)
        {
            GameObject temp = num[i];
            int randomIndex = Random.Range(0, num.Length);
            num[i] = num[randomIndex];
            num[randomIndex] = temp;
        }
    }
    
}

