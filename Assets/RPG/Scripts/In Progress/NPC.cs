using UnityEngine;
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
            if (QuestPopup.Instance.IsProcessing)
                return;

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!_hasGivenQuest)
                {
                    QuestPopup.Instance.Popup(Name, QuestText, 3, true);
                    _hasGivenQuest = true;
                }
                else if(!_questComplete)
                {
                    if(!other.GetComponent<Inventory>().CheckInventory())
                        QuestPopup.Instance.Popup(Name, InProgressText, 3, true);
                    else
                    {
                        QuestPopup.Instance.Popup(Name, CompletionText, 3, true);
                        _questComplete = true;
                        GameManager.Instance.CompleteQuest();
                        if (!other.GetComponent<Inventory>().CheckInventory())
                            other.GetComponent<Inventory>().RemoveFromInventory(0);
                    }
                }
                else
                {
                    QuestPopup.Instance.Popup(Name, CompletedText, 3, true);
                }
            }
        }
    }
}