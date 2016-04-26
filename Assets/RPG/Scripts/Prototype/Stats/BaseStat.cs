using UnityEngine;

[System.Serializable]
public class BaseStat
{
    [SerializeField]
    private string _description;
    [SerializeField]
    private StatTypes _type;
    [SerializeField]
    private int _lvlOneValue;
    [SerializeField]
    private int _lvlTwentyValue;
    [SerializeField]
    private int _lvlOneHundredValue;
    [SerializeField]
    private int _baseValue;     //comes from level/animation curve, is only set on level up
    //modified is a culmination of weapon, armour, accessory and any other modifiers. when getting, return base plus modified, allows for modified to potentially lower base
    //character has public getters for these stats, allows for effects such as lowering a stat to base value or restoring a stat to normal aka default modified value
    [SerializeField]
    private int _modifiedValue;
    [SerializeField]
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

    public BaseStat(string description, StatTypes type)
    {
        _description = description;
        _type = type;
    }

    public string StatDescription
    {
        get { return _description; }
    }

    public int StatBaseValue
    {
        get { return _baseValue; }
    }

    public int StatModifiedValue
    {
        get { return _baseValue + _modifiedValue; }
    }

    public StatTypes StatType
    {
        get { return _type; }
    }

    public int BattleValue
    {
        get { return _battleValue; }
        set
        {
            _battleValue = value;

            if (StatType == StatTypes.HEALTH && _battleValue > _modifiedValue)
            {
                _battleValue = _modifiedValue;
            }

        }
    }

    public int LvlOneValue
    {
        get { return _lvlOneValue; }
        set { _lvlOneValue = value; }
    }

    public int LvlTwentyValue
    {
        get { return _lvlTwentyValue; }
        set { _lvlTwentyValue = value; }
    }

    public int LvlOneHundredValue
    {
        get { return _lvlOneHundredValue; }
        set { _lvlOneHundredValue = value; }
    }

    public void SetBaseStat(int level)
    {
        int scaledLevel;

        if (level == 1)
            _baseValue = _lvlOneValue;
        else if (level < 20)
        {
            scaledLevel = (level - 1) / (20 - 1);
            _baseValue = Mathf.FloorToInt(Mathf.Lerp(_lvlOneValue, _lvlTwentyValue, scaledLevel));
        }
        else if (level == 20)
        {
            _baseValue = _lvlTwentyValue;
        }
        else
        {
            scaledLevel = (level - 21) / (100 - 21);
            _baseValue = Mathf.FloorToInt(Mathf.Lerp(_lvlTwentyValue, _lvlOneHundredValue, scaledLevel));
        }
    }

    public void SetModifiedStat(Character ch)
    {
        _modifiedValue = 0;

        switch(StatType)
        {
            case StatTypes.HEALTH:
                //check if armour and/or accessories raise health, if so, add to modified stat
                break;
            case StatTypes.MAGATK:
                _modifiedValue += ch.Wep.MagicalAttack;
                //check if armour and/or accessories raise magic attack, if so, add to modified stat
                break;
            case StatTypes.MAGDEF:
                //check if armour and/or accessories raise magic defence, if so, add to modified stat
                break;
            case StatTypes.PHYATK:
                _modifiedValue += ch.Wep.PhysicalAttack;
                //check if armour and/or accessories raise physical attack, if so, add to modified stat
                break;
            case StatTypes.PHYDEF:
                //check if armour and/or accessories raise physical defence, if so, add to modified stat
                break;
        }
    }

    public void InitBattleValue()
    {
        _battleValue = _modifiedValue;
    }
}