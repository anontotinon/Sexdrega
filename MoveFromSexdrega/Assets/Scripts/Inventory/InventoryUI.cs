using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject parent;
    Inventory inventory;
    InventorySlot[] slots;
    public Text goldPanel;
    void Start()
    {
        inventory = Inventory.instance;
        //parent = this;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = this.GetComponentsInChildren<InventorySlot>();
    }

 

    void UpdateUI()
    {
        Debug.Log("In update UI");
        //Iterate the ui slots and check if picked up item name exists in any slot. 
        // If so, only update the text.
        Debug.Log(inventory.GetCurrentAction());
        if (inventory.GetCurrentAction().Equals("addItem"))
        {
            int invLen = inventory.items.Count - 1;
            //var itemsCounts = inventory.itemCounts;
            Debug.Log("New item in ui: " + inventory.GetActionItem().name);
            if (inventory.GetActionItem() != null) //remove this
            {
                string newestItemName = inventory.GetActionItem().name;
                for (int i = 0; i < slots.Length; i++)
                {
                    var curItem = slots[i].GetItem();
                    if (curItem != null)
                        if (curItem.name.Equals(newestItemName))
                        {
                            slots[i].CountUpItem(inventory.items[invLen]);
                            //update text slot[i]
                            return;
                        }
                }
            }

            int indx = GetNextFreeSpaceIndex(slots);
            slots[indx].AddItem(inventory.items[invLen]);
        }


        //remove item
        if (inventory.GetCurrentAction().Equals("delItem"))
        {
            
            Item actionItem = inventory.GetActionItem();
            for(int i = 0; i<slots.Length; i++)
            {
                Item itemInSlot = slots[i].GetItem();
                if (itemInSlot.name.Equals(actionItem.name))
                {
                    if (!slots[i].itemCountText.Equals("1"))
                    {
                        slots[i].CountDownItem(itemInSlot);
                        return;
                    }
                    else
                    {
                        slots[i].ClearSlot();
                        return;
                    }
                }
            }
        }
        /*
        if (inventory.GetCurrentAction().Equals("addGold"))
        {
            goldPanel.text = inventory.gold.ToString();
        }

        if (inventory.GetCurrentAction().Equals("removeGold"))
        {
            goldPanel.text = inventory.gold.ToString();
        }
        */
    }

    private int GetNextFreeSpaceIndex(InventorySlot[] slots)
    {
        for(int i = 0; i<slots.Length; i++)
        {
            if (slots[i].GetItem() == null)
                return i;
        }
        return -1; //No space.
    }

   
}
