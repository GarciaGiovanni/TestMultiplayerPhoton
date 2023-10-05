using Photon.Pun;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DamageSystem : MonoBehaviourPunCallbacks
{
    private Vector3 worldPosition;
    private int health;
    private GameObject currentWeapon;
    private int dmg;

    void Start()
    {
        if (photonView.IsMine)
        {
            dmg = 10;
            health = 100;
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Debug.Log(health);
            if (Input.GetButtonDown("Fire1")) { Shoot(); }
        }
    }

    private void Shoot()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        LayerMask shootableLayer = LayerMask.GetMask("Shootable");

        // Cast a ray from the object's position towards the mouse pointer
        RaycastHit2D hit = Physics2D.Raycast(transform.position, worldPosition - transform.position, Mathf.Infinity, shootableLayer);

        // If it hits something...
        if (hit.collider != null)
        {
            // Sends remote protocol to the hit object which applies the damage done 
            photonView.RPC("ApplyDamage", hit.collider.gameObject.GetPhotonView().Controller, dmg);
        }
    }

    [PunRPC]
    public void ApplyDamage(int dmg)
    {
        //Debug.Log("I Got Hit!!");
        this.health -= this.dmg;
        Debug.Log(health);
        //if (health <= 0)
        //{
        //    PhotonNetwork.Disconnect();
        //    PhotonNetwork.LoadLevel(0);
        //}
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
        }
    }

}

