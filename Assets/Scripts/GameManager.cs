using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //this can be removed just for debug
    public GameModes CurrentMode = GameModes.PLATFORMER;

    public delegate void ChangedGameMode(GameModes gm);


    public event ChangedGameMode OnGameModeChange;

    public Camera PlatformerCamera;
    public Camera BuildingCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (CurrentMode)
            {
                //IF currently game is platformer change it to building
                case GameModes.PLATFORMER:
                    if (OnGameModeChange != null)
                        OnGameModeChange(GameModes.BUILDING);
                    CurrentMode = GameModes.BUILDING;
                    break;
                default:
                    if (OnGameModeChange != null)
                        OnGameModeChange(GameModes.PLATFORMER);
                    CurrentMode = GameModes.PLATFORMER;
                    break;
            }
        }
    }

    private void Start()
    {
        OnGameModeChange += GameManager_OnGameModeChange;
    }

    private void GameManager_OnGameModeChange(GameModes gm)
    {
        if (gm == GameModes.PLATFORMER)
        {
            //if its changed to platformer
            PlatformerCamera.gameObject.SetActive(true);
            BuildingCamera.gameObject.SetActive(false);
            UnFreezeGame();
        }
        else
        {
            PlatformerCamera.gameObject.SetActive(false);
            BuildingCamera.gameObject.SetActive(true);
            FrezzeGame();
        }
    }

    private void FrezzeGame()
    {
        Debug.Log("freeze");
        Time.timeScale = 0f;
    }

    private void UnFreezeGame()
    {
        Time.timeScale = 1f;
    }
}

[Serializable]
public enum GameModes
{
    PLATFORMER,
    BUILDING
}