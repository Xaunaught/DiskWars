using UnityEngine;
using Rewired;

public class Player : MonoBehaviour
{
    private float chargeAmount;
    public float minCharge;
    private Rigidbody rBody;
    public float maxCharge;
    private Vector3 pushDir;
    private float chargeMultiplier;
    public int chargePercentage;
    public TextMesh PlayerTextMesh;
    public GameObject playerManager;
    Vector3 oldVel;


    //Assigned controller
    public int playerId = 0;
    private Rewired.Player player;
    private Vector3 moveVector;
    public bool chargeRe;
    public bool start;
    public bool escape;



    //These floats will be used to store the magnitude of the players velocity over the last couple of frames
    public float velMagnitude;
    float velMagnitudeBuffer;

    void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);
        print(playerId);

    }

    // Use this for initialization
    void Start()
    {
        chargeAmount = 0f;
        minCharge = 3f;
        maxCharge = 30f;
        chargeMultiplier = 40;
        chargePercentage = 0;
        rBody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        velMagnitude = velMagnitudeBuffer;
        velMagnitudeBuffer = rBody.velocity.magnitude;
        oldVel = rBody.velocity;
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        ProcessInput();
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag != "ground")
        {
            ContactPoint cp = c.contacts[0];
            if (c.gameObject.tag == "Walls")
            {
                rBody.velocity = Vector3.Reflect(oldVel, cp.normal);
            }
            if (c.gameObject.tag != "Walls")
            {
                PlayerCollisionTest(rBody, c.rigidbody);
            }


        }


        //use a a collision to get velocity, comapre speeds, set bounceback to lower on dominant player

    }

    void PlayerCollisionTest(Rigidbody player, Rigidbody otherPlayer)
    {
        Player otherPlayerScript = otherPlayer.gameObject.GetComponent<Player>();
        print("player: " + velMagnitude + "   other: " + otherPlayerScript.velMagnitude);
        if (velMagnitude > otherPlayerScript.velMagnitude)
        {
            otherPlayer.AddForce(player.velocity * player.mass, ForceMode.Impulse);
            player.velocity = new Vector3(0, 0, 0);
            print("player was faster");
        }
        else
        {
            print("player other was faster");
        }
    }

    private void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.y = player.GetAxis("Move Vertical");
        chargeRe = player.GetButton("Charge");
        start = player.GetButton("Start");
        escape = player.GetButton("Escape");
    }

    private void ProcessInput()
    {
        if (chargeRe)
        {
            if (chargeAmount < maxCharge)
            {
                chargeAmount += Time.deltaTime * chargeMultiplier;
            }
            else
            {
                chargeAmount = maxCharge;
            }
            chargePercentage = (int)(chargeAmount / maxCharge * 100);
            PlayerTextMesh.text = chargePercentage.ToString();
            //print(chargePercentage);
        }
        else
        {
            if (chargeAmount > 0f)
            {
                chargeAmount = chargeAmount + minCharge;
                //pushDir = new Vector3(inputDevice.LeftStick.X, 0f, inputDevice.LeftStick.Y);
                pushDir = new Vector3(moveVector.x, 0f, moveVector.y);
                //Debug.Log("Push force is " + (pushDir.x * chargeAmount) + "," + (pushDir.y * chargeAmount) + "," + (pushDir.z * chargeAmount));
                rBody.AddForce((pushDir * chargeAmount), ForceMode.Impulse);
                chargeAmount = 0f;
                chargePercentage = 0;
                PlayerTextMesh.text = chargePercentage.ToString();
            }
        }
        if (escape)
        {
            Application.Quit();
        }
    }
}
