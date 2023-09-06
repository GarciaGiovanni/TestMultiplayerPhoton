//AS OF RIGHT NOW DONE!!

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    private Camera cam;
    Rigidbody2D rb;
    private float defaultSpeed = 150f;
    Vector3 moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        photonView.RPC("Movement", RpcTarget.AllBuffered);
    }

    //THIS FUNCTION IS A RPC MEANING ITS SENT RIGHT TO THE SERVER
    //Works better for syncing
    [PunRPC]
    void Movement()
    {
        if (photonView.IsMine)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * defaultSpeed * Time.deltaTime;
            rb.velocity = move;
        }
    }
}
