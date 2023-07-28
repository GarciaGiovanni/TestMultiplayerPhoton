using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviourPunCallbacks
{
    public Inventory inventory;
    private ItemInstance inHand;
    private GameObject itemModel;
    void Start()
    {
        if (inHand is not null && inHand.itemType.model is not null)
        {
            itemModel = Instantiate(inHand.itemType.model, this.transform.position + new Vector3(-1, 0.5f, 0), new Quaternion(0.0f, 0.0f, 0.0f, 1), this.transform) as GameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.TryGetComponent(out InstanceItemContainer foundItem) && !inventory.get_size_left())
        {
            inventory.AddItem(foundItem.TakeItem());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equip(1, this.transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equip(2, this.transform);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            drop();
        }
    }

    public void drop()
    {
        if (inHand is not null && inHand.itemType.model is not null)
        {
            GameObject temp;
            temp = Instantiate(inHand.itemType.model, this.transform.position + new Vector3(1, 0, 0), new Quaternion(0.0f, 0.0f, 0.0f, 1)) as GameObject;
            temp.GetComponent<InstanceItemContainer>().item.set_amount(inHand.get_amount());
            //NetworkServer.Spawn(temp);
            remove(itemModel);
            inventory.items.RemoveAt(inventory.items.IndexOf(inHand));
            inHand = null;
        }
    }

    public void equip(int itemIndex, Transform parent)
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
