using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
	protected static T _instance;
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				return null;
			}
			return _instance;
		}
	}

	protected virtual void Awake()
	{
		if (!Application.isPlaying)
		{
			return;
		}

		_instance = this as T;
	}
}
 