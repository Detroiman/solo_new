using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChoose : MonoBehaviour
{
	public GameObject Create;
	public GameObject Join;
	public GameObject Back;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
	public void buttonBack()
	{
		Application.LoadLevel("Menu");
	}
	public void buttonJoin()
	{
	}
	public void buttonCreate()
	{
	}
}
