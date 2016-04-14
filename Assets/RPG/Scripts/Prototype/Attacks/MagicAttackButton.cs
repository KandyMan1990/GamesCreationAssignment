using UnityEngine;

public class MagicAttackButton : MonoBehaviour
{
    public BaseAttack MagicAttackToPerform;

    public void CastMagic()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().Input4(MagicAttackToPerform);
    }
}