using UnityEngine;
using System.Collections;

public class MapSphereHolder : MonoBehaviour 
{
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Map"))				// looking for an object entering this trigger with the tag "Map" - so we can give it this object as its magnet position
		{
			//Debug.Log(other.transform.parent.name);
			other.transform.parent.GetComponent<MapSphereMagnet>().AddMagnetPos(this.transform);
		}
		else if (other.CompareTag("MapShard"))		// looking for an object entering this trigger with the tag "MapShard" - same as above
		{
			other.transform.GetComponent<MapSphereMagnet>().AddMagnetPos(this.transform);
		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Map"))
		{
			other.transform.parent.GetComponent<MapSphereMagnet>().RemoveMagnetPos(); // remove the magnet position when this object exits the trigger zone
		}
		else if (other.CompareTag("MapShard"))
		{
			other.transform.GetComponent<MapSphereMagnet>().RemoveMagnetPos();
		}
	}
}
