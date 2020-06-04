using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEntity{

	static HeroEntity s_instance = null;

	public List<HeroEntityData> heroList = new List<HeroEntityData>();

	static public HeroEntity getInstance()
	{
		if(s_instance == null)
		{
			s_instance = new HeroEntity();
			s_instance.init();
		}

		return s_instance;
	}

	void init()
	{
		heroList = JsonUtils.loadJsonToList<HeroEntityData>("hero");
	}

	public HeroEntityData getDataById(int id)
	{
		for(int i = 0; i < heroList.Count; i++)
		{
			if(heroList[i].id == id)
			{
				return heroList[i];
			}
		}

		return null;
	}
}
