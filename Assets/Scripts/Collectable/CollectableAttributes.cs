using UnityEngine;

public class CollectableAttributes : MonoBehaviour
{
    public CollectableType Type = CollectableType.Blue;
    public GameObject UIBox;

    private CollectableModel _model;


    public CollectableModel GenerateModel()
    {
        _model = new CollectableModel(Type, UIBox);
        return _model;
    }
}
