using UnityEngine;

public class PlatformPlacer : MonoBehaviour
{

    public delegate void PlatformPlaced();
    public event PlatformPlaced OnPlatformPlacer;

    public bool IsPlaced = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsPlaced = true;
            if (OnPlatformPlacer != null)
                OnPlatformPlacer();
        }
    }
}
