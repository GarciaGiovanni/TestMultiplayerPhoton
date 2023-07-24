using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviourPunCallbacks
{
    private GameObject cameraHolder;
    private Vector3 offset;
    private float smoothing = 100f;

    // Start is called before the first frame update
    void Start()
    {
        cameraHolder = transform.GetChild(0).gameObject;
        offset = cameraHolder.transform.position - new Vector3(0, 0, 10);
        if (PhotonNetwork.IsConnected)
        {
            cameraHolder.SetActive(true);
        }
    }

    void Update()
    {
        cameraHolder.transform.position = transform.position + offset;
    }
}
