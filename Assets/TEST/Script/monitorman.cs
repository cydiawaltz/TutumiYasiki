
using UnityEngine;

public class monitorman : MonoBehaviour
{
    [SerializeField] Camera MainCam;
    [SerializeField] RuntimeAnimatorController[] controller;//[0]idle [1]walk
    [SerializeField] Animator animator;
    [SerializeField] State state;
    enum State
    {
        idle,walk
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCam.cullingMask = (1 << 1) + (1 << 2) + (1 << 3) + (1 << 4) + (1 << 5) + (1 << 6) + (1 << 7) + (1 << 9);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if(state == State.idle)
            {
                state = State.walk;
                animator.runtimeAnimatorController = controller[1];
            }
        }
        else
        {
            if(state == State.walk)
            {
                state = State.idle;
                animator.runtimeAnimatorController = controller[0];
            }
        }
    }
}
 