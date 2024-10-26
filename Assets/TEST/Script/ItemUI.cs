using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image[] items;
    [SerializeField] SettingStore setting;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject uI;
    [SerializeField] GameObject clear;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setting = GameObject.FindWithTag("Setting").GetComponent<SettingStore>();
        uI.SetActive(true);
        clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i<items.Length;i++)
        {
            if (i+1>setting.residueItem)
            {
                items[i].color = new Color(255, 255, 255);
            }
            else
            {
                items[i].color = new Color(0, 0, 0);
            }
        }
        if(setting.residueItem == 0)
        {
            enemy.isGameOverOrClear = true;
            clear.SetActive(true);
            uI.SetActive(false);
        }
    }
}
