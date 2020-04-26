using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRawImBuy : MonoBehaviour
{
    public GameObject All_elem;
	public GameObject Exit_All_elem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void buttonAll_elem()
	{
		All_elem.SetActive(true);
	}
	public void buttonExit_All_elem()
	{
		All_elem.SetActive (false);
	}
}
