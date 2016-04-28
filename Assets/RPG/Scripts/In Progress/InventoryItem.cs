using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour
{
    public int HealthToRestore;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<Inventory>().AddToInventory(this);
                gameObject.SetActive(false);
            }
        }
    }
}