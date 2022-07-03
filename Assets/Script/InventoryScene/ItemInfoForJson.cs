using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfoForJson 
{
    public int itemId;
    public int addCount;
}

[System.Serializable]
public class ItemInfoForJsons
{
    public List<ItemInfoForJson> itemInfoForJsons = new List<ItemInfoForJson>();
}

