using UnityEngine;

public class footsteps : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource footstepSource;
    public AudioClip[] footstepClips;
    public float stepInterval = 0.5f;
    private float footstepTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded &&  controller.velocity.magnitude>1f)
        {
            footstepTime += Time.deltaTime;
            if (footstepTime > stepInterval )
            {
                PlayFootstep();
                footstepTime = 0f;
            }
        }
        else
        {
            footstepTime = 0f;
        }
    }
    void PlayFootstep()
    {
        if ( footstepClips.Length > 0)
        {
            footstepSource.clip = footstepClips[Random.Range(0, footstepClips.Length)];
                footstepSource.Play();
        }
    }
}
