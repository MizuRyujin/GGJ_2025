using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttons;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private float _fadeTime;
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _lossMenu;

    public void StartGame() => GameManager.ManagerInstance.StartGame();
    public void ReturnToMainMenu() => GameManager.ManagerInstance.ReloadScene();
    public void ExitGame() => GameManager.ManagerInstance.ExitGame();

    private void Awake()
    {
        foreach (GameObject button in _buttons)
        {
            button.GetComponent<Button>().enabled = false;
            Image image = button.GetComponent<Image>();
            image.color = new Color(image.color.r,
                                    image.color.g, image.color.b, 0f);
        }
        _titleText.color = new Color(_titleText.color.r, _titleText.color.g,
                                        _titleText.color.b, 0f);
    }
    private void Start()
    {
        GameManager.ManagerInstance.OnStartGame += StartFadeOut;
        GameManager.ManagerInstance.OnBubbleBurst += ShowLossScreen;
        GameManager.ManagerInstance.OnPauseGame += ShowPauseMenu;

        StartCoroutine(FadeInMenus(_fadeTime));
    }

    private void StartFadeOut()
    {
        StartCoroutine(FadeOutMenus());
    }

    private void ShowPauseMenu()
    {
        if (_pauseMenu.activeSelf == true)
        {
            _inGameUI.SetActive(true);
            _pauseMenu.SetActive(false);
            return;
        }
        _inGameUI.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    private void ShowLossScreen()
    {
        _inGameUI.SetActive(false);
        _lossMenu.SetActive(true);
    }

    private IEnumerator FadeInMenus(float time)
    {
        float progress = time;
        float alphaVal = 0f;
        yield return new WaitForSeconds(.5f);
        GameManager.ManagerInstance.PlayIntroSound();
        while (progress > 2f)
        {
            alphaVal += Time.deltaTime / progress * 2;

            _titleText.color = new Color(_titleText.color.r,
                                            _titleText.color.g, _titleText.color.b, alphaVal);
            progress -= 1 * Time.deltaTime;

            yield return null;
        }

        alphaVal = 0f;

        while (progress > 0f)
        {
            alphaVal += Time.deltaTime / progress;

            foreach (GameObject button in _buttons)
            {
                Image image = button.GetComponent<Image>();
                image.color = new Color(image.color.r,
                                    image.color.g, image.color.b, alphaVal);
            }
            progress -= 1 * Time.deltaTime;
            yield return null;
        }

        foreach (GameObject button in _buttons)
        {
            button.GetComponent<Button>().enabled = true;
        }
    }

    private IEnumerator FadeOutMenus()
    {
        float progress = 2f;
        float alphaVal = 1f;
        while (progress > 0f)
        {
            alphaVal -= Time.deltaTime / progress;

            _titleText.color = new Color(_titleText.color.r,
                                            _titleText.color.g, _titleText.color.b, alphaVal);

            foreach (GameObject button in _buttons)
            {
                Image image = button.GetComponent<Image>();
                image.color = new Color(image.color.r,
                                    image.color.g, image.color.b, alphaVal);
            }
            progress -= 1 * Time.deltaTime;

            yield return null;
        }

        foreach (GameObject button in _buttons)
        {
            button.GetComponent<Button>().enabled = false;
        }

        _startMenu.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.ManagerInstance.OnStartGame -= StartFadeOut;
        GameManager.ManagerInstance.OnBubbleBurst -= ShowLossScreen;
        GameManager.ManagerInstance.OnPauseGame -= ShowPauseMenu;
    }
}
