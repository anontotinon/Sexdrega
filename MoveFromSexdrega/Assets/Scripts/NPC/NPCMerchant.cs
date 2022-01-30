using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMerchant : NPCInteraction
{
    public List<Item> products;

    public void Buy(Item item) //from npc
    {

    }
    public void Sell(Item item) //to npc
    {
        if(item != null)
        {
            int price = item.value;
            Inventory.instance.Remove(item);
            Inventory.instance.AddGold(price);
        }
        else
        {
            //Set action text npc "You're trying to sell me air? Idiot."
        }
    }

    public override void Interact()
    {
         
        base.Interact();
        //Spawn UI with list of products.
        //Button to spawn a list of own products. -> button sells. 
        Item test = Inventory.instance.GetActionItem();
        Sell(test);
    }
}
