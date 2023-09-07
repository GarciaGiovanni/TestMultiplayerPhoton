using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryDisplay : MonoBehaviourPunCallbacks
{
    private GameObject inventoryView; 
    void Awake()
    {
        if (photonView.IsMine)
            inventoryView = transform.GetChild(2).gameObject;
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryView.SetActive(!inventoryView.activeSelf);
        }
    }
}
