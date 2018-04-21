using System;
using UnityEngine;

[Serializable]
public class CollectableModel
{
    public int ID;
    public GameObject UIBox;

    public CollectableModel(GameObject uibox)
    {
        UIBox = uibox;
    }
}
