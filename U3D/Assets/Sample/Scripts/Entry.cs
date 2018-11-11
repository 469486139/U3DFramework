using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour
{
	private void Awake()
	{
		SceneManager.LoadScene("loading");
	}
}
