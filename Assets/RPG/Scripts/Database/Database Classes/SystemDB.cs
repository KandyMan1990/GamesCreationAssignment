using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class SystemDB : ScriptableObject
{
    [SerializeField]
    string _gameTitle;
    [SerializeField]
    float _versionNumber;
    [SerializeField]
    string _currencyUnit;
    [SerializeField]
    Sprite _windowColour;
    [SerializeField]
    IntroloopAudio _titleMusic;
    [SerializeField]
    IntroloopAudio _battleMusic;
    [SerializeField]
    IntroloopAudio _bossMusic;
    [SerializeField]
    IntroloopAudio _victoryMusic;
    [SerializeField]
    IntroloopAudio _gameOverMusic;

    public string GameTitle
    {
        get { return _gameTitle; }
        set { _gameTitle = value; }
    }
    public float VersionNumber
    {
        get { return _versionNumber; }
        set { _versionNumber = value; }
    }
    public string CurrencyUnit
    {
        get { return _currencyUnit; }
        set { _currencyUnit = value; }
    }
    public Sprite WindowColour
    {
        get { return _windowColour; }
        set { _windowColour = value; }
    }
    public IntroloopAudio TitleMusic
    {
        get { return _titleMusic; }
        set { _titleMusic = value; }
    }
    public IntroloopAudio BattleMusic
    {
        get { return _battleMusic; }
        set { _battleMusic = value; }
    }
    public IntroloopAudio BossMusic
    {
        get { return _bossMusic; }
        set { _bossMusic = value; }
    }
    public IntroloopAudio VictoryMusic
    {
        get { return _victoryMusic; }
        set { _victoryMusic = value; }
    }
    public IntroloopAudio GameOverMusic
    {
        get { return _gameOverMusic; }
        set { _gameOverMusic = value; }
    }

    /*
    prefabs for vehicles (if any)

    sfx:
    cursor
    ok
    cancel
    error
    equip
    save
    load
    battle start
    boss start
    escape
    enemy attack (move to attack class)
    enemy collapse (move to enemy class)
    boss collapse (move to boss class)
    recover (move to healing magic class)
    physical miss
    magic miss
    */
}