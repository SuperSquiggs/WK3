using UnityEngine;
using System.Collections;

public class IncineratorOpen : MonoBehaviour 
{
	[SerializeField]
	private GameObject Door = null;

	private HingeJoint doorJoint;
	private JointMotor jm;

	// Use this for initialization
	void Awake () 
	{
		doorJoint = Door.GetComponent<HingeJoint>();

	}
	
	public void ClickInteraction()
	{
		doorJoint.useMotor = !doorJoint.useMotor;
	}
}
