using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillMover : MonoBehaviour {
    private Rigidbody rBody;
    Vector3 oldVel;
    Vector3 currentVel;

    public float movementZ = 1;
    public float movementX = 1;
    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody>();
        currentVel = new Vector3(movementZ, 0, movementX);
    }
	
	// Update is called once per frame
	void Update () {
        rBody.velocity = currentVel;
	}

    void FixedUpdate()
    {
        oldVel = rBody.velocity;
    }

    void OnCollisionEnter(Collision c)
    {
        print("hit a wall");
        if (c.gameObject.tag == "Walls")
        {
            ContactPoint cp = c.contacts[0];

            currentVel = Vector3.Reflect(oldVel, cp.normal);
        }
    }
}
