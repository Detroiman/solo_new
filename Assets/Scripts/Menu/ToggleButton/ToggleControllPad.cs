using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleControllPad : MonoBehaviour
{
	public Toggle togl;
	public GameObject switchSwipe, switchPad;
	public void buttonSwipePadControll()
	{
		bool swipepadSwitch = togl.isOn;
		if (swipepadSwitch)
		{
			switchSwipe.SetActive(true);
			switchPad.SetActive(false);
		}
		else
		{
			switchSwipe.SetActive(false);
			switchPad.SetActive(true);
		}
	}
}
