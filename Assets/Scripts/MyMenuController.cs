using UnityEngine;
using UnityEngine.EventSystems;

public class MyMenuController : MonoBehaviour
{
    public int FirstSelectedPosition = 0;

    private EventSystem _eventSystem;
    private int _currentSelected;

    private MenuSelect[] _menuOptions;

    // Use this for initialization
    void Start()
    {
        _menuOptions = GetComponentsInChildren<MenuSelect>();

        if (_menuOptions.Length <= 0)
        {
            Debug.LogError("There are no MenuSelect children Game Objects!");
            return;
        }

        _currentSelected = FirstSelectedPosition;
        _eventSystem = EventSystem.current;
        _eventSystem.SetSelectedGameObject(_menuOptions[_currentSelected].gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_menuOptions.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                var prev = _currentSelected;
                _currentSelected = (_currentSelected + 1) % _menuOptions.Length;
                _eventSystem.SetSelectedGameObject(_menuOptions[_currentSelected].gameObject);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                var prev = _currentSelected;
                _currentSelected = (_currentSelected - 1 + _menuOptions.Length) % _menuOptions.Length;
                _eventSystem.SetSelectedGameObject(_menuOptions[_currentSelected].gameObject);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Select
                Debug.Log(_menuOptions[_currentSelected].name);
            }
        }

    }
}
