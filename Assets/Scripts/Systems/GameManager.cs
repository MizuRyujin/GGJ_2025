using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager ManagerInstance { get; private set; }
    public Action OnStartGame;
    public Action OnPauseGame;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            _instance = this;
            ManagerInstance = _instance;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseGame?.Invoke();
        }
    }

}
