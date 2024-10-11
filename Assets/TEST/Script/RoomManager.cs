using UnityEngine;
using System.Linq;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] defaultRooms;//0~Maxまでを規則正しく並べる
    [SerializeField] GameObject[] currentRooms;//番号はdefaultNumの座標に対応
    [SerializeField] GameObject player;
    [SerializeField] GameObject cameraObj;
    [SerializeField] Vector3[] center;//部屋の中心（畳）の座標を取得する
    [SerializeField] float[] distance;//部屋の中心(=畳の中心)からプレイヤーへの距離
    [SerializeField] bool isShuffle = false;
    [SerializeField] int currentRoomIndex;//今いる部屋
    [SerializeField] int nearRoomIndex;//現在最も近い部屋

    // シャッフル前の最も近い部屋のインデックス
    private int preShuffleNearRoomIndex;

    void Start()
    {
        currentRooms = new GameObject[defaultRooms.Length];
        currentRooms = defaultRooms.Clone() as GameObject[];
        center = new Vector3[defaultRooms.Length];
        distance = new float[defaultRooms.Length];
        for (int i = 0; i < defaultRooms.Length; i++)
        {
            center[i] = defaultRooms[i].transform.GetChild(0).transform.position;
        }
    }

    void Update()
    {
        // 各部屋の中心からプレイヤーまでの距離を計算
        for (int i = 0; i < defaultRooms.Length; i++)
        {
            distance[i] = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - center[i].x, 2) + Mathf.Pow(player.transform.position.z - center[i].z, 2));
        }
        // 最も近い部屋のインデックスを取得
        nearRoomIndex = distance.ToList().IndexOf(distance.Min());

        if (isShuffle)
        {
            player.GetComponent<CharacterController>().enabled = false;
            // シャッフル前の最も近い部屋のインデックスを記録
            preShuffleNearRoomIndex = nearRoomIndex;
            // プレイヤーのローカル座標を保存
            Vector3 localPosition = player.transform.InverseTransformPoint(transform.position);
            // 現在の部屋の位置を保存
            Vector3[] a = new Vector3[currentRooms.Length];
            for (int i = 0; i < currentRooms.Length; i++)
            {
                a[i] = currentRooms[i].transform.position;
            }
            // 部屋をシャッフル
            Shuffle();
            // シャッフル後に部屋を元の位置に再配置
            for (int i = 0; i < currentRooms.Length; i++)
            {
                currentRooms[i].transform.position = a[i];
            }
            // プレイヤーをシャッフル前に最も近かった部屋に追従させる
            player.transform.position = defaultRooms[preShuffleNearRoomIndex].transform.GetChild(0).transform.position;
            // プレイヤーの位置を復元
            transform.localPosition = localPosition;
            // プレイヤーを再び動けるようにする
            player.GetComponent<CharacterController>().enabled = true;
            currentRoomIndex = nearRoomIndex;
            isShuffle = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            isShuffle = true;
        }
        if (!(currentRoomIndex == nearRoomIndex))
        {
            player.transform.SetParent(defaultRooms[nearRoomIndex].transform.GetChild(0).transform);
            cameraObj.transform.SetParent(defaultRooms[nearRoomIndex].transform.GetChild(0).transform);
            isShuffle = true;
        }
    }

    // 部屋をシャッフルするメソッド
    void Shuffle()
    {
        for (int i = 0; i < currentRooms.Length; i++)
        {
            GameObject temp = currentRooms[i];
            int randomIndex = Random.Range(0, currentRooms.Length);
            currentRooms[i] = currentRooms[randomIndex];
            currentRooms[randomIndex] = temp;
        }
    }
}