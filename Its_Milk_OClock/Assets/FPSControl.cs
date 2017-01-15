using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class FPSControl : MonoBehaviour {
    
    public PlayerIndex playerIndexNum;
    //public int playerNumber;
    private GamePadState state;
    public float lookSpeed = 1f;
    public float moveSpeed = 1f;

     Transform camTrans;

	public float	vertMult=0.5f, vertMin=-30, vertMax=30;
	public float	horizMult=0.5f;
	public float	speed = 10;
	
	public Vector3 	rot;
	public Vector3 	camRot;
	Rigidbody 		rigid;

    public GameObject laserBlast;
    public GameObject muzzle;
    public GameObject ABParticle;
    public GameObject GlowParticle;
    public shakifier gunShake;

    public Transform flareOrigin;
    public GameObject laserFlare;

    public GameObject laserGun;

    private float lastFireTime = 0f;
    private bool firing = false;
    public float RoF = 0.5f;
    public float particleTime = 0.1f;

    // Use this for initialization
    void Start () {
		camTrans = transform.Find ("Camera");
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && !firing)
        {
            GameObject laserInst = Instantiate(laserBlast);
            laserInst.transform.position = muzzle.transform.position;
            laserInst.transform.rotation = muzzle.transform.rotation;
            GameObject laserFlareInst = Instantiate(laserFlare);
            laserFlareInst.transform.position = flareOrigin.transform.position;
            laserFlareInst.transform.rotation = flareOrigin.transform.rotation;
            firing = true;
            lastFireTime = Time.time;
            gunShake.shakeTime += RoF;
            //laserGun.GetComponent<Animator>().SetBool("firing", true);
            laserGun.GetComponent<Animator>().SetTrigger("fire");
        }
        if (Time.time < lastFireTime + particleTime)
        {
            if (ABParticle.GetComponent<ParticleSystem>().enableEmission == false)
            {
                ABParticle.GetComponent<ParticleSystem>().enableEmission = true;
                GlowParticle.GetComponent<ParticleSystem>().enableEmission = true;
            }
        }
        else
        {
            if (ABParticle.GetComponent<ParticleSystem>().enableEmission == true)
            {
                ABParticle.GetComponent<ParticleSystem>().enableEmission = false;
                GlowParticle.GetComponent<ParticleSystem>().enableEmission = false;
            }

        }

        rot = transform.localRotation.eulerAngles;
		camRot = camTrans.localRotation.eulerAngles;
		if (camRot.x > 180) camRot.x -= 360;

        float mDeltaX;
        float mDeltaY;

        state = GamePad.GetState(playerIndexNum);
        if (state.IsConnected)
        {
            //Debug.Log ("Controller " + playerIndexNum.ToString () + " connected.");
            mDeltaX = state.ThumbSticks.Right.X * lookSpeed * Time.deltaTime;
            mDeltaY = state.ThumbSticks.Right.Y * lookSpeed * Time.deltaTime;

        }
        else {
            mDeltaX = Input.GetAxis("Mouse X");
            mDeltaY = Input.GetAxis("Mouse Y");

        }

		print ("mX:"+mDeltaX+"    mY:"+mDeltaY);

		camRot.x -= mDeltaY * vertMult;
		camRot.x = Mathf.Clamp(camRot.x, vertMin, vertMax);

		rot.y += mDeltaX * horizMult;

		transform.localRotation = Quaternion.Euler(rot);
		camTrans.localRotation = Quaternion.Euler(camRot);
	}

	void FixedUpdate() {

        if (firing && (Time.time> lastFireTime + RoF))
        {
            firing = false;
            //laserGun.GetComponent<Animator>().SetBool("firing", false);
        }
        
        float vX;
        float vY;

        state = GamePad.GetState(playerIndexNum);
        if (state.IsConnected)
        {
            //Debug.Log ("Controller " + playerIndexNum.ToString () + " connected.");
            vX = state.ThumbSticks.Left.X * moveSpeed * Time.fixedDeltaTime;
            vY = state.ThumbSticks.Left.Y * moveSpeed * Time.fixedDeltaTime;

        }
        else {
            vX = Input.GetAxis("Horizontal");
            vY = Input.GetAxis("Vertical");

        }

        Vector3 vel = Vector3.zero;
		vel += transform.forward * vY;
		vel += transform.right * vX;
		vel *= speed;
		vel.y = rigid.velocity.y;

		rigid.velocity = vel;
	}
}
