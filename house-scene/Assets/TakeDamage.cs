using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamage : MonoBehaviour
{
    public float intensity = 0;
    PostProcessVolume _volume;
    Vignette _vignette;
    public GameObject player;
    public GameObject crawler;

    private bool isDamageEffectActive = false;

    void Start()
    {
        
        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);
        if (!_vignette)
        {
            Debug.LogError("Vignette not found!");
        }
        else
        {
            _vignette.enabled.Override(false);
        }
    }

    void Update()
    {
        if (player != null && player.activeSelf && !isDamageEffectActive)
        {
            if (crawler != null)
            {
                float distanceToPlayer = Vector3.Distance(player.transform.position, crawler.transform.position);
                if (distanceToPlayer < 6.0f)
                {
                    Debug.Log("start damage");
                    StartCoroutine(StartTakeDamageEffect());
                }
            }
        }
        else if (!player.activeSelf)
        {
            Debug.LogError("Player object is not active!");
        }
    }

    private IEnumerator StartTakeDamageEffect()
    {
        isDamageEffectActive = true;
        yield return StartCoroutine(TakeDamageEffect());
        isDamageEffectActive = false;
    }

    private IEnumerator TakeDamageEffect()
    {
        intensity = 0.6f;

        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.6f);
        yield return new WaitForSeconds(0.4f);
        while (intensity > 0)
        {
            intensity -= 0.08f;
            if (intensity < 0)
            {
                intensity = 0;
            }
            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.1f);
        }
        _vignette.enabled.Override(false);
    }
}
