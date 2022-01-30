using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public string type = "New Type";
    public string description;
    public int value;
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int weight;
}
