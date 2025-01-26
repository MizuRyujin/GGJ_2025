using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager ManagerInstance { get; private set; }
    public Action OnStartGame;
    public Action OnPauseGame;
    public Action OnBubbleBurst;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
            ManagerInstance = _instance;
            DontDestroyOnLoad(_instance);
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

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
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
