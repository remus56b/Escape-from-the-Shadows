using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Transform handsManagerTransform;
    [SerializeField]
    private Transform crawlerTransform;
    [SerializeField]
    private float activationDistance = 5f;
    [SerializeField]
    private AudioSource audioSource; // Referință către componenta AudioSource asociată sunetului

    private bool isSoundPlaying = false;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing!");
            }
            else
            {
                audioSource.Stop();
                audioSource.loop = true; // Facem sunetul să se repete
            }
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }
    }

    void Update()
    {
        if (handsManagerTransform != null && crawlerTransform != null)
        {
            float distance = Vector3.Distance(handsManagerTransform.position, crawlerTransform.position);

            if (distance < activationDistance)
            {
                animator.SetBool("isJumping", true);
                if (isSoundPlaying == false)
                {
                    audioSource.Play();
                    isSoundPlaying = true;
                }
            }
            else
            {
                animator.SetBool("isJumping", false);
                if (isSoundPlaying == true)
                {
                    audioSource.Stop();
                    isSoundPlaying = false;
                }
            }
        }
        else
        {
            Debug.LogError("Reference to HandsManager, crawler Transform, or AudioSource is missing!");
        }
    }
}
