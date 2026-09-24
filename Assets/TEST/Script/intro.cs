using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class intro : MonoBehaviour
{
    public VideoPlayer vp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vp.loopPointReached += LoopPointReached;
        Screen.SetResolution(1200, 800, false);
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Stage");
        }

    }
    // Update is called once per frame
    void LoopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("Stage");
    }
}
