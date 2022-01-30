using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    #region Singleton
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("> 1 instance of inventory found. ");
            return;
        }
        instance = this;
    }
    #endregion

    public int gold;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public delegate void OnCurrencyChanged();
    public OnCurrencyChanged onCurrencyChangedCallBack;
    public List<Item> items = new List<Item>();
    public Dictionary<Item, int> itemCounts = new Dictionary<Item, int>();
    public int maxCapacity = 100;
    public int currentCapacity = 0;
    private Item actionItem;
    private string latestAction = "start";

   
    public bool Add(Item item)
    {
        if (currentCapacity + item.weight > maxCapacity)
        {
            Debug.Log("You carry to much, too weak. ");
            return false;
        }

        

        items.Add(item);
        if (itemCounts.ContainsKey(item))
            itemCounts[item] += 1;
        else
            itemCounts.Add(item, 1);
        Debug.Log("+1 " + item.name);

        currentCapacity += item.weight;
        actionItem = item;
        latestAction = "addItem";


        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
        else
            Debug.Log("Wtf");


        Debug.Log("New item: " + actionItem.name);
        return true;
    }

    public void Remove(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            itemCounts[item] -= 1;
            Debug.Log("-1 " + item.name);
            currentCapacity -= item.weight;
        }   
        else
            Debug.LogWarning("Item you're trying to remove does not exist. ");

        latestAction = "delItem";
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

    public void AddGold(int term)
    {
        gold += term;
        latestAction = "addGold";
        if (onCurrencyChangedCallBack != null)
            onCurrencyChangedCallBack.Invoke();
    }

    public void RemoveGold(int term)
    {
        gold -= term;
        latestAction = "removeGold";
        if (onCurrencyChangedCallBack != null)
            onCurrencyChangedCallBack.Invoke();
    }

    public Item GetActionItem()
    {
        return actionItem;
    }

    public string GetCurrentAction()
    {
        return latestAction;
    }
}
