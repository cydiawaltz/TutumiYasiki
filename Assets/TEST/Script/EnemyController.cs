using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    // 目的地となるGameObjectをセットします。
    public Transform target;
    private NavMeshAgent myAgent;
    [SerializeField] GameObject player;
    [SerializeField] Life lifeManager;
    [SerializeField] float distance;
    [SerializeField] RoomManager roomManager;
    [SerializeField] AudioSource audioSource;
    public float speed;
    public float maxspeed;
    public bool isGameOverOrClear = false;
    [SerializeField] bool isWarpOnShuffle;

    void Start()
    {
        // Nav Mesh Agent を取得します。
        myAgent = GetComponent<NavMeshAgent>();
        //StartCoroutine("corutine", 1);
    }
    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 thisPos = this.transform.position;
        distance = Mathf.Sqrt(Mathf.Pow(playerPos.x - thisPos.x, 2) + Mathf.Pow(playerPos.z - thisPos.z, 2));
        if (distance < 1)
        {
            myAgent.speed = speed;
        }
        else
        {
            myAgent.speed = maxspeed;
        }
        myAgent.SetDestination(target.position);
        transform.LookAt(target);
        if(isGameOverOrClear)
        {
            myAgent.speed = 0f;
        }
        if (distance < 0.5f)
        {
            if(lifeManager.residueLife <= 0)
            {
                speed = 0;
            }
            else
            {
                audioSource.Play();
                Warp();
                lifeManager.residueLife--;
                Debug.Log("You are not alone.");
            }
        }
        if(roomManager.isShuffle && isWarpOnShuffle)
        {
            int shuffleNum = int.Parse(player.transform.parent.transform.parent.name);
            JumpToRoom(shuffleNum);
        }
    }
    void Warp()
    {
        myAgent.Warp(roomManager.center[Random.Range(0, roomManager.center.Length)]);
    }
    void JumpToRoom(int num)
    {
        if(num > 9)
        {
            num = 0;
        }
        myAgent.Warp(roomManager.center[num+2]);
    }
    /*IEnumerator corutine()
    {
        Vector3 direction = this.transform.position - player.transform.position;
        float distance = direction.magnitude; // AとBの距離
        if(!Physics.Raycast(player.transform.position, direction, distance))
        {
            lifeManager.GetComponent<Life>().residueLife--;
        }
        yield return null;
    }*/
}