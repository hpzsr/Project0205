using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameLayerScript : MonoBehaviour {

	static public GameLayerScript s_instance = null;


	void Start () {
		s_instance = this;

		Cursor.visible = true;						//隐藏鼠标指针
		Cursor.lockState = CursorLockMode.Confined; // 把鼠标锁定到屏幕中间
	}

	void Update()
	{
		
	}

	public void onClick_GM()
	{
	}
}
