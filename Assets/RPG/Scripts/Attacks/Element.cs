using UnityEngine;
using System.Collections;

public class Element
{
    [SerializeField]
    string _name;
    [SerializeField]
    int _value;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int BaseValue
    {
        get { return _value; }
        set { _value = value; }
    }

    public Element(string Name, int BaseValue)
    {
        _name = Name;
        _value = BaseValue;
    }
}