using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
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
                    Debug.Log("Fetch me my Potion would you?");
                    _hasGivenQuest = true;
                }
                else if(!_questComplete)
                {
                    if(!other.GetComponent<Inventory>().CheckInventory())
                        Debug.Log("I hope you bring my Potion soon...");
                    else
                    {
                        Debug.Log("Thank you, now I won't die!");
                        _questComplete = true;
                        if (!other.GetComponent<Inventory>().CheckInventory())
                            other.GetComponent<Inventory>().RemoveFromInventory(0);
                    }
                }
                else
                {
                    Debug.Log("Thanks again, you're a real hero!");
                }
            }
        }
    }
}