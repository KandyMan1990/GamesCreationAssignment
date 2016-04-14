using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private static SystemDB _system_DB;
    private static Terms _terms_DB;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (_instance == null)
                {
                    GameObject gameManager;
                    gameManager = new GameObject("Game Manager");
                    gameManager.AddComponent<GameManager>(); //This point Awake will be called

                    _instance = gameManager.GetComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public SystemDB System_DB
    {
        get
        {
            if(_system_DB == null)
            {
                _system_DB = Resources.Load("Databases/System", typeof(SystemDB)) as SystemDB;
            }

            return _system_DB;
        }
    }
    public Terms Terms_DB
    {
        get
        {
            if (_terms_DB == null)
            {
                _terms_DB = Resources.Load("Databases/Terms", typeof(Terms)) as Terms;
            }

            return _terms_DB;
        }
    }


    void Awake()
    {
        //Check for duplicates in the scene
        Object[] gameManagers = FindObjectsOfType(typeof(GameManager));
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i] != this)
            { //Not conform to singleton pattern
              //Self destruct!
                Destroy(gameObject);
            }
        }

        //DontDestroyOnLoad(gameObject);
        if(SceneManager.GetActiveScene().buildIndex == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }
}