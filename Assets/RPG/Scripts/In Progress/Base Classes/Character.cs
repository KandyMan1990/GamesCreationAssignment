using UnityEngine;
using System.Collections;

public enum CharacterClass
{
    NONE,
    PLAYER,
    PARTY,
    ENEMY,
    BOSS
}

[System.Serializable]
public class Character
{
    [SerializeField]
    string _name;
    [SerializeField]
    int _level;
    [SerializeField]
    string _description;
    [SerializeField]
    Sprite _portrait;
    [SerializeField]
    GameObject _model;
    [SerializeField]
    CharacterClass _class;
    [SerializeField]
    Weapon _weapon;
    //armour
    //4 accessories
    //hp curve
    //phyAtk curve
    //phyDef curve
    //magAtk curve
    //magDef curve
    //speed curve
    //luck curve
    //skills

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public Sprite Portrait
    {
        get { return _portrait; }
        set { _portrait = value; }
    }
    public GameObject Model
    {
        get { return _model; }
        set { _model = value; }
    }
    public CharacterClass Class
    {
        get { return _class; }
        set { _class = value; }
    }
    public Weapon Wep
    {
        get { return _weapon; }
        set { _weapon = value; }
    }
    public int WeaponIndex;
    //armour
    //4 accessories
    //hp curve
    //phyAtk curve
    //phyDef curve
    //magAtk curve
    //magDef curve
    //speed curve
    //luck curve
    //skills

    public Character()
    {
        _name = "New Character";
        _level = 1;
        _description = "Enter a character description here.";
    }
    //public int baseHP;
    //public int currentHP;

    //public int physicalAttack;
    //public int physicalDefence;

    //public int magicalAttack;
    //public int magicalDefence;

    ////example of using equip attributes
    //public int BaseAttack;
    //public int ModifiedAttack;
    //public EquipAttribute Attribute = new EquipAttribute(BaseStat.StatTypes.PHYATK, EquipAttribute.ModifyType.ADD, 5);

    //void calcStats()
    //{
    //    //modified attack = base attack + all equip attributes of type phyatk in weapon, armour and accessory
    //    ModifiedAttack = BaseAttack + Attribute.GetAttributeValue(this);
    //}


    ////public int evasion;
    ///*
    //animation curves should return to evaluate current level in order to set stats
    //additional set of variables for bonuses, phyAtk bonus etc
    //additional set of variables for current stats that can be manipulated in game (meltdown lowers phyDef to 0 but we don't want to set the actual phyDef to 0)
    //additional set of public variables that can get the final value necessarry (evaluated stat + bonuses)
    //*/

    //public List<BaseAttack> AttackList = new List<BaseAttack>();

    //public string HPtoString
    //{
    //    get { return currentHP + "/" + baseHP; }
    //}
}