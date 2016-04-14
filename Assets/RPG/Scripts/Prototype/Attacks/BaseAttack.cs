using UnityEngine;

[System.Serializable]
public abstract class BaseAttack : MonoBehaviour
{
    public string AttackName;
    public int BaseAttackDamage;
    public bool IsPhysical;
    public int AttackCost;
}