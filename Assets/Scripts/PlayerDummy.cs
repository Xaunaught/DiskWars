using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDummy : MonoBehaviour
{
    private float chargeAmount;
    public float minCharge;
    private Rigidbody rBody;
    public float maxCharge;
    private Vector3 pushDir;
    private float chargeMultiplier;
    public int chargePercentage;
    public TextMesh PlayerTextMesh;

    Vector3 oldVel;

    // Use this for initialization
    void Start()
    {
        chargeAmount = 0f;
        minCharge = 3f;
        maxCharge = 20f;
        chargeMultiplier = 30;
        chargePercentage = 0;
        rBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        oldVel = rBody.velocity;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag != "ground")
        {
            ContactPoint cp = c.contacts[0];
            PlayerCollisionTest(rBody, c.rigidbody);
            rBody.velocity = Vector3.Reflect(oldVel, cp.normal);
        }
        

        //use a a collision to get velocity, comapre speeds, set bounceback to lower on dominant player

    }

    void PlayerCollisionTest(Rigidbody player, Rigidbody otherPlayer)
    {
        if(player.velocity.magnitude > otherPlayer.velocity.magnitude)
        {
            rBody.drag = 10;
            print("player was faster");
        }
        else
        {
            //rBody.AddForce((otherPlayer.velocity * -otherPlayer.velocity.magnitude), ForceMode.Impulse);
            print("player other was faster");
        }
    }
}
