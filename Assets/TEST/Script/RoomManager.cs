using UnityEngine;

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
    [SerializeField] float targetDistance;

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
        CalDistance();
        if (isShuffle)
        {
            player.transform.SetParent(defaultRooms[nearRoomIndex].transform.GetChild(0).transform);
            cameraObj.transform.SetParent(defaultRooms[nearRoomIndex].transform.GetChild(0).transform);
            player.GetComponent<CharacterController>().enabled = false;
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
                //currentRooms[i].transform.position = defaultRooms[i].transform.position;
            }
            player.GetComponent<CharacterController>().enabled = true;
            CalDistance();
            currentRoomIndex = nearRoomIndex;
            isShuffle = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            isShuffle = true;
        }
        if (!(currentRoomIndex == nearRoomIndex))
        {
            isShuffle = true;
        }
    }
    void CalDistance()
    {
        // 各部屋の中心からプレイヤーまでの距離を計算
        for (int i = 0; i < defaultRooms.Length; i++)
        {
            distance[i] = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - defaultRooms[i].transform.GetChild(0).transform.position.x, 2) + Mathf.Pow(player.transform.position.z - defaultRooms[i].transform.GetChild(0).transform.position.z, 2));
            if (distance[i]<targetDistance)
            {
                nearRoomIndex = i;
            }
        }
        // 最も近い部屋のインデックスを取得
        //nearRoomIndex = distance.ToList().IndexOf(distance.Min());
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