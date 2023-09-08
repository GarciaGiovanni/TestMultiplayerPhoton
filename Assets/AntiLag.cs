using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiLag : MonoBehaviourPunCallbacks, IPunObservable
{
    private Rigidbody2D rb;
    private Vector2 _netPos;
    private Quaternion _netRot;
    void Awake()
    {
        if (photonView.IsMine)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    void Start()
    {
        if (!photonView.IsMine)
        {
            _netPos = transform.position;
            _netRot = transform.rotation;
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _netPos, Time.fixedDeltaTime); // I wonder if I need to change this line with Vector3.Lerp ??
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, _netRot, Time.fixedDeltaTime * 720.0f);
            return;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rb.velocity);
            //stream.SendNext(transform.rotation);
            //stream.SendNext(rb.velocity);

        }
        else
        {
            rb.velocity = (Vector2)stream.ReceiveNext();
            //_netPos = (Vector2)stream.ReceiveNext();
            //_netRot = (Quaternion)stream.ReceiveNext();
            //rb.velocity = (Vector2)stream.ReceiveNext();

            //float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            //Debug.Log(lag);
            //_netPos += (rb.velocity * lag);
            //if (Vector3.Distance(this.transform.position, _netPos) > 20.0f) // more or less a replacement for CheckExitScreen function on remote clients
            //{
            //    this.transform.position = _netPos;
            //}

        }
    }
}
