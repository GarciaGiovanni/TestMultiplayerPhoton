using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string title;
    public Sprite icon;
    public GameObject model;

    private int startCondition = 100;
    private int startAmmo = 50;
    public int maxStack;
    public bool isStackable;

    [TextArea]
    public string description;

    public int get_startingAmmo() { return startAmmo; }
    public int get_startingCondition() { return startCondition; }
    public int get_max() { return maxStack; }
    public bool get_stackable() { return isStackable; }
}
