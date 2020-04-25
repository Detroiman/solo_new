using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Canvas1: MonoBehaviourPun
{

    Camera cam;
    Canvas Uicanvas;
    string camtag;
    bool find = false;
    
  
    void Update()
    {
        if (!find)
        {
            try
            {
                camtag = PhotonNetwork.NickName + "Camera";
                Debug.Log(camtag);
                cam = GameObject.Find(camtag).GetComponent<Camera>();
                Uicanvas = gameObject.GetComponent<Canvas>();
                Uicanvas.worldCamera = cam;
                find = true;
            }
            catch { }
        }
    }
}
