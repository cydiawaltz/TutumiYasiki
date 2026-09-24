using System.Threading.Tasks;
using UnityEngine;

public class over : MonoBehaviour
{
    public Animator animator;
    public bool isClear = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isEnd"))
        {
            animator.SetBool("isEnd", false); // òAë±é¿çsñhé~
            OnAnimEnd();
        }
    }
    async void OnAnimEnd()
    {
        if(!isClear)
        {
            while(!Input.GetKeyDown(KeyCode.Return))
            {
                await Task.Delay(1);
            }
            Application.Quit();
        }
    }
}
