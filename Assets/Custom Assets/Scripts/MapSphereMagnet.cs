using UnityEngine;
using System.Collections;

public class MapSphereMagnet : MonoBehaviour 
{
	public Transform magnetPos;

	[SerializeField]
	private float magnetStrength = 0.0f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();		// getting the RigidBody Component of this object
	}


	void FixedUpdate () 
	{
		if (magnetPos != null)				// proceed if a magnet position has been assigned (i.e. through the MapSphereHolder.cs script)
		{
			Vector3 dir = magnetPos.position - transform.position;	// gets a vector that is the difference between the magnet position and the MapSphere transform position

			rb.AddForce(dir * magnetStrength);						// add a force that is propertional to the distance away from the magnet pos - to pull the sphere towards the center

		}
	}


	public void AddMagnetPos (Transform pos)
	{
		magnetPos = pos;

	}


	public void RemoveMagnetPos ()
	{
		magnetPos = null;
	}
}
