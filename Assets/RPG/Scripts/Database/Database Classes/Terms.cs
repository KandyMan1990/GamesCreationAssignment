using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Terms : ScriptableObject
{
    //title screen
    [SerializeField]
    string _newGame;
    [SerializeField]
    string _loadGame;
    [SerializeField]
    string _quit;
    [SerializeField]
    string _cancel;

    public string NewGame
    {
        get { return _newGame; }
        set { _newGame = value; }
    }
    public string LoadGame
    {
        get { return _loadGame; }
        set { _loadGame = value; }
    }
    public string Quit
    {
        get { return _quit; }
        set { _quit = value; }
    }
    public string Cancel
    {
        get { return _cancel; }
        set { _cancel = value; }
    }

    //menus
    [SerializeField]
    string _weapons;
    [SerializeField]
    string _armours;
    [SerializeField]
    string _items;
    [SerializeField]
    string _equip;
    [SerializeField]
    string _autoEquip;
    [SerializeField]
    string _clear;

    public string Weapons
    {
        get { return _weapons; }
        set { _weapons = value; }
    }
    public string Armours
    {
        get { return _armours; }
        set { _armours = value; }
    }
    public string Items
    {
        get { return _items; }
        set { _items = value; }
    }
    public string Equip
    {
        get { return _equip; }
        set { _equip = value; }
    }
    public string AutoEquip
    {
        get { return _autoEquip; }
        set { _autoEquip = value; }
    }
    public string Clear
    {
        get { return _clear; }
        set { _clear = value; }
    }

    //commands
    [SerializeField]
    string _fight;
    [SerializeField]
    string _escape;
    [SerializeField]
    string _skills;
    [SerializeField]
    string _status;
    [SerializeField]
    string _save;

    public string Fight
    {
        get { return _fight; }
        set { _fight = value; }
    }
    public string Escape
    {
        get { return _escape; }
        set { _escape = value; }
    }
    public string Skills
    {
        get { return _skills; }
        set { _skills = value; }
    }
    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }
    public string Save
    {
        get { return _save; }
        set { _save = value; }
    }

    //equipment types
    [SerializeField]
    string _weapon;
    [SerializeField]
    string _armour;
    [SerializeField]
    string _accessory;

    public string Weapon
    {
        get { return _weapon; }
        set { _weapon = value; }
    }
    public string Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public string Accessory
    {
        get { return _accessory; }
        set { _accessory = value; }
    }

    //basic status
    [SerializeField]
    string _level;
    [SerializeField]
    string _levelShort;
    [SerializeField]
    string _hp;

    public string Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public string LevelShort
    {
        get { return _levelShort; }
        set { _levelShort = value; }
    }
    public string HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    //parameters
    [SerializeField]
    string _maxHP;
    [SerializeField]
    string _statPhysicalAttack;
    [SerializeField]
    string _statPhysicalDefence;
    [SerializeField]
    string _statMagicalAttack;
    [SerializeField]
    string _statMagicalDefence;

    public string MaxHP
    {
        get { return _maxHP; }
        set { _maxHP = value; }
    }
    public string StatPhysicalAttack
    {
        get { return _statPhysicalAttack; }
        set { _statPhysicalAttack = value; }
    }
    public string StatPhysicalDefence
    {
        get { return _statPhysicalDefence; }
        set { _statPhysicalDefence = value; }
    }
    public string StatMagicalAttack
    {
        get { return _statMagicalAttack; }
        set { _statMagicalAttack = value; }
    }
    public string StatMagicalDefence
    {
        get { return _statMagicalDefence; }
        set { _statMagicalDefence = value; }
    }

    //list of types
    [SerializeField]
    List<string> _weaponTypes = new List<string>();
    [SerializeField]
    List<string> _armourTypes = new List<string>();
    [SerializeField]
    List<string> _skillTypes = new List<string>();
    [SerializeField]
    List<string> _elementTypes = new List<string>();

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
    public List<string> ElementTypes
    {
        get { return _elementTypes; }
    }
}