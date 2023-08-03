using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource m_sound;
    public float forceMaxClamp = 8f;
    public float forceMinClamp = 3f;
    private float m_sMag = 0f;

    // Start is called before the first frame update
    void Start()
    {
        m_sound = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log ("LINEAR VEL " + collision.relativeVelocity);
        //Debug.Log("LINEAR VEL " + collision.relativeVelocity.magnitude);
        
        m_sMag = collision.relativeVelocity.magnitude;
        m_sound.pitch = Random.Range(0.8f, 1.2f);

        if (m_sMag < forceMaxClamp && m_sMag > forceMinClamp)
        {
            if (!m_sound.isPlaying)
            {
                m_sound.volume = 0.5f;
                m_sound.Play();
            }
        }
        else if (m_sMag > forceMaxClamp)
        {
            if (!m_sound.isPlaying)
            {
                m_sound.volume = 1f;
                m_sound.Play();
            }

        }
    }

}
