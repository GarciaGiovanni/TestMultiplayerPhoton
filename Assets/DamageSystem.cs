using Photon.Pun;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DamageSystem : MonoBehaviourPunCallbacks
{
    Vector3 worldPosition;

    void Update()
    {
        if (photonView.IsMine && Input.GetButtonDown("Fire1"))
        {
            photonView.RPC("Shoot", RpcTarget.All, null);
        }
    }

    [PunRPC]
    private void Shoot()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check for left mouse button click

        LayerMask shootableLayer = LayerMask.GetMask("Shootable");
            // Cast a ray from the object's position towards the mouse pointer
        RaycastHit2D hit = Physics2D.Raycast(transform.position, worldPosition - transform.position, Mathf.Infinity, shootableLayer);

            // If it hits something...
        if (hit.collider != null)
        {
            ;
        }
    }
}

