#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public partial class SystemDB : ScriptableObject
{
    public string SetGameTitle
    {
        set
        {
            _gameTitle = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetVersionNumber
    {
        set
        {
            _versionNumber = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetCurrencyUnit
    {
        set
        {
            _currencyUnit = value;
            EditorUtility.SetDirty(this);
        }
    }
    public int SetExpToLevelUp
    {
        set
        {
            _expToLevelUp = value;
            EditorUtility.SetDirty(this);
        }
    }
    public Sprite SetWindowColour
    {
        set
        {
            _windowColour = value;
            EditorUtility.SetDirty(this);
        }
    }

    public IntroloopAudio SetTitleMusic
    {
        set
        {
            _titleMusic = value;
            EditorUtility.SetDirty(this);
        }
    }
    public IntroloopAudio SetBattleMusic
    {
        set
        {
            _battleMusic = value;
            EditorUtility.SetDirty(this);
        }
    }
    public IntroloopAudio SetBossMusic
    {
        set
        {
            _bossMusic = value;
            EditorUtility.SetDirty(this);
        }
    }
    public IntroloopAudio SetVictoryMusic
    {
        set
        {
            _victoryMusic = value;
            EditorUtility.SetDirty(this);
        }
    }
    public IntroloopAudio SetGameOverMusic
    {
        set
        {
            _gameOverMusic = value;
            EditorUtility.SetDirty(this);
        }
    }

    public AudioClip SetCursorSFX
    {
        set
        {
            _cursorSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetOkSFX
    {
        set
        {
            _okSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetCancelSFX
    {
        set
        {
            _cancelSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetErrorSFX
    {
        set
        {
            _errorSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetEquipSFX
    {
        set
        {
            _equipSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetSaveSFX
    {
        set
        {
            _saveSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetLoadSFX
    {
        set
        {
            _loadSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetNewGameSFX
    {
        set
        {
            _newGameSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetCharacterTurnSFX
    {
        set
        {
            _characterTurnSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetBattleStartSFX
    {
        set
        {
            _battleStartSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetBossStartSFX
    {
        set
        {
            _bossStartSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetEscapeSFX
    {
        set
        {
            _escapeSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetPhysicalMissSFX
    {
        set
        {
            _physicalMissSFX = value;
            EditorUtility.SetDirty(this);
        }
    }
    public AudioClip SetMagicMissSFX
    {
        set
        {
            _magicMissSFX = value;
            EditorUtility.SetDirty(this);
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
#endif