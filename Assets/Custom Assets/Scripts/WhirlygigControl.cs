using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlygigControl : MonoBehaviour {

	public Transform player;
	public Light whirlyLight;
	public GameObject whirlySparkObject;

	private HingeJoint whirlyJoint;  
	private JointMotor wMotor;
	private ParticleSystem whirlypart;

	//private float motorForce;		// settable float for the force used to rotate the motor
	private float motorMaxVel;		// variable for storing the max velocity of the motor as set (targetVelocity) in its Prefab (so we can reset it later)
	private float motorMinVel;		// variable for setting the max velocity of the motor to (in this case) zero - doing so engages motor braking behaviour

	private Color lightDefault;
	private Color lightWarn;
	private Renderer rend;			

	// Use this for initialization
	void Start () {
		whirlyJoint = this.GetComponent<HingeJoint> ();		// assigning this GameObject's HingeJoint to the local HingeJoint variable
		rend = this.GetComponent<Renderer>();				// assigning this GameObject's Renderer to the local Renderer variable
		whirlypart = whirlySparkObject.GetComponent<ParticleSystem> ();
		wMotor = whirlyJoint.motor;							// grabbing the JointMotor element and assigning to the local JointMotor variable
		//motorForce = wMotor.force;
		motorMaxVel = wMotor.targetVelocity;				// storing target velocity as motorMaxVel
		motorMinVel = 0.0f;									// initialising the minimum velocity to zero
		lightDefault = whirlyLight.color;
		lightWarn = new Color (0.5f, 0.0f, 1.0f, 1.0f);
		if (player == null)
			GameObject.Find("FPSController");				// grabbing a reference to the player just in case someone forgets to assign a reference in the Unity inspector
	}

	void OnTriggerEnter (Collider other) {					// checking for a specific tagged object (Player) to collide with, not just any-old object
		
		if (player && other.tag == "Player") {
			whirlyJoint.axis = new Vector3 (0, -1, 0);		// making the motor spin backwards by changing the vector from the default 0,1,0
			wMotor.targetVelocity = motorMinVel;			// lowering the target velocity to minimum - causing the motor to brake
			whirlyLight.color = lightWarn;
			rend.material.color = lightWarn;
			whirlypart.Play ();
		}
		
	}

	void OnTriggerExit (Collider other) {
		
		if (player && other.tag == "Player") {
			whirlyJoint.axis = new Vector3 (0, 1, 0);		// change to spin forwards
			wMotor.targetVelocity = motorMaxVel;			// able to go to max speed 
			whirlyLight.color = lightDefault;
			rend.material.color = lightDefault;
			whirlypart.Play ();
		}
	}

	void TurnMotorOff () {
		whirlyJoint.useMotor = false;
		whirlyLight.enabled = false;
	}

	void TurnMotorOn () {
		whirlyJoint.useMotor = true;
		whirlyLight.enabled = true;
	}
}
