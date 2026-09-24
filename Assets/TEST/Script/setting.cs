using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class SettingStore : MonoBehaviour//Tag名:「Setting」　これは、データを保持する以外の主だった目的は特にない
{
	public string graphicsSetting;//Low=>PS1程度のグラフィックス、Normal=>PS2程度、High=>普通
	public int residueItem;//アイテムの残りの数
	public bool isClear = false;
	public int defaultLife;//Lifeの元の値
	public bool isChangeValue = false;//外部からいじる用
	public float residueTime;
	// Use this for initialization
	void Start()
	{
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.P))
		{
			residueItem = 0;
        }
	}
	public void OnChangeValue()
	{
		isChangeValue = true;
	}
	void OnSceneLoaded(Scene loadedScene,LoadSceneMode loadSceneMode)
	{
		residueItem = GameObject.FindGameObjectsWithTag("Item").Length;
    }
}

