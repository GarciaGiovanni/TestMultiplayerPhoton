using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviourPunCallbacks
{
    Vector3 worldPosition;
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        int layerMask = 1 << 3;
        layerMask = ~layerMask;

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(worldPosition.x, worldPosition.y), Mathf.Infinity, LayerMask.GetMask("Shootable"), 0);
            if (hit.collider != null)
            {
                //Hit something, print the tag of the object
                Debug.Log("Hitting: " + hit.collider.tag);
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            //photonView.RPC("Shoot", RpcTarget.All);
        }
    }

    [PunRPC]
    private void Shoot()
    {
        //List<RaycastHit2D> results = new List<RaycastHit2D>();


       
    }

}
