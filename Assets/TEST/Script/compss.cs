using UnityEngine;
using System.Linq;

public class compss : MonoBehaviour
{
    [SerializeField] GameObject[] Items;
    [SerializeField] SettingStore setting;
    [SerializeField] float[] distances;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Items = GameObject.FindGameObjectsWithTag("Item");
        distances = new float[Items.Length];
        try
        {
            setting = GameObject.FindWithTag("Setting").GetComponent<SettingStore>();
        }
        catch (UnityException e)
        {
            Debug.LogError("You can (not) advance." + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i= 0; i<Items.Length; i++)
        {
            distances[i] = Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - Items[i].transform.position.x, 2) + Mathf.Pow(gameObject.transform.position.y - Items[i].transform.position.y, 2));
        }
        int minDistance = 0;
        for (int i = 0; i < Items.Length; i++)
        {
            if(distances[i] == distances.Min() )
            {
                minDistance = i; break;
            }
        }
        this.gameObject.transform.LookAt(Items[minDistance].transform);
        if(setting.isChangeValue)
        {
            setting.isChangeValue = false;
            Items = GameObject.FindGameObjectsWithTag("item");
            distances = new float[Items.Length];
        }
    }
}
