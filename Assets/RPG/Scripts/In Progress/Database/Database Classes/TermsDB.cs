using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public partial class TermsDB : ScriptableObject
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
    }
    public string LoadGame
    {
        get { return _loadGame; }
    }
    public string Quit
    {
        get { return _quit; }
    }
    public string Cancel
    {
        get { return _cancel; }
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
    }
    public string Armours
    {
        get { return _armours; }
    }
    public string Items
    {
        get { return _items; }
    }
    public string Equip
    {
        get { return _equip; }
    }
    public string AutoEquip
    {
        get { return _autoEquip; }
    }
    public string Clear
    {
        get { return _clear; }
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
    }
    public string Escape
    {
        get { return _escape; }
    }
    public string Skills
    {
        get { return _skills; }

    }
    public string Status
    {
        get { return _status; }
    }
    public string Save
    {
        get { return _save; }
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
    }
    public string Armour
    {
        get { return _armour; }
    }
    public string Accessory
    {
        get { return _accessory; }
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
    }
    public string LevelShort
    {
        get { return _levelShort; }
    }
    public string HP
    {
        get { return _hp; }
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
    }
    public string StatPhysicalAttack
    {
        get { return _statPhysicalAttack; }
    }
    public string StatPhysicalDefence
    {
        get { return _statPhysicalDefence; }
    }
    public string StatMagicalAttack
    {
        get { return _statMagicalAttack; }
    }
    public string StatMagicalDefence
    {
        get { return _statMagicalDefence; }
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