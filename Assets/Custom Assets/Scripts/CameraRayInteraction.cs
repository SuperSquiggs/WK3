using UnityEngine;
using System.Collections;

public class CameraRayInteraction : MonoBehaviour 
{
	[SerializeField]
	private float maxRayDist = 2f;

	private Camera cam;

	// Use this for initialization
	void Awake () 
	{
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, maxRayDist)) // this targets the object hit by the raycast with a message. Any kind of click interaction can be set up in this way.
			{
				//Debug.Log(hit.transform.name);
				hit.transform.gameObject.SendMessage("ClickInteraction", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
