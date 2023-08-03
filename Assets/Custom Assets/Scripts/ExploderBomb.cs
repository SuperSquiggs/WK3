using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploderBomb : MonoBehaviour {

	public Transform player;								// reference to the playerś position
	public Transform bomb;									// the position of the bomb object
	public float bombRadius;								// extent the bomb force should affect
	public float bombPower;									// force of the bomb
	public AudioSource bombSound;							// what is a bomb without an explosion sound?
	public Image bombFadeImage;								// reference to the UI white sprite image in front of the camera - for a nice blinding flash effect

	private ParticleSystem partiFlame;
	private Vector3 explosionPos;
	//private Color seeThrough;
	private float fadeTime;									// time the white fadeout will take

	void Awake () {
		bombFadeImage.enabled = false; 						// making sure the UI element is not visible when the game starts
	}

	// Use this for initialization
	void Start () {
		explosionPos = bomb.position;
		//seeThrough = new Color (1.0f, 1.0f, 1.0f, 0.0f);	// transparent
		fadeTime = 0.5f;
		if (player == null)
			GameObject.Find("FPSController");				// grabbing a reference to the player just in case someone forgets to assign a reference in the Unity inspector
		partiFlame = this.GetComponent<ParticleSystem>();
	}

	void OnTriggerEnter (Collider other) {					// checking for a specific tagged object (Player) to collide with, not just any-old object

		if (player && other.tag == "Player") {
			//print ("BOMB");
			Collider[] colliders = Physics.OverlapSphere (explosionPos, bombRadius);		// creating an array of colliders - anything in the OverlapSphere defined by the bomb radius from the explosion center
			foreach (Collider hit in colliders) {											// iterating over the list of colliders found in the array 
				Rigidbody rBody = hit.GetComponent<Rigidbody> ();							// temporarily assigning the rigidbody of the colliding object to a variable rBody
				ParticleSystem partBall = hit.GetComponent<ParticleSystem> ();
				if (rBody != null && rBody.tag == "ExplodingBalls") {						// checking we have an object on the correct layer - only things that exist and are tagged properly will be affected
					rBody.AddExplosionForce (bombPower, explosionPos, bombRadius, 2.0f);	// adding an explosion force. The final var is an offset below the bomb center to give the effect more upward oomf.
					if (partBall != null) {
						partBall.Play ();
					}
				}
					
			}
			bombSound.Play ();
			bombFadeImage.enabled = true;			// turn on the white UI flash
			partiFlame.Play();

			CameraShake.Shake(0.75f, 0.25f); 		// duration, amount
			Invoke ("BeginFade", 0.1f);				// start a function to fade the UI element - but keep it at full intensity for a brief time first
		}

	}

	void BeginFade () {
		bombFadeImage.CrossFadeAlpha (0.0f, fadeTime, true);	// use the crossfade function to fade the alpha value over time.
		Invoke ("DisableFadeImage", fadeTime);					// start a function to restore the white UI elementś values and set it to invisible after it has faded out.
	}

	void DisableFadeImage () {
		bombFadeImage.enabled = false;
		bombFadeImage.CrossFadeAlpha (1.0f, 0.01f, true);
	}
}
