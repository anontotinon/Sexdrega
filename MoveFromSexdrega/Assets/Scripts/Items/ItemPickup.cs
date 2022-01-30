using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        
        const string unityObj = " (UnityEngine.GameObject)";
        base.Interact();
        var obj = base.gameObject;
        /*
        var parentObj = obj.transform.parent.gameObject;
        if (parentObj.ToString().Equals("Stuff" + unityObj))
        {
          //  Debug.Log("You got some stuff eh");
        }
        */

        if (item.name.Equals("Stoneone"))
        {
            
          //  Debug.Log("Item is Stoneone and typ is " + item.GetType().FullName);

        }

        Inventory.instance.Add(item);
        Destroy(base.gameObject);
        
    }
}
