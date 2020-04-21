using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CONTROLLPAD : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

	Vector2 inputVector;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
	public void OnDrag(PointerEventData eventData)
	{
		inputVector.x = eventData.delta.x;
		inputVector.y = eventData.delta.y;

	}
	public void OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		
		
	}
	public float Horizontal()
	{
		if (inputVector.x != 0) { }

		else
			inputVector.x = 0;
		return inputVector.x;
	}
	public float Vertical()
	{
		if (inputVector.y != 0) { }

		else
			inputVector.y = 0;
		return inputVector.y;
	}
}
