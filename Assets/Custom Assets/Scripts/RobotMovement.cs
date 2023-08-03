using UnityEngine;
using System.Collections;

public class RobotMovement : MonoBehaviour 
{
	public Transform[] locations;

	private int count = 0;

	void Start()
	{
		count = locations.Length;

		NextTarget();
	}


	void NextTarget()
	{
		if (count < locations.Length - 1)
		{
			count++;
		}
		else
		{
			count = 0;
		}

		Transform pos = locations[count];

		iTween.MoveTo(gameObject, iTween.Hash("position", pos, "looktarget", pos, "looktime", 0.5, "speed", 2, "oncomplete", "NextTarget"));
	}

}
