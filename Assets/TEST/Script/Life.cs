using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour
{
    public int residueLife;//残りのLife
    [SerializeField] GameObject[] rousokus;
    [SerializeField] RectTransform[] rectTransform;
    [SerializeField] GameObject purpleBack;
    [SerializeField] Timer timer;
    [SerializeField] GameObject player;
    bool isStartedPurple = false;
    [SerializeField] float waitSeconds;
    [SerializeField] Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = new RectTransform[rousokus.Length];
        for (int i = 0; i < rousokus.Length; i++)
        {
            rectTransform[i] = rousokus[i].GetComponent<RectTransform>();
        }
        GameObject setting = GameObject.FindWithTag("Setting");
        residueLife = setting.GetComponent<SettingStore>().defaultLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(residueLife > rousokus.Length)
        {
            residueLife = rousokus.Length;
        }
        for(int i = 0;i<rousokus.Length;i++)
        {
            if(i < residueLife)
            {
                rectTransform[i].localScale = Vector3.one;
            }
            else
            {
                rectTransform[i].localScale = Vector3.zero;
            }
        }
        if(residueLife < 2 && !isStartedPurple)
        {
            StartCoroutine("OnLifeFew");
            isStartedPurple = true;
        }
        if(residueLife >= 2)
        {
            StopCoroutine("OnLifeFew");
        }
        if(residueLife == 0)
        {
            player.GetComponent<CharacterController>().enabled = false;
            enemy.isGameOverOrClear = true;
            timer.isGameOver = true;
        }
    }
    IEnumerator OnLifeFew()
    {
        while(true)
        {
            purpleBack.SetActive(!purpleBack.activeSelf);
            yield return new WaitForSeconds(waitSeconds);
        }
    }
}
