using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image crosshair;
    void Update()
    {
        crosshair.transform.position = Input.mousePosition;
    }
}
