using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class Terms : ScriptableObject
{
    //title screen
    public string _newGame;
    public string _loadGame;
    public string _quit;
    public string _cancel;

    //menus
    public string _weapons;
    public string _armours;
    public string _items;
    public string _equip;
    public string _autoEquip;
    public string _clear;

    //commands
    public string _fight;
    public string _escape;
    public string _skills;
    public string _status;
    public string _save;

    //equipment types
    public string _weapon;
    public string _armour;
    public string _accessory;

    //basic status
    public string _level;
    public string _levelShort;
    public string _hp;

    //parameters
    public string _maxHP;
    public string _statPhysicalAttack;
    public string _statPhysicalDefence;
    public string _statMagicalAttack;
    public string _statMagicalDefence;

    //list of types
    public List<string> _weaponTypes = new List<string>();
    public List<string> _armourTypes = new List<string>();
    public List<string> _skillTypes = new List<string>();
    public List<string> _elementTypes = new List<string>();
}