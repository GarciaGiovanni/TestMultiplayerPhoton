using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    private Camera cam;
    Rigidbody2D rb;
    public float defaultSpeed = 70f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(xInput, yInput, 0) * defaultSpeed * Time.deltaTime * 5;
    }
}
