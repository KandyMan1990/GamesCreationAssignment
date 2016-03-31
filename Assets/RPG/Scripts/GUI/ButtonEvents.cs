using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    private BattleStateMachine BSM;
    private Button btn;
    
    void Start()
    {
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        btn = GetComponent<Button>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(btn.IsInteractable())
            BSM.PlaySound(BSM.ButtonHighlightSound);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (btn.IsInteractable())
            BSM.PlaySound(BSM.ButtonHighlightSound);
    }
}