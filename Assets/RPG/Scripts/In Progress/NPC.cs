﻿using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
    public string Name;
    public string QuestText;
    public string InProgressText;
    public string CompletionText;
    public string CompletedText;

    private bool _hasGivenQuest = false;
    private bool _questComplete = false;

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!_hasGivenQuest)
                {
                    QuestPopup.Instance.Popup(Name, QuestText, 3);
                    _hasGivenQuest = true;
                }
                else if(!_questComplete)
                {
                    if(!other.GetComponent<Inventory>().CheckInventory())
                        QuestPopup.Instance.Popup(Name, InProgressText, 3);
                    else
                    {
                        QuestPopup.Instance.Popup(Name, CompletionText, 3);
                        _questComplete = true;
                        if (!other.GetComponent<Inventory>().CheckInventory())
                            other.GetComponent<Inventory>().RemoveFromInventory(0);
                    }
                }
                else
                {
                    QuestPopup.Instance.Popup(Name, CompletedText, 3);
                }
            }
        }
    }
}