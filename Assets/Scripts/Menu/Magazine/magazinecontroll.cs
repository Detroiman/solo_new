using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazinecontroll : MonoBehaviour
{
    public GameObject back;
	public GameObject Abilities;
	public GameObject Guns;
	public GameObject Other;
	public GameObject RawImGuns;
	public GameObject Exit_guns;
	public GameObject RawImAbilities;
	public GameObject Exit_abilities;
	public GameObject RawImOther;
	public GameObject Exit_other;
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
		RawImAbilities.SetActive(true);
	}
	public void buttonExit_abilities()
	{
		RawImAbilities.SetActive(false);
	}
	public void buttonOther()
	{
		RawImOther.SetActive(true);
	}
	public void buttonExit_other()
	{
		RawImOther.SetActive(false);
	}
	public void buttonGuns()
	{
		RawImGuns.SetActive (true);
	}
	public void buttonExit_guns()
	{
		RawImGuns.SetActive (false);
	}
}
