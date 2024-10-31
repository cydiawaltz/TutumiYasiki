using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    VideoPlayer video;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.loopPointReached += LoopPointReached;
    }

    void LoopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("NameEntry");
    }
}
