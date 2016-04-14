using UnityEngine;
using System.Collections;

public class ActionPanelOnEnable : MonoBehaviour
{
    void OnEnable()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().PlaySound(GameManager.Instance.System_DB.CharacterTurnSFX);
    }
}