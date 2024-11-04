using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource stepsSound;
    public CharacterController characterController;
    [SerializeField] private bool characterWalking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        characterWalking = characterController.IsMoving();
        if (characterWalking)
        {
            EnableFootsteps();
        }
        else
        {
            DisableFootsteps();
        }
    }

    void EnableFootsteps()
    {
        if (!stepsSound.isPlaying)
        {
            stepsSound.Play();
        }
    }

    void DisableFootsteps()
    {
        stepsSound.Pause();
    }
}
