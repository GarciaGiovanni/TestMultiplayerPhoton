using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceItemContainer : MonoBehaviourPunCallbacks
{
    public ItemInstance item;
    public ItemInstance TakeItem()
    {
        PhotonNetwork.Destroy(gameObject);
        return item;
    }
}
