using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour {

	public GameObject obj1;						// reference to the first object we will draw the line from
	public GameObject obj2;						// reference to the second object we will draw the line to (from / to order doesn't matter)
	public Material mat;						// a material reference to apply to the line

	private Color lineCol;
	private LineRenderer line;

	// Use this for initialization
	void Start () {
		line = this.gameObject.AddComponent<LineRenderer> ();	// create a line renderer component
		line.startWidth = 0.05f;
		line.endWidth = 0.05f;
		line.material = mat;
		lineCol = new Color (0.1f, 0.1f, 0.1f, 1);
		line.startColor = lineCol;
		line.endColor = lineCol;
		line.positionCount = 2;									// this line has only a start point and an end point
	}
	
	// Update is called once per frame
	void Update () {
		if (obj1 != null && obj2 != null) {						// checking we have valid references
			line.SetPosition (0, obj1.transform.position);
			line.SetPosition (1, obj2.transform.position);
		}
	}
}
