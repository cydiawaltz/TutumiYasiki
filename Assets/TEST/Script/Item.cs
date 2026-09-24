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
        //Transform player = transform.Find("Player");
        //Transform camera = transform.Find("CameraHolder");
        //if (!(player == null))
        //{
            //camera.parent = this.transform.parent;
            //player.parent = this.transform.parent;
        //}
        this.gameObject.SetActive(false);
        //this.GetComponent<BoxCollider>().enabled = false;
        //this.GetComponent<MeshRenderer>().enabled = false;
        if(!(setting==null))
        {
            setting.residueItem--;
            setting.OnChangeValue();
        }
        //this.GetComponent<Item>().enabled = false;
    }
}
