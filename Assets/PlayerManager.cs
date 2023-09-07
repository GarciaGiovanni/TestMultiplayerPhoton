//AS OF RIGHT NOW DONE!!

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Tilemaps.Tilemap;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    Rigidbody2D rb;
    private float defaultSpeed = 150f;

    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement();
        photonView.RPC("Movement", RpcTarget.All);
    }

    //THIS FUNCTION IS A RPC MEANING ITS SENT RIGHT TO THE SERVER
    //Works better for syncing
    [PunRPC]
    void Movement()
    {
        if (photonView.IsMine)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * defaultSpeed * Time.fixedDeltaTime;
            rb.velocity = move;
        }
    }
}
