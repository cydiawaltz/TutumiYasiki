using UnityEngine;

public class FusumaManager : MonoBehaviour//襖にアタッチ
{
    public double distance;
    [SerializeField] GameObject player;
    [SerializeField] float initialX;
    [SerializeField] float initialZ;
    [SerializeField] float targetDistance;//襖が開く距離
    [SerializeField] bool isOpen;//trueなら襖が開いた状態、falseなら閉じた状態
    [SerializeField] Animator anim;
    [SerializeField] ShaffleRoom shaffleRoom;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        initialX = gameObject.transform.position.x;
        initialZ = gameObject.transform.position.z;
        //targetDistance = 2.6f;
    }

    private void Update()
    {
        if (shaffleRoom.isShuffle)
        {
            initialX = gameObject.transform.position.x;
            initialZ = gameObject.transform.position.z;
        }
        //distance = Vector3.Distance(player.transform.position, initial);
        distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - initialX, 2) + Mathf.Pow(player.transform.position.z - initialZ, 2));
        if(distance > targetDistance && isOpen)
        {
            anim.SetBool("isOpen", false);
            anim.SetBool("isClose", true);
            isOpen = !isOpen;
        }
        if (distance < targetDistance && !isOpen)
        {
            //this.transform.position = new Vector3(initial.x + 0.9f, initial.y, initial.z);
            anim.SetBool("isClose", false);
            anim.SetBool("isOpen", true);
            isOpen = !isOpen;
        }
    }
    /*void OnOpenEnd()
    {
        this.transform.position = new Vector3(initial.x + 0.9f, initial.y, initial.z);
    }
    void OnCloseEnd()
    {
        this.transform.position = initial;
    }*/
}

