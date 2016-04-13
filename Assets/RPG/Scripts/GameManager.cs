using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private static SystemDB _system_DB;
    private static Terms _terms_DB;

    public GameObject Camera;

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

    public static SystemDB System_DB
    {
        get
        {
            if(_system_DB == null)
            {
                _system_DB = (SystemDB)Resources.Load("Databases", typeof(SystemDB));
            }

            return _system_DB;
        }
    }
    public static Terms Terms_DB
    {
        get
        {
            if (_terms_DB == null)
            {
                _terms_DB = (Terms)Resources.Load("Databases", typeof(Terms));
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        Destroy(Camera);
    }
}