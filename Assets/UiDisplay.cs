using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UiDisplay: MonoBehaviourPunCallbacks
{
    private GameObject Panel;
    private GameObject inv;
    private GameObject settings;
    void Awake()
    {
        if (photonView.IsMine)
        {
            Panel = this.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
            inv = Panel.transform.GetChild(0).gameObject;
            settings = Panel.transform.GetChild(1).gameObject;
        }
    }
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Panel.SetActive(!Panel.activeSelf);
            inv.SetActive(!inv.activeSelf);
        }
    }
}
