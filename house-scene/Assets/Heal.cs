using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Heal : MonoBehaviour
{
    public float intensity = 0;
    PostProcessVolume _volume;
    Vignette _vignette;
    public GameObject player;
    public GameObject medicine;
    private bool isEffectActive = false;
    private int effectCount = 0;
    private const int maxEffectCount = 3;

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
        if (player != null && player.activeSelf)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, medicine.transform.position);

            if (distanceToPlayer < 8.0f && !isEffectActive && effectCount <= maxEffectCount)
            {
                StartCoroutine(StartHealEffect());
            }

        }
        else if (!player.activeSelf)
        {
            Debug.LogError("Player object is not active!");
        }
    }

    private IEnumerator StartHealEffect()
    {
        isEffectActive = true;
        effectCount++;
        yield return StartCoroutine(HealEffect());
        isEffectActive = false;
        if(effectCount == maxEffectCount)
        {
            medicine.SetActive(false);
        }
    }

    private IEnumerator HealEffect()
    {
        intensity = 0.6f;
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.6f);

        yield return new WaitForSeconds(0.1f);

        while (intensity > 0)
        {
            intensity -= 0.1f;
            if (intensity < 0)
            {
                intensity = 0;
            }
            _vignette.intensity.Override(intensity);

        }
        yield return new WaitForSeconds(0.1f);


        _vignette.enabled.Override(false);
    }
}
