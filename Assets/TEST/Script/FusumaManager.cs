using UnityEngine;

public class FusumaManager : MonoBehaviour//襖にアタッチ
{
    public float distance;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 initial;
    [SerializeField] float targetDistance;//襖が開く距離
    [SerializeField] bool isOpen;//trueなら襖が開いた状態、falseなら閉じた状態
    [SerializeField] Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        initial = gameObject.transform.position;
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance > targetDistance && isOpen)
        {
            anim.SetBool("isOpen", false);
            anim.SetBool("isClose", true);
            isOpen = !isOpen;
        }
        if (distance < targetDistance && !isOpen)
        {
            this.transform.position = new Vector3(initial.x + 0.9f, initial.y, initial.z);
            anim.SetBool("isClose", false);
            anim.SetBool("isOpen", true);
            isOpen = !isOpen;
        }
    }
    void OnOpenEnd()
    {
        this.transform.position = new Vector3(initial.x + 0.9f, initial.y, initial.z);
    }
    void OnCloseEnd()
    {
        this.transform.position = initial;
    }
}

