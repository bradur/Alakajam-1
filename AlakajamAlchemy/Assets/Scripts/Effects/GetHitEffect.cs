// Date   : 23.09.2017 17:42
// Project: AlakajamAlchemy
// Author : bradur

using UnityEngine;
using System.Collections;

public class GetHitEffect : MonoBehaviour {

    private ParticleSystem particleEffect;

    [SerializeField]
    [Range(0.1f, 5f)]
    private float particleLifeTime = 1f;

    private float particleTimer = 0f;

    private bool isPlaying = false;

    [SerializeField]
    private bool dontPause = false;

    void Start () {
        particleEffect = GetComponent<ParticleSystem>();
        particleEffect.Play();
        isPlaying = true;
    }

    void Update () {
        if(isPlaying)
        {
            particleTimer += Time.deltaTime;
            if (particleTimer >= particleLifeTime)
            {
                isPlaying = false;
                if (!dontPause)
                {
                    particleEffect.Pause();
                }
                particleTimer = 0f;
            }
        }
    }
}
