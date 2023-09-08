using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiLag : MonoBehaviourPunCallbacks, IPunObservable
{
    private Rigidbody2D rb;
    private Rigidbody2D netRb;
    private Vector2 _netPos;
    private Quaternion _netRot;

    public void Start()
    {
        if (photonView.IsMine) rb = GetComponent<Rigidbody2D>();    
    }

    public void Awake()
    {
        if (!photonView.IsMine)
        {
            netRb = GetComponent<Rigidbody2D>();
        }
    }

    public void Update()
    {
        if (!photonView.IsMine)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, _netPos, Time.fixedDeltaTime); // I wonder if I need to change this line with Vector3.Lerp ??
            //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, _netRot, Time.fixedDeltaTime * 720.0f);
            //return;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rb.position);
            stream.SendNext(rb.velocity);
        }
        else
        {
            netRb.position = (Vector2) stream.ReceiveNext();
            netRb.velocity = (Vector2) stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            netRb.velocity += netRb.velocity * lag;
            netRb.position += netRb.velocity * lag;
        }
    }
}
