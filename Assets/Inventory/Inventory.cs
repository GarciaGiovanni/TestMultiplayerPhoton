using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public int maxItems = 10;
    public List<ItemInstance> items = new();
    private GameObject itemModel;
    private Transform player;
    public ItemInstance inHand;

    public bool AddItem(ItemInstance itemToAdd)
    {
        // Finds an empty slot if there is one
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return true;
            }
            else if (items[i].itemType == itemToAdd.itemType && itemToAdd.itemType.get_stackable()) //Checks for stacking, this works for only specific items
            {
                items[i].add_amount(itemToAdd.get_amount());
                return true;
            }
        }
        // Adds a new item if the inventory has space
        if (items.Count < maxItems)
        {
            items.Add(itemToAdd);
            return true;
        }
        return false;
    }

    public bool get_size_left()
    {
        return items.Count == maxItems;
    }
}