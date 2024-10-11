using UnityEngine;
using System.Collections;

public class SettingStore : MonoBehaviour//Tag名:「Setting」　これは、データを保持する以外の主だった目的は特にない
{
	public string graphicsSetting = "Low";//Low=>PS1程度のグラフィックス、Normal=>PS2程度、High=>普通
	// Use this for initialization
	void Start()
	{
		DontDestroyOnLoad(this);
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}

