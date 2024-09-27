using UnityEngine;
using System.Collections;

public class ShaffleRoom : MonoBehaviour
{
    [SerializeField] GameObject[] rooms;
    [SerializeField] Vector3[] initialTransForms;
    public bool isShuffle;
    // Use this for initialization
	void Start()
	{
        initialTransForms = new Vector3[rooms.Length];
        for(int i = 0;i<rooms.Length;i++)
        {
            initialTransForms[i] = rooms[i].transform.position;
        }
	}

	// Update is called once per frame
	void Update()
	{
	    if(isShuffle)
        {
            Shuffle(rooms);
            for(int i = 0;i<rooms.Length;i++)
            {
                rooms[i].transform.position = initialTransForms[i];
            }
            isShuffle = false;
        }
	}
    void Shuffle(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            //（説明１）現在の要素を預けておく
            GameObject temp = num[i];
            //（説明２）入れ替える先をランダムに選ぶ
            int randomIndex = Random.Range(0, num.Length);
            //（説明３）現在の要素に上書き
            num[i] = num[randomIndex];
            //（説明４）入れ替え元に預けておいた要素を与える
            num[randomIndex] = temp;
        }
    }
}

