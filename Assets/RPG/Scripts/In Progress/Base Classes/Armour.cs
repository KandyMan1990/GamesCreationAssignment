using UnityEngine;
using System.Collections;

[System.Serializable]
public class Armour
{
    [SerializeField]
    string _name;
    [SerializeField]
    Sprite _icon;
    [SerializeField]
    string _description;
    [SerializeField]
    string _armType;
    [SerializeField]
    int _cost;
    [SerializeField]
    GameObject _model;

    [SerializeField]
    int _physicalDefence;
    [SerializeField]
    int _magicalDefence;

    public Armour()
    {
        _name = "New Armour";
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string ArmType
    {
        get { return _armType; }
        set { _armType = value; }
    }
    public int Cost
    {
        get { return _cost; }
        set { _cost = value; }
    }
    public GameObject Model
    {
        get { return _model; }
        set { _model = value; }
    }

    public int PhysicalDefence
    {
        get { return _physicalDefence; }
        set { _physicalDefence = value; }
    }
    public int MagicalAttack
    {
        get { return _magicalDefence; }
        set { _magicalDefence = value; }
    }

    public int ArmourTypeIndex;

    //TODO: maybe have a resistance to an element by a certain percentage?
}