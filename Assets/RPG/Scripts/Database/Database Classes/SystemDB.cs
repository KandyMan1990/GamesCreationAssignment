using UnityEditor;
using UnityEngine;

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
        set { _gameTitle = value; EditorUtility.SetDirty(this); }
    }
    public string VersionNumber
    {
        get { return _versionNumber; }
        set { _versionNumber = value; EditorUtility.SetDirty(this); }
    }
    public string CurrencyUnit
    {
        get { return _currencyUnit; }
        set { _currencyUnit = value; EditorUtility.SetDirty(this); }
    }
    public Sprite WindowColour
    {
        get { return _windowColour; }
        set { _windowColour = value; EditorUtility.SetDirty(this); }
    }

    public IntroloopAudio TitleMusic
    {
        get { return _titleMusic; }
        set { _titleMusic = value; EditorUtility.SetDirty(this); }
    }
    public IntroloopAudio BattleMusic
    {
        get { return _battleMusic; }
        set { _battleMusic = value; EditorUtility.SetDirty(this); }
    }
    public IntroloopAudio BossMusic
    {
        get { return _bossMusic; }
        set { _bossMusic = value; EditorUtility.SetDirty(this); }
    }
    public IntroloopAudio VictoryMusic
    {
        get { return _victoryMusic; }
        set { _victoryMusic = value; EditorUtility.SetDirty(this); }
    }
    public IntroloopAudio GameOverMusic
    {
        get { return _gameOverMusic; }
        set { _gameOverMusic = value; EditorUtility.SetDirty(this); }
    }

    public AudioClip CursorSFX
    {
        get { return _cursorSFX; }
        set { _cursorSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip OkSFX
    {
        get { return _okSFX; }
        set { _okSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip CancelSFX
    {
        get { return _cancelSFX; }
        set { _cancelSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip ErrorSFX
    {
        get { return _errorSFX; }
        set { _errorSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip EquipSFX
    {
        get { return _equipSFX; }
        set { _equipSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip SaveSFX
    {
        get { return _saveSFX; }
        set { _saveSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip LoadSFX
    {
        get { return _loadSFX; }
        set { _loadSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip BattleStartSFX
    {
        get { return _battleStartSFX; }
        set { _battleStartSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip BossStartSFX
    {
        get { return _bossStartSFX; }
        set { _bossStartSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip EscapeSFX
    {
        get { return _escapeSFX; }
        set { _escapeSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip PhysicalMissSFX
    {
        get { return _physicalMissSFX; }
        set { _physicalMissSFX = value; EditorUtility.SetDirty(this); }
    }
    public AudioClip MagicMissSFX
    {
        get { return _magicMissSFX; }
        set { _magicMissSFX = value; EditorUtility.SetDirty(this); }
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