#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public partial class TermsDB : ScriptableObject
{
    public string SetNewGame
    {
        set
        {
            _newGame = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetLoadGame
    {
        set
        {
            _loadGame = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetQuit
    {
        set
        {
            _quit = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetCancel
    {
        set
        {
            _cancel = value;
            EditorUtility.SetDirty(this);
        }
    }

    public string SetWeapons
    {
        set
        {
            _weapons = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetArmours
    {
        set
        {
            _armours = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetItems
    {
        set
        {
            _items = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetEquip
    {
        set
        {
            _equip = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetAutoEquip
    {
        set
        {
            _autoEquip = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetClear
    {
        set
        {
            _clear = value;
            EditorUtility.SetDirty(this);
        }
    }

    public string SetFight
    {
        set
        {
            _fight = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetEscape
    {
        set
        {
            _escape = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetSkills
    {
        set
        {
            _skills = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetStatus
    {
        set
        {
            _status = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetSave
    {
        set
        {
            _save = value;
            EditorUtility.SetDirty(this);
        }
    }

    public string SetWeapon
    {
        set
        {
            _weapon = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetArmour
    {
        set
        {
            _armour = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetAccessory
    {
        set
        {
            _accessory = value;
            EditorUtility.SetDirty(this);
        }
    }

    public string SetLevel
    {
        set
        {
            _level = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetLevelShort
    {
        set
        {
            _levelShort = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetHP
    {
        set
        {
            _hp = value;
            EditorUtility.SetDirty(this);
        }
    }

    public string SetMaxHP
    {
        set
        {
            _maxHP = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetStatPhysicalAttack
    {
        set
        {
            _statPhysicalAttack = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetStatPhysicalDefence
    {
        set
        {
            _statPhysicalDefence = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetStatMagicalAttack
    {
        set
        {
            _statMagicalAttack = value;
            EditorUtility.SetDirty(this);
        }
    }
    public string SetStatMagicalDefence
    {
        set
        {
            _statMagicalDefence = value;
            EditorUtility.SetDirty(this);
        }
    }
}
#endif