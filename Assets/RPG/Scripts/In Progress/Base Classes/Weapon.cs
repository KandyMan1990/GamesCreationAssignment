using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{
    [SerializeField]
    string _name;
    [SerializeField]
    Sprite _icon;
    [SerializeField]
    string _description;
    [SerializeField]
    string _wepType;
    [SerializeField]
    int _cost;
    [SerializeField]
    GameObject _model;

    //list of stats (can be + or -)
    //element (physical, physical and fire etc)

    public Weapon()
    {
        _name = "New Weapon";
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
    public string WepType
    {
        get { return _wepType; }
        set { _wepType = value; }
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
    public int WeaponTypeIndex;
}