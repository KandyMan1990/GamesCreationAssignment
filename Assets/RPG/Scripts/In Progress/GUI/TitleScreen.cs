using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
    public Text Title;
    public Button NewGame;
    public Button LoadGame;
    public Button QuitGame;
    public Text Version;
    public CanvasGroup Canvas;
    public Image BlackFadeImage;

    private bool _titleScreenLoaded;
    private bool _quitGame;
    void Awake()
    {
        BlackFadeImage.color = new Color(0, 0, 0, 1);
        _titleScreenLoaded = false;
        _quitGame = false;
        Canvas.interactable = false;
        Canvas.blocksRaycasts = false;
        Canvas.alpha = 0;
    }

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        SceneManager.SetActiveScene(gameObject.scene);

        Title.text = GameManager.Instance.System_DB.GameTitle;
        NewGame.GetComponentInChildren<Text>().text = GameManager.Instance.Terms_DB.NewGame;
        LoadGame.GetComponentInChildren<Text>().text = GameManager.Instance.Terms_DB.LoadGame;
        QuitGame.GetComponentInChildren<Text>().text = GameManager.Instance.Terms_DB.Quit;
        Version.text = "Version " + GameManager.Instance.System_DB.VersionNumber;

        LoadGame.interactable = false;

        IntroloopPlayer.Instance.PlayFade(GameManager.Instance.System_DB.TitleMusic, 4f);

        StartCoroutine(FadeTitleScreen());
    }

    IEnumerator FadeTitleScreen()
    {
        float alpha;
        //starting game
        if (!_titleScreenLoaded)
        {
            alpha = 1f;
            yield return new WaitForSeconds(2f);
            while (Canvas.alpha < 1)
            {
                alpha -= 0.5f * Time.deltaTime;
                BlackFadeImage.color = new Color(0, 0, 0, alpha);
                Canvas.alpha += 0.5f * Time.deltaTime;
                yield return 0;
            }
            BlackFadeImage.color = new Color(0, 0, 0, 0);
            Canvas.alpha = 1;
            Canvas.interactable = true;
            Canvas.blocksRaycasts = true;
            _titleScreenLoaded = true;
        }
        //loading new game or quitting
        else
        {
            Canvas.interactable = false;
            Canvas.blocksRaycasts = false;
            _titleScreenLoaded = false;
            alpha = 0f;
            IntroloopPlayer.Instance.StopFade(2f);
            while (Canvas.alpha > 0)
            {
                alpha += 0.5f * Time.deltaTime;
                BlackFadeImage.color = new Color(0, 0, 0, alpha);
                Canvas.alpha -= 0.5f * Time.deltaTime;
                yield return 0;
            }
            BlackFadeImage.color = new Color(0, 0, 0, 1);
            Canvas.alpha = 0;

            if (!_quitGame)
            {
                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadSceneAsync(nextScene);
            }
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            }
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(FadeTitleScreen());
    }

    public void QuitGameButton()
    {
        _quitGame = true;
        StartCoroutine(FadeTitleScreen());
    }
}