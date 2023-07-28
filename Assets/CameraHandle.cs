using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviourPunCallbacks
{
    private GameObject cameraHolder;
    private Vector3 offset;
    private float smoothing = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cameraHolder = transform.GetChild(1).gameObject;
        offset = cameraHolder.transform.position - new Vector3(0, 0, 40);

        if (!photonView.IsMine) cameraHolder.SetActive(false); //if current view isnt yours (Current instance of game running) then deactivate that camera
    }

    void Update()
    {
        cameraHolder.transform.position = Vector3.Lerp(cameraHolder.transform.position, transform.position + offset, smoothing * Time.deltaTime);
    }
}
