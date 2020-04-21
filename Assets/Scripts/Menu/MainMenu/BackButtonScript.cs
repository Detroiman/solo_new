using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonScript : MonoBehaviour
{
	public void buttonBack()
	{
		Application.LoadLevel("Main Menu");
	}
}
