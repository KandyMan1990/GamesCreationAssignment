using UnityEngine;
using System.Collections;

public class ActionPanelOnEnable : MonoBehaviour
{
    public AudioClip clip;

    void OnEnable()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().PlaySound(clip);
    }
}