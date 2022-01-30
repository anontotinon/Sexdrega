using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Text goldView;
    public GameObject hpView;
    public GameObject map;
    public GameObject quickBar;
    public GameObject player;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        //parent = this;
        inventory.onCurrencyChangedCallBack += UpdateCurrency;
        
    }

    private void UpdateCurrency()
    {
        //var goldTextObj = goldView.GetComponentInChildren<Text>();
        //goldView.transform.GetComponentInChildren<Text>();
        goldView.text = inventory.gold.ToString();
    }

}
