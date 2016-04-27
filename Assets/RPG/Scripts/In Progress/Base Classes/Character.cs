using UnityEngine;

public enum CharacterClass
{
    PARTY,
    PLAYER,
    ENEMY
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
    string _wepType;
    [SerializeField]
    Weapon _weapon;
    [SerializeField]
    string _armType;
    [SerializeField]
    Armour _armour;
    //4 accessories
    //skills

    //base stats
    [SerializeField]
    BaseStat _healthStat = new BaseStat("Represents the Health of the character.", BaseStat.StatTypes.HEALTH);
    [SerializeField]
    BaseStat _phyAtkStat = new BaseStat("Represents the Physical Attack of the character.", BaseStat.StatTypes.PHYATK);
    [SerializeField]
    BaseStat _phyDefStat = new BaseStat("Represents the Physical Defence of the character.", BaseStat.StatTypes.PHYDEF);
    [SerializeField]
    BaseStat _magAtkStat = new BaseStat("Represents the Magical Attack of the character.", BaseStat.StatTypes.MAGATK);
    [SerializeField]
    BaseStat _magDefStat = new BaseStat("Represents the Magical Defence of the character.", BaseStat.StatTypes.MAGDEF);    //on level value change, update base stats to reflect curve

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
    public string WeaponType
    {
        get { return _wepType; }
        set { _wepType = value; }
    }
    public Weapon EquippedWeapon
    {
        get { return _weapon; }
        set { _weapon = value; }
    }
    public int WeaponTypeIndex;
    public int WeaponIndex;

    public string ArmourType
    {
        get { return _armType; }
        set { _armType = value; }
    }

    public Armour EquippedArmour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    //4 accessories

    public BaseStat HealthStat
    {
        get { return _healthStat; }
        set { _healthStat = value; }
    }
    public BaseStat PhyAtkStat
    {
        get { return _phyAtkStat; }
        set { _phyAtkStat = value; }
    }
    public BaseStat PhyDefStat
    {
        get { return _phyDefStat; }
        set { _phyDefStat = value; }
    }
    public BaseStat MagAtkStat
    {
        get { return _magAtkStat; }
        set { _magAtkStat = value; }
    }
    public BaseStat MagDefStat
    {
        get { return _magDefStat; }
        set { _magDefStat = value; }
    }
    //skills

    public Character()
    {
        _name = "New Character";
        _level = 1;
        _description = "Enter a character description here.";
    }
}