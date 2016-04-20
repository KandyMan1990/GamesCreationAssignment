﻿using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class Terms : ScriptableObject
{
    //title screen
    [HideInInspector]
    [SerializeField]
    string _newGame;
    [HideInInspector]
    [SerializeField]
    string _loadGame;
    [HideInInspector]
    [SerializeField]
    string _quit;
    [HideInInspector]
    [SerializeField]
    string _cancel;

    public string NewGame
    {
        get { return _newGame; }
        set
        {
            _newGame = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string LoadGame
    {
        get { return _loadGame; }
        set
        {
            _loadGame = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Quit
    {
        get { return _quit; }
        set
        {
            _quit = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Cancel
    {
        get { return _cancel; }
        set
        {
            _cancel = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    //menus
    [HideInInspector]
    [SerializeField]
    string _weapons;
    [HideInInspector]
    [SerializeField]
    string _armours;
    [HideInInspector]
    [SerializeField]
    string _items;
    [HideInInspector]
    [SerializeField]
    string _equip;
    [HideInInspector]
    [SerializeField]
    string _autoEquip;
    [HideInInspector]
    [SerializeField]
    string _clear;

    public string Weapons
    {
        get { return _weapons; }
        set
        {
            _weapons = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Armours
    {
        get { return _armours; }
        set
        {
            _armours = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Items
    {
        get { return _items; }
        set
        {
            _items = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Equip
    {
        get { return _equip; }
        set
        {
            _equip = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string AutoEquip
    {
        get { return _autoEquip; }
        set
        {
            _autoEquip = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Clear
    {
        get { return _clear; }
        set
        {
            _clear = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    //commands
    [HideInInspector]
    [SerializeField]
    string _fight;
    [HideInInspector]
    [SerializeField]
    string _escape;
    [HideInInspector]
    [SerializeField]
    string _skills;
    [HideInInspector]
    [SerializeField]
    string _status;
    [HideInInspector]
    [SerializeField]
    string _save;

    public string Fight
    {
        get { return _fight; }
        set
        {
            _fight = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Escape
    {
        get { return _escape; }
        set
        {
            _escape = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Skills
    {
        get { return _skills; }
        set
        {
            _skills = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Status
    {
        get { return _status; }
        set
        {
            _status = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Save
    {
        get { return _save; }
        set
        {
            _save = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    //equipment types
    [HideInInspector]
    [SerializeField]
    string _weapon;
    [HideInInspector]
    [SerializeField]
    string _armour;
    [HideInInspector]
    [SerializeField]
    string _accessory;

    public string Weapon
    {
        get { return _weapon; }
        set
        {
            _weapon = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Armour
    {
        get { return _armour; }
        set
        {
            _armour = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string Accessory
    {
        get { return _accessory; }
        set
        {
            _accessory = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    //basic status
    [HideInInspector]
    [SerializeField]
    string _level;
    [HideInInspector]
    [SerializeField]
    string _levelShort;
    [HideInInspector]
    [SerializeField]
    string _hp;

    public string Level
    {
        get { return _level; }
        set
        {
            _level = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string LevelShort
    {
        get { return _levelShort; }
        set
        {
            _levelShort = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string HP
    {
        get { return _hp; }
        set
        {
            _hp = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    //parameters
    [HideInInspector]
    [SerializeField]
    string _maxHP;
    [HideInInspector]
    [SerializeField]
    string _statPhysicalAttack;
    [HideInInspector]
    [SerializeField]
    string _statPhysicalDefence;
    [HideInInspector]
    [SerializeField]
    string _statMagicalAttack;
    [HideInInspector]
    [SerializeField]
    string _statMagicalDefence;

    public string MaxHP
    {
        get { return _maxHP; }
        set
        {
            _maxHP = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string StatPhysicalAttack
    {
        get { return _statPhysicalAttack; }
        set
        {
            _statPhysicalAttack = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string StatPhysicalDefence
    {
        get { return _statPhysicalDefence; }
        set
        {
            _statPhysicalDefence = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string StatMagicalAttack
    {
        get { return _statMagicalAttack; }
        set
        {
            _statMagicalAttack = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
    public string StatMagicalDefence
    {
        get { return _statMagicalDefence; }
        set
        {
            _statMagicalDefence = value;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }

    //list of types
    [HideInInspector]
    [SerializeField]
    List<string> _weaponTypes = new List<string>();
    [HideInInspector]
    [SerializeField]
    List<string> _armourTypes = new List<string>();
    [HideInInspector]
    [SerializeField]
    List<string> _skillTypes = new List<string>();

    public List<string> WeaponTypes
    {
        get { return _weaponTypes; }
    }
    public List<string> ArmourTypes
    {
        get { return _armourTypes; }
    }
    public List<string> SkillTypes
    {
        get { return _skillTypes; }
    }
}