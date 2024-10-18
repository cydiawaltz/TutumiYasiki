using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] SettingStore setting;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            setting = GameObject.FindWithTag("Setting").GetComponent<SettingStore>();
        }
        catch (UnityException e)
        {
            Debug.LogError("You can (not) advance." + e.Message);
        }
    }
    private void Update()
    {
        if(setting.residueItem == 0)
        {
            setting.isClear = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        var otherTag = other.gameObject.tag;
        if(otherTag == "Player")
        {
            Debug.LogWarning("You can (not) redo.");
        }
        this.gameObject.SetActive(false);
        if(!(setting==null))
        {
            setting.residueItem--;
        }
    }
}
