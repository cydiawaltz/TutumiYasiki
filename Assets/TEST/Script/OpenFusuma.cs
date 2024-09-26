using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFusuma : MonoBehaviour//廃止
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject player;
    [SerializeField] GameObject roomCenter;
    [SerializeField] float distance;
    [SerializeField] float targetDistance;
    [SerializeField] bool isOpen;
    [SerializeField] bool isClose;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        distance = Vector3.Distance(player.transform.position,roomCenter.transform.position);
        if(distance<targetDistance && isOpen)
        {
            anim.SetBool("isOpen", true);
            isOpen = true;
            isClose = false;
        }
        if (distance > targetDistance && isClose)
        { 
            anim.SetBool("isClose", true);
            isClose = true;
            isOpen = false;
        }
        
    }
}
