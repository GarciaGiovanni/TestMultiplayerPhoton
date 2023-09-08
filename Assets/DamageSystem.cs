using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviourPunCallbacks
{

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //photonView.RPC("Shoot", RpcTarget.All);
        }
    }

    [PunRPC]
    private void Shoot(Ray ray)
    {

        int layerMask = 1 << 3;

        layerMask = ~layerMask;

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.Log("Did not Hit");
        }
    }

}
