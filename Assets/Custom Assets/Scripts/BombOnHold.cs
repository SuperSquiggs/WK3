using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombOnHold : MonoBehaviour
{
    /*public Transform bomb;
    public float bombRadius;
    public float bombPower;
    public AudioSource bombSound;
    public ParticleSystem partiFlame;
    public Image bombFadeImage;
    private Transform player;
    private Vector3 explosionPos;
    private float holdDuration = 5f;
    private bool isHolding = false;
    private float currentTime = 0f;
    private float fadeTime = 0.5f;

    void Awake()
    {
        bombFadeImage.enabled = false;
    }

    void Start()
    {
        explosionPos = bomb.position;
        player = GameObject.Find("FPSController").transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isHolding = true;
            currentTime = 0f;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isHolding = false;
            currentTime = 0f;
        }

        if (isHolding)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= holdDuration)
            {
                TriggerExplosion();
                isHolding = false;
                currentTime = 0f;
            }
        }
    }

    void TriggerExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPos, bombRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rBody = hit.GetComponent<Rigidbody>();
            ParticleSystem partBall = hit.GetComponent<ParticleSystem>();
            if (rBody != null && rBody.tag == "ExplodingBalls")
            {
                rBody.AddExplosionForce(bombPower, explosionPos, bombRadius, 2.0f);
                if (partBall != null)
                {
                    partBall.Play();
                }
            }
        }

        bombSound.Play();
        bombFadeImage.enabled = true;
        partiFlame.Play();
        CameraShake.Shake(0.75f, 0.25f);
        Invoke("BeginFade", 0.1f);
    }

    void BeginFade()
    {
        bombFadeImage.CrossFadeAlpha(0.0f, fadeTime, true);
        Invoke("DisableFadeImage", fadeTime);
    }

    void DisableFadeImage()
    {
        bombFadeImage.enabled = false;
        bombFadeImage.CrossFadeAlpha(1.0f, 0.01f, true);
    }*/
}
