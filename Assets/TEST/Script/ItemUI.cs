using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image[] items;
    [SerializeField] SettingStore setting;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject uI;
    [SerializeField] GameObject clear;
    [SerializeField] CharacterController characterController;
    [SerializeField] Image[] images;//命と宝の文字をfillamountで隠す用
    [SerializeField] GameObject toki;//時だけ別オブジェクトなので
    [SerializeField] Animator animator;//命の下がるアニメ
    [SerializeField] GameObject ending;//エンディングの動画
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setting = GameObject.FindWithTag("Setting").GetComponent<SettingStore>();
        uI.SetActive(true);
        clear.SetActive(false);
        ending.SetActive(false);
        animator.enabled = false;
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
            foreach(Image image in images)
            {
                image.fillAmount = 0.8f;
            }
            enemy.isGameOverOrClear = true;
            characterController.enabled = false;
            animator.enabled = true;
            clear.SetActive(true);
            toki.SetActive(false);
            ending.SetActive(true);
            uI.SetActive(false);
        }
    }
}
