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
                GameManager.Instance.PlaySFX((GameManager.Instance.System_DB.ReceiveItemSFX));
                gameObject.SetActive(false);
            }
        }
    }
}