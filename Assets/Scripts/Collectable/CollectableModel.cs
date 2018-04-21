using System;
using UnityEngine;

[Serializable]
public class CollectableModel
{
    public int ID;
    public CollectableType collectableType;
    public GameObject UIBox;

    public CollectableModel(CollectableType ct, GameObject uibox)
    {
        ID = 999;
        collectableType = ct;
        UIBox = uibox;
    }
}
