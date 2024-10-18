using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // 目的地となるGameObjectをセットします。
    public Transform target;
    private NavMeshAgent myAgent;

    void Start()
    {
        // Nav Mesh Agent を取得します。
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // targetに向かって移動します。
        myAgent.SetDestination(target.position);
        transform.LookAt(target);
    }
}