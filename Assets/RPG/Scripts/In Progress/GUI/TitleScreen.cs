using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Text Title;
    public Button NewGame;
    public Button LoadGame;
    public Button QuitGame;
    public Text Version;

    // Use this for initialization
    void Start()
    {
        SceneManager.SetActiveScene(gameObject.scene);

        Title.text = GameManager.Instance.System_DB.GameTitle;
        NewGame.GetComponentInChildren<Text>().text = GameManager.Instance.Terms_DB.NewGame;
        LoadGame.GetComponentInChildren<Text>().text = GameManager.Instance.Terms_DB.LoadGame;
        QuitGame.GetComponentInChildren<Text>().text = GameManager.Instance.Terms_DB.Quit;
        Version.text = "Version " + GameManager.Instance.System_DB.VersionNumber;

        LoadGame.interactable = false;

        IntroloopPlayer.Instance.Play(GameManager.Instance.System_DB.TitleMusic);
    }

    public void NewGameButton()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(nextScene);
    }

}