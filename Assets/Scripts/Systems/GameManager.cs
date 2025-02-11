using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager ManagerInstance { get; private set; }
    [SerializeField] private AudioSource _introSound;
    public Action OnStartGame;
    public Action OnPauseGame;
    public Action OnBubbleBurst;
    public Action<bool> BurstBubble;

    private bool _bubbleBursted = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
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
        if (_bubbleBursted) return;
        PauseGame();
    }

    public void PlayIntroSound() => _introSound.Play();

    public void BubbleBursted(bool burst)
    {
        _bubbleBursted = burst;
        if (!burst)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return;
        }
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        OnStartGame?.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReloadScene()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
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
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            OnPauseGame?.Invoke();
        }
    }
}
