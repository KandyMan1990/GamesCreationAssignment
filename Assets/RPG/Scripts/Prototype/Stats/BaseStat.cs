[System.Serializable]
public class BaseStat
{
    private string _name;
    private string _description;
    private StatTypes _type;
    private int _baseValue;     //comes from level/animation curve, is only set on level up
    //modified is a culmination of weapon, armour, accessory and any other modifiers. when getting, return base plus modified, allows for modified to potentially lower base
    //character has public getters for these stats, allows for effects such as lowering a stat to base value or restoring a stat to normal aka default modified value
    private int _modifiedValue;
    private int _battleValue;   //set to modified on battle begin, this stat is then modified during battle using effects like haste, meltdown etc.
                                //battle hp cannot go above modified value

    public enum StatTypes
    {
        HEALTH,
        PHYATK,
        PHYDEF,
        MAGATK,
        MAGDEF
    }

    public BaseStat(string name, string description, StatTypes type)
    {
        _name = name;
        _description = description;
        _type = type;
    }

    public string StatName
    {
        get { return _name; }
    }

    public string StatDescription
    {
        get { return _description; }
    }

    public int StatBaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }

    public int StatModifiedValue
    {
        get { return _modifiedValue; }
        set { _modifiedValue = value; }
    }

    public StatTypes StatType
    {
        get { return _type; }
    }

    public int BattleValue
    {
        get { return _battleValue; }
        set { _battleValue = value; }
    }
}