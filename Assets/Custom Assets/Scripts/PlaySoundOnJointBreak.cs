using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnJointBreak : MonoBehaviour
{
    public AudioSource m_hingeSound;
    private FixedJoint m_fixJ;
    private HingeJoint m_hingeJ;
    private bool jointBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        m_fixJ = GetComponent<FixedJoint>();
        m_hingeJ = GetComponent<HingeJoint>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("CheckHingeAngle", 0.2f);
    }


    // NOTE. This effect only synchronises with the hinge rotation in some cases. 
    // A better solution would be to play a looping hinge sound while the hinge is rotating, and use pitch shift according to rate of rotation. 

    private void CheckHingeAngle()
    {
        if (m_hingeJ.angle > 2f && !jointBroken)
        {
            m_hingeSound.Play();
            jointBroken = true;
//            Debug.Log("FIX J GONE");
        }
    }
}
