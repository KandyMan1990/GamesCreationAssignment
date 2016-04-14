using UnityEngine;
using UnityEditor;

[System.Serializable]
public class BaseMagic : ScriptableObject
{
    [HideInInspector]
    [SerializeField]
    string _name;
    [HideInInspector]
    [SerializeField]
    int _value;

    public string Name
    {
        get { return _name; }
        set { _name = value; EditorUtility.SetDirty(this); }
    }

    public int BaseValue
    {
        get { return _value; }
        set { _value = value; EditorUtility.SetDirty(this); }
    }

    public void Init(string Name, int BaseValue)
    {
        _name = Name;
        _value = BaseValue;
    }

    public static BaseMagic CreateInstance(string Name, int BaseValue)
    {
        BaseMagic obj = ScriptableObject.CreateInstance<BaseMagic>();
        obj.Init(Name, BaseValue);
        return obj;
    }
}