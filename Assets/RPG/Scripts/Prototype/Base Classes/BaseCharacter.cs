using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class BaseCharacter
{
    public string CharacterName;

    public int baseHP;
    public int currentHP;

    public int physicalAttack;
    public int physicalDefence;

    public int magicalAttack;
    public int magicalDefence;

    public int Luck;

    //public int evasion;
    /*
    animation curves should return to evaluate current level in order to set stats
    additional set of variables for bonuses, phyAtk bonus etc
    additional set of variables for current stats that can be manipulated in game (meltdown lowers phyDef to 0 but we don't want to set the actual phyDef to 0)
    additional set of public variables that can get the final value necessarry (evaluated stat + bonuses)
    */

    public List<BaseAttack> AttackList = new List<BaseAttack>();

    public string HPtoString
    {
        get { return currentHP + "/" + baseHP; }
    }
}