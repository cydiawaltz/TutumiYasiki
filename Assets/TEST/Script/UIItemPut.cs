using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemPut : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float yDistance;//Y座標の離れ
    Vector3 targetPosition;
    RectTransform thisTransform;
    [SerializeField] float widthRatio;//画面に対する左下(ピポット)からの距離 (縦)
    [SerializeField] float heightRatio;//画面に対する左下(ピポット)からの距離(横)
    [SerializeField] bool isHeight;

    // Start is called before the first frame update
    void Start()
    {
        //targetPosition = target.GetComponent<RectTransform>().position;
        //thisTransform = this.GetComponent<RectTransform>();
        //thisTransform.position = new Vector3(thisTransform.position.x, targetPosition.y + target.GetComponent<RectTransform>().position.y + yDistance, thisTransform.position.z);
        RectTransform rect = this.GetComponent<RectTransform>();
        if (isHeight)
        {
            rect.position = new Vector3(rect.position.x, Screen.height * heightRatio, rect.position.z);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.position = new Vector3(rect.position.x, Screen.height * heightRatio, rect.position.z);
    }
}
