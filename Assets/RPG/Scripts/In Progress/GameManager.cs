﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private static SystemDB _system_DB;
    private static TermsDB _terms_DB;
    private static WeaponDB _weapons_DB;
    private static ElementDB _elements_DB;
    private static CharacterDB _characters_DB;
    private static ArmourDB _armours_DB;

    private static Vector3 _playerPosition = Vector3.zero;
    private static Vector3 _playerRotation = Vector3.zero;
    private static string _scene = string.Empty;

    private bool _questComplete = false;

    private AudioSource _audio;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (_instance == null)
                {
                    GameObject templatePrefab = Resources.Load("GameManager") as GameObject;
                    GameObject gameManager;
                    if (templatePrefab != null)
                    {
                        gameManager = Instantiate(templatePrefab);
                        gameManager.name = "GameManager";
                    }
                    else
                    {
                        gameManager = new GameObject("Game Manager");
                        gameManager.AddComponent<GameManager>(); //This point Awake will be called
                    }

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
            if (_system_DB == null)
            {
                _system_DB = Resources.Load("Databases/System", typeof(SystemDB)) as SystemDB;
            }

            return _system_DB;
        }
    }
    public TermsDB Terms_DB
    {
        get
        {
            if (_terms_DB == null)
            {
                _terms_DB = Resources.Load("Databases/Terms", typeof(TermsDB)) as TermsDB;
            }

            return _terms_DB;
        }
    }
    public WeaponDB Weapon_DB
    {
        get
        {
            if (_weapons_DB == null)
            {
                _weapons_DB = Resources.Load("Databases/Weapons", typeof(WeaponDB)) as WeaponDB;
            }

            return _weapons_DB;
        }
    }
    public ElementDB Elements_DB
    {
        get
        {
            if (_elements_DB == null)
            {
                _elements_DB = Resources.Load("Databases/Elements", typeof(ElementDB)) as ElementDB;
            }

            return _elements_DB;
        }
    }
    public CharacterDB Characters_DB
    {
        get
        {
            if (_characters_DB == null)
            {
                _characters_DB = Resources.Load("Databases/Characters", typeof(CharacterDB)) as CharacterDB;
            }

            return _characters_DB;
        }
    }
    public ArmourDB Armours_DB
    {
        get
        {
            if (_armours_DB == null)
            {
                _armours_DB = Resources.Load("Databases/Armours", typeof(ArmourDB)) as ArmourDB;
            }

            return _armours_DB;
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

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public Vector3 GetPlayerPosition
    {
        get
        {
            return _playerPosition; ;
        }
    }
    public Vector3 GetPlayerRotation
    {
        get
        {
            return _playerRotation;
        }
    }
    public void SetPlayerPosition(Vector3 position, Vector3 rotation)
    {
        _playerPosition = position;
        _playerRotation = rotation;
    }
    public string GetSceneName
    {
        get
        {
            return _scene;
        }
    }
    public void SetSceneName(string name)
    {
        _scene = name;
    }
    public void ClearPlayerPositionRotationAndScene()
    {
        _playerPosition = Vector3.zero;
        _playerRotation = Vector3.zero;
        _scene = string.Empty;

    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            _audio.PlayOneShot(clip);
    }

    public bool IsQuestComplete
    {
        get { return _questComplete; }
    }

    public void CompleteQuest()
    {
        _questComplete = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}