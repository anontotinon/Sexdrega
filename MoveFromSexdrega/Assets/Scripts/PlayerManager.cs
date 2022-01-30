using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    void Awake() 
    {
       instance = this; 
    }
    #endregion
    
    public GameObject player;
    public GameObject ui;
    public RawImage miniMap;
    public RawImage bigMap;

    public bool bigMapActive;

    private void Start()
    {
        bigMapActive = false;
        bigMap.enabled = false;
        miniMap.enabled = true;

    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleObj((GameObject)ui);
        }
        ToggleMap();
    }

    private void ToggleObj(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
    }

    private void ToggleMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
            if (bigMapActive)
            {
                bigMap.enabled = false;
                miniMap.enabled = true;
                bigMapActive = false;
            }
            else
            {
                bigMap.enabled = true;
                miniMap.enabled = false;
                bigMapActive = true;
            } 
    }


}
