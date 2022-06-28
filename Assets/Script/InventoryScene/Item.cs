using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Item
{
    public ItemType ItemType;
    public string Name;
    public string Desdescription;
    public int Count;
    public Sprite ItemImage;
}
public enum ItemType
{
    DOGGUM = 1,
    BEAK,
    TEETH,
    BEARD,
    HAIRBALL
}