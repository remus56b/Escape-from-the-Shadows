using UnityEngine;
//marea schimbare

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

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }

        if (audioSource == null)
        {
            // Dacă componenta AudioSource este lipsă, încercă să o găsești pe acest obiect
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing!");
            }
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
                
            }
            else
            {
                animator.SetBool("isJumping", false);
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogError("Reference to HandsManager, crawler Transform, or AudioSource is missing!");
        }
    }
}
