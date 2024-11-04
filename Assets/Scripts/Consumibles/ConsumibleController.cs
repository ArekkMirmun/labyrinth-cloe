using System.Collections;
using UnityEngine;

public class ConsumibleController : MonoBehaviour
{
    
    public CharacterController characterController;
    public SanityController sanityController;
    public int sanityToRestore;
    public AudioSource eatingSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            eatingSound.Play();
            RestoreSanity();
        }
    }

    private void RestoreSanity()
    {
        sanityController.ConsumibleEvent(sanityToRestore);
        Destroy(this.gameObject, 0.2f);
    }
}
