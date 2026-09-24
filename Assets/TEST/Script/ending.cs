using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class ending : MonoBehaviour
{
    VideoPlayer video;
    [SerializeField] GameObject end;
    bool flag = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.loopPointReached += LoopPointReached;
        AudioListener.volume = 0f;
        end.SetActive(false);
    }
    private void Update()
    {
        if(video.isPlaying && !flag)
        {
            StartCoroutine(ActiveEnd());
        }
    }
    IEnumerator ActiveEnd()
    {
        yield return new WaitForSeconds(3.0f);
        end.SetActive(true);
    }

    void LoopPointReached(VideoPlayer vp)
    {
        //SceneManager.LoadScene("NameEntry");
        //Application.Quit();
    }
}
