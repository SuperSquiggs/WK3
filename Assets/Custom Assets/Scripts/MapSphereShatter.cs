using UnityEngine;
using System.Collections;

public class MapSphereShatter : MonoBehaviour 
{
	[SerializeField]
	private float shatterVel = 0.0f;

	[SerializeField]
	private GameObject shatterMesh = null;

	private Rigidbody rb;

	private bool canShatter;

	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody>();

		canShatter = true;
	}

	void OnCollisionEnter(Collision other)
	{
		if (rb.velocity.magnitude > shatterVel)
		{
			if (canShatter)
			{
				canShatter = false;
				Shatter();
			}
		}
	}

	private void Shatter ()
	{
		GameObject go = Instantiate(shatterMesh, transform.position, transform.rotation) as GameObject;
		GameObject chop = go.transform.GetChild(0).gameObject;
		Rigidbody[] shards = chop.transform.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody shard in shards)
		{
			shard.velocity = rb.velocity;
		}
		Destroy(this.gameObject);
	}
}
