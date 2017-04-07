using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject player1object;
    public GameObject player2object;
    public GameObject player3object;
    public GameObject player4object;

    public GameObject hill;
    public GameObject splash;
    public GameObject timer;

    public bool gameRunning;
	// Use this for initialization
    private void Awake()
    {
    }


	// Update is called once per frame
	void Update () {
	    if (!gameRunning)
	    {
	        Player player1Script = player1.gameObject.GetComponent<Player>();
	        Player player2Script = player2.gameObject.GetComponent<Player>();
	        Player player3Script = player3.gameObject.GetComponent<Player>();
	        Player player4Script = player4.gameObject.GetComponent<Player>();
	        if (player1Script.chargeRe)
	        {
	            player1object.SetActive(true);
	            player1.GetComponent<Rigidbody>().useGravity = true;

	        }
	        if (player2Script.chargeRe)
	        {
	            player2object.SetActive(true);
	            player2.GetComponent<Rigidbody>().useGravity = true;

	        }
	        if (player3Script.chargeRe)
	        {
	            player3object.SetActive(true);
	            player3.GetComponent<Rigidbody>().useGravity = true;

	        }
	        if (player4Script.chargeRe)
	        {
	            player4object.SetActive(true);
	            player4.GetComponent<Rigidbody>().useGravity = true;

	        }
	        if (player1Script.start || player2Script.start || player3Script.start || player4Script.start)
	        {
	            player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	            player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	            player3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	            player4.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	            gameRunning = true;
                splash.SetActive(false);
	            hill.SetActive(true);
                timer.SetActive(true);
	            print("Game started");
	        }
	    }

	}
}
