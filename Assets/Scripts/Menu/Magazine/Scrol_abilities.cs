using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrol_abilities : MonoBehaviour
{
	public GameObject All_abilities;
	public Vector3 screenPoint, offset;
	public float _lockedYPos;
	
	void Update()
	{
		if (All_abilities.transform.position.x > 0)
			All_abilities.transform.position = Vector3.MoveTowards(All_abilities.transform.position, new Vector3 (0f, All_abilities.transform.position.y, All_abilities.transform.position.z), Time.deltaTime * 10f);
		else if (All_abilities.transform.position.x < -20f)
			All_abilities.transform.position = Vector3.MoveTowards(All_abilities.transform.position, new Vector3 (-5f, All_abilities.transform.position.y, All_abilities.transform.position.z), Time.deltaTime * 10f);
	}
	void OnMouseDown()
	{
		_lockedYPos = screenPoint.x;
		offset = All_abilities.transform.position - Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
	}
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		curPosition.y = _lockedYPos;
		All_abilities.transform.position = curPosition;
	}
	void OnMouseUp()
	{
		
	}
}
