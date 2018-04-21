using System;

[Serializable]
public class CollectableModel
{
    public int ID;
    public CollectableType collectableType;

    public CollectableModel(CollectableType ct)
    {
        ID = 999;
        collectableType = ct;
    }
}
