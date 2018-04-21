using UnityEngine;

public class CollectableAttributes : MonoBehaviour
{
    public GameObject UIBox;
    private CollectableModel _model;

    public CollectableModel GenerateModel()
    {
        _model = new CollectableModel(UIBox);
        return _model;
    }
}
