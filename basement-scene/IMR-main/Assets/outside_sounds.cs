using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outside_sounds : MonoBehaviour
{
    public AudioSource[] audioSources; 

    void Start()
    {
        if (audioSources.Length == 3) 
        {
            StartCoroutine(PlayContinuousSounds());
        }
        else
        {
            Debug.LogError("Trebuie să aveți exact 3 surse audio în vectorul audioSources!");
        }
    }

    IEnumerator PlayContinuousSounds()
    {
        while (true)
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.Play();

                yield return new WaitForSeconds(audioSource.clip.length);
            }
        }
    }

    void Update()
    {
    }
}
