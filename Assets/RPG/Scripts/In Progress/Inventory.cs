﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    List<InventoryItem> PotionList = new List<InventoryItem>();

    void Start()
    {
        GetInventory();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UseInventoryItem();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GetInventory();
        }
    }

    public void UseInventoryItem()
    {
        if (PotionList.Count > 0)
        {
            Debug.Log("Inventory item " + PotionList[0] + " has been used");
            RemoveFromInventory(PotionList[0]);
        }
    }

    public bool CheckInventory()
    {
        if (PotionList.Count > 0)
            return true;
        else
            return false;
    }

    public void GetInventory()
    {
        if (PotionList.Count > 0)
        {
            for (int i = 0; i < PotionList.Count; i++)
            {
                Debug.Log("Inventory slot " + i + " contains " + PotionList[i]);
            }
        }
        else
        {
            Debug.Log("Inventory is empty");
        }
    }

    public void AddToInventory(InventoryItem obj)
    {
        PotionList.Add(obj);
        Debug.Log(obj + " added to inventory.");
        GetInventory();
    }

    public void RemoveFromInventory(InventoryItem obj)
    {
        PotionList.Remove(obj);
        Debug.Log(obj + " removed from inventory.");
        GetInventory();
    }

    public void RemoveFromInventory(int obj)
    {
        PotionList.RemoveAt(obj);
        Debug.Log(PotionList[obj] + " removed from inventory.");
        GetInventory();
    }
}