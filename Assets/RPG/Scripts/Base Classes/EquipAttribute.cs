using UnityEngine;
using System.Collections;

public class EquipAttribute
{
    public enum ModifyType
    {
        ADD,
        MINUS,
        ADDMULTIPLY,
        MINUSMULTIPLY
    }

    BaseStat.StatTypes _statType;
    ModifyType _modType;
    int _value;

    public int GetAttributeValue(BaseCharacter character)
    {
        switch (_modType)
        {
            case ModifyType.ADD:
                return _value;
            case ModifyType.MINUS:
                return _value * -1;                
            case ModifyType.ADDMULTIPLY:
                return (int)((float)character.BaseAttack * (float)(_value / 100));
            case ModifyType.MINUSMULTIPLY:
                return (int)((float)character.BaseAttack * (float)(_value / 100)) * -1;
            default:
                return 0;
        }
    }

    public BaseStat.StatTypes StatType
    {
        get { return _statType; }
    }

    //testing
    public EquipAttribute(BaseStat.StatTypes statType, ModifyType modType, int value)
    {
        _statType = statType;
        _modType = modType;
        _value = value;
    }
}