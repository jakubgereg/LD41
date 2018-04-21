using UnityEngine;

public class CollectableAttributes : MonoBehaviour
{
    public CollectableType Type = CollectableType.Blue;
    private CollectableModel _model;


    public CollectableModel GenerateModel()
    {
        _model = new CollectableModel(Type);
        return _model;
    }
}
