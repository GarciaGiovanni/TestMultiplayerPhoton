using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    private int condition;
    private int ammo;
    private int maxQuantity;
    private int dmg;
    public int currentAmount;
    public ItemInstance(ItemData itemData)
    {
        this.itemType = itemData;
        currentAmount = 1;
        condition = itemData.get_startingCondition();
        ammo = itemData.get_startingAmmo();
        maxQuantity = itemData.get_max();
        currentAmount = 1;
        dmg = itemData.get_dmg();
    }

    public void add_amount(int i)
    {
        currentAmount += i;
    }

    public void set_amount(int i)
    {
        currentAmount = i;
    }

    public int get_amount()
    {
        return currentAmount;
    }

    public int get_dmg()
    {
        return dmg;
    }

}
