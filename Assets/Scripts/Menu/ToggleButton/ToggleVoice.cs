using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVoice : MonoBehaviour
{
	public Toggle togl;
	public GameObject switchOn, switchOff;
	public void buttonVoicePausetoggle()
	{
		Debug.Log(1);
		bool onoffSwitch = togl.isOn;
		if (onoffSwitch)
		{
			switchOn.SetActive(true);
			switchOff.SetActive(false);
			Debug.Log(1);
		}
		else
		{
			switchOn.SetActive(false);
			switchOff.SetActive(true);
		}
	}
}
