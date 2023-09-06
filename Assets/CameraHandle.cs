//AS OF RIGHT NOW DONE!!

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
        //Gets player object
        cameraHolder = transform.GetChild(1).gameObject;

        //Creates offset for cameras Z axis creating Fixed FOV
        offset = cameraHolder.transform.position - new Vector3(0, 0, 40);

        if (!photonView.IsMine) cameraHolder.SetActive(false); //if current view isnt yours (Current instance of game running) then deactivate that camera
    }

    void Update()
    {
        //Lerps camera to position of player, add smoothing for a delayed effect
        cameraHolder.transform.position = Vector3.Lerp(cameraHolder.transform.position, transform.position + offset, smoothing * Time.deltaTime);
    }
}
