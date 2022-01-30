using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    #region Singleton
    public static InteractionManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    public List<Interactable> interactableObjects;
   
}
