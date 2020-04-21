using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazinecontroll : MonoBehaviour
{
    public GameObject back;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void buttonBack()
	{
		Application.LoadLevel("Main Menu");
	}
}
