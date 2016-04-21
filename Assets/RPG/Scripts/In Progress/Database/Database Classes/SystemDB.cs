using UnityEngine;

[System.Serializable]
public partial class SystemDB : ScriptableObject
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
    }
    public string VersionNumber
    {
        get { return _versionNumber; }
    }
    public string CurrencyUnit
    {
        get { return _currencyUnit; }
    }
    public int ExpToLevelUp
    {
        get { return _expToLevelUp; }
    }
    public Sprite WindowColour
    {
        get { return _windowColour; }
    }

    public IntroloopAudio TitleMusic
    {
        get { return _titleMusic; }
    }
    public IntroloopAudio BattleMusic
    {
        get { return _battleMusic; }
    }
    public IntroloopAudio BossMusic
    {
        get { return _bossMusic; }
    }
    public IntroloopAudio VictoryMusic
    {
        get { return _victoryMusic; }
    }
    public IntroloopAudio GameOverMusic
    {
        get { return _gameOverMusic; }
    }

    public AudioClip CursorSFX
    {
        get { return _cursorSFX; }
    }
    public AudioClip OkSFX
    {
        get { return _okSFX; }
    }
    public AudioClip CancelSFX
    {
        get { return _cancelSFX; }
    }
    public AudioClip ErrorSFX
    {
        get { return _errorSFX; }
    }
    public AudioClip EquipSFX
    {
        get { return _equipSFX; }
    }
    public AudioClip SaveSFX
    {
        get { return _saveSFX; }
    }
    public AudioClip LoadSFX
    {
        get { return _loadSFX; }
    }
    public AudioClip NewGameSFX
    {
        get { return _newGameSFX; }
    }
    public AudioClip CharacterTurnSFX
    {
        get { return _characterTurnSFX; }
    }
    public AudioClip BattleStartSFX
    {
        get { return _battleStartSFX; }
    }
    public AudioClip BossStartSFX
    {
        get { return _bossStartSFX; }
    }
    public AudioClip EscapeSFX
    {
        get { return _escapeSFX; }
    }
    public AudioClip PhysicalMissSFX
    {
        get { return _physicalMissSFX; }
    }
    public AudioClip MagicMissSFX
    {
        get { return _magicMissSFX; }
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