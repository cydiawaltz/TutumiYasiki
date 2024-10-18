using UnityEngine;

public class FusumaManager : MonoBehaviour//襖にアタッチ
{
    public double distance;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 current;
    [SerializeField] float targetDistance;//襖が開く距離
    [SerializeField] bool isOpen;//trueなら襖が開いた状態、falseなら閉じた状態
    [SerializeField] Animator anim;
    [SerializeField] bool isOperating;//襖の開閉操作中か

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        targetDistance = 1.5f;
    }

    private void Update()
    {
        //current = transform.TransformPoint(initial);
        current = gameObject.transform.position;
        distance = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - current.x, 2) + Mathf.Pow(player.transform.position.z - current.z, 2));
        if(distance > targetDistance && isOpen&&!isOperating)
        {
            isOperating = true;
            anim.SetBool("isOpen", false);
            anim.SetBool("isClose", true);
            isOpen = !isOpen;
        }
        if (distance < targetDistance && !isOpen&&!isOperating)
        {
            isOperating = true;
            anim.SetBool("isClose", false);
            anim.SetBool("isOpen", true);
            isOpen = !isOpen;
        }
    }
    public void OnAnimationEnd()
    {
        isOperating = false;
    }
    
}

