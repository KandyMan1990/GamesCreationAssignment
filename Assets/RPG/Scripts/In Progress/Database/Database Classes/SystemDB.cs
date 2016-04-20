using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class SystemDB : ScriptableObject
{
    [HideInInspector]
    [SerializeField]
    string _gameTitle;
    [HideInInspector]
    [SerializeField]
    string _versionNumber;
    [HideInInspector]
    [SerializeField]
    string _currencyUnit;
    [HideInInspector]
    [SerializeField]
    int _expToLevelUp;
    [HideInInspector]
    [SerializeField]
    Sprite _windowColour;

    [HideInInspector]
    [SerializeField]
    IntroloopAudio _titleMusic;
    [HideInInspector]
    [SerializeField]
    IntroloopAudio _battleMusic;
    [HideInInspector]
    [SerializeField]
    IntroloopAudio _bossMusic;
    [HideInInspector]
    [SerializeField]
    IntroloopAudio _victoryMusic;
    [HideInInspector]
    [SerializeField]
    IntroloopAudio _gameOverMusic;

    [HideInInspector]
    [SerializeField]
    AudioClip _cursorSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _okSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _cancelSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _errorSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _equipSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _saveSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _loadSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _newGameSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _characterTurnSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _battleStartSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _bossStartSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _escapeSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _physicalMissSFX;
    [HideInInspector]
    [SerializeField]
    AudioClip _magicMissSFX;

    public string GameTitle
    {
        get { return _gameTitle; }
        set
        {
            _gameTitle = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string VersionNumber
    {
        get { return _versionNumber; }
        set
        {
            _versionNumber = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string CurrencyUnit
    {
        get { return _currencyUnit; }
        set
        {
            _currencyUnit = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public int ExpToLevelUp
    {
        get { return _expToLevelUp; }
        set
        {
            _expToLevelUp = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public Sprite WindowColour
    {
        get { return _windowColour; }
        set
        {
            _windowColour = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    public IntroloopAudio TitleMusic
    {
        get { return _titleMusic; }
        set
        {
            _titleMusic = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public IntroloopAudio BattleMusic
    {
        get { return _battleMusic; }
        set
        {
            _battleMusic = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public IntroloopAudio BossMusic
    {
        get { return _bossMusic; }
        set
        {
            _bossMusic = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public IntroloopAudio VictoryMusic
    {
        get { return _victoryMusic; }
        set
        {
            _victoryMusic = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public IntroloopAudio GameOverMusic
    {
        get { return _gameOverMusic; }
        set
        {
            _gameOverMusic = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    public AudioClip CursorSFX
    {
        get { return _cursorSFX; }
        set
        {
            _cursorSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip OkSFX
    {
        get { return _okSFX; }
        set
        {
            _okSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip CancelSFX
    {
        get { return _cancelSFX; }
        set
        {
            _cancelSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip ErrorSFX
    {
        get { return _errorSFX; }
        set
        {
            _errorSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip EquipSFX
    {
        get { return _equipSFX; }
        set
        {
            _equipSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip SaveSFX
    {
        get { return _saveSFX; }
        set
        {
            _saveSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip LoadSFX
    {
        get { return _loadSFX; }
        set
        {
            _loadSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip NewGameSFX
    {
        get { return _newGameSFX; }
        set
        {
            _newGameSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip CharacterTurnSFX
    {
        get { return _characterTurnSFX; }
        set
        {
            _characterTurnSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip BattleStartSFX
    {
        get { return _battleStartSFX; }
        set
        {
            _battleStartSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip BossStartSFX
    {
        get { return _bossStartSFX; }
        set
        {
            _bossStartSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip EscapeSFX
    {
        get { return _escapeSFX; }
        set
        {
            _escapeSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip PhysicalMissSFX
    {
        get { return _physicalMissSFX; }
        set
        {
            _physicalMissSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public AudioClip MagicMissSFX
    {
        get { return _magicMissSFX; }
        set
        {
            _magicMissSFX = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    /*
    prefabs for vehicles (if any)

    sfx:
    enemy attack (move to attack class)
    enemy collapse (move to enemy class)
    boss collapse (move to boss class)
    recover (move to healing magic class)
    */
}