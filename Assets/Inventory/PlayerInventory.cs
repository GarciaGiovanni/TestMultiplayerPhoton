using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If you dont understand, close the application you shouldnt be working

public class PlayerInventory : MonoBehaviourPunCallbacks
{
    public Inventory inventory;
    public ItemInstance inHand;
    private GameObject itemModel;
    void Start()
    {
        //if (inHand is not null && inHand.itemType.model is not null)
        //{
        //    itemModel = Instantiate(inHand.itemType.model, this.transform.position + new Vector3(-1, 0.5f, 0), new Quaternion(0.0f, 0.0f, 0.0f, 1), this.transform) as GameObject;
        //}
    }

    //Almost Done Need To Fix HitBoxes
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.TryGetComponent(out InstanceItemContainer foundItem) && !inventory.get_size_left())
        {
            inventory.AddItem(foundItem.TakeItem());
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                photonView.RPC("equip", RpcTarget.AllBuffered, 1);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                photonView.RPC("drop", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    public void drop()
    {
        if (inHand is not null && inHand.itemType.model is not null)
        {
            GameObject temp;
            temp = PhotonNetwork.InstantiateRoomObject(inHand.itemType.model.name, this.transform.position + new Vector3(1, 0, -1), new Quaternion(0.0f, 0.0f, 0.0f, 1));
            temp.GetComponent<InstanceItemContainer>().item.set_amount(inHand.get_amount());
            remove(itemModel);
            inventory.items.RemoveAt(inventory.items.IndexOf(inHand));
            inHand = null;
        }
    }

    [PunRPC]
    public void equip(int itemIndex)
    {
        if (itemIndex <= inventory.items.Count - 1)
        {
            if (itemModel is not null && itemIndex == inventory.items.IndexOf(inHand))
            {
                remove(itemModel);
                inHand = null;
            }
            else if (itemModel == null)
            {
                displayItem(itemIndex);
            }
            else if (itemModel is not null && itemIndex != inventory.items.IndexOf(inHand))
            {
                remove(itemModel);
                inHand = null;
                displayItem(itemIndex);
            }
        }

    }

    private void remove(GameObject o) { Destroy(o); }

    private void displayItem(int index)
    {
        itemModel = Instantiate(inventory.items[index].itemType.model, this.transform.position + new Vector3(-1, 0.5f, 0), new Quaternion(0.0f, 0.0f, 0.0f, 1), this.transform) as GameObject;
        inHand = inventory.items[index];
    }



}
