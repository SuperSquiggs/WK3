using UnityEngine;
using System.Collections;

public class IncineratorFire : MonoBehaviour
{
	void OnCollisionEnter (Collision other)
	{
		Destroy(other.gameObject);
	}

}
