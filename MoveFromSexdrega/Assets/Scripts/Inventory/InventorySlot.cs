using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Text itemCountText;
     public void AddItem(Item newItem)
    {
        Debug.Log("Inside inventory slot add");
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        itemCountText.text = "1";
        itemCountText.enabled = true;
    }

    public void CountUpItem(Item newItem)
    {
        Debug.Log("Inside inventory slot count");
        item = newItem;
        //icon.sprite = item.icon;
        //icon.enabled = true;
        
        int currentCount = System.Int32.Parse(itemCountText.text);
        currentCount += 1;
        itemCountText.text = currentCount.ToString();
        itemCountText.enabled = true;
    }

    public void CountDownItem(Item newItem)
    {
        item = newItem;
        //icon.sprite = item.icon;
        //icon.enabled = true;

        int currentCount = System.Int32.Parse(itemCountText.text);
        currentCount -= 1;
        itemCountText.text = currentCount.ToString();
        itemCountText.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
       
        itemCountText.text = "0";
        itemCountText.enabled = false;
    }

    public Item GetItem()
    {
        return item;
    }
}
