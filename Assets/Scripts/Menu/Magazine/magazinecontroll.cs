using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazinecontroll : MonoBehaviour
{
    public GameObject back;
	public GameObject Abilities;
	public GameObject Guns;
	public GameObject Other;
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
	public void buttonAbilities()
	{
		Application.LoadLevel("Abilities_magazine");
	}
	public void buttonOther()
	{
		Application.LoadLevel("Other_magazine");
	}
	public void buttonGuns()
	{
		Application.LoadLevel("Guns_magazine");
	}
}
