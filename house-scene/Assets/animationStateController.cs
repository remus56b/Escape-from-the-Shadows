using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform handsManagerTransform;
    [SerializeField] private Transform crawlerTransform;
    [SerializeField] private float activationDistance = 5f;
    [SerializeField] private AudioSource audioSource; // Referință către componenta AudioSource asociată sunetului

    private float audioDelay = 5f;
    private float currentDelay = 0f;
    private bool hasPlayedAudio = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }
    }

    private void Update()
    {
        if (handsManagerTransform != null && crawlerTransform != null)
        {
            float distance = Vector3.Distance(handsManagerTransform.position, crawlerTransform.position);

            if (distance < activationDistance)
            {
                // Setăm parametrul "isJumping" la true pentru a face animația să ruleze în mod continuu
                animator.SetBool("isJumping", true);

                if (!hasPlayedAudio)
                {
                    audioSource.Play();
                    hasPlayedAudio = true;
                }

                if (currentDelay < audioDelay)
                {
                    currentDelay += Time.deltaTime;
                }
                else
                {
                    // Resetăm variabilele pentru a permite redarea sunetului după ce s-a atins delay-ul dorit
                    currentDelay = 0f;
                    hasPlayedAudio = false;
                }
            }
            else
            {
                // Resetăm variabilele dacă jucătorul nu se află în apropiere
                currentDelay = 0f;
                hasPlayedAudio = false;

                //// Setăm parametrul "isJumping" la false pentru a opri animația
                //animator.SetBool("isJumping", false);
            }
        }
        else
        {
            Debug.LogError("Reference to HandsManager, crawler Transform, or AudioSource is missing!");
        }
    }
}
