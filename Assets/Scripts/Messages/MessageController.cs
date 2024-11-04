using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{

    public GameObject terrorMessage;
    public GameObject terrorMessageTrigger;
    public CharacterController characterController;
    public SanityController sanityController;
    public bool executed = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        terrorMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowTerrorMessage()
    {
        sanityController.ParanormalEvent();
        Destroy(terrorMessageTrigger);
        characterController.FreezeCharacter(1.8f);
        Destroy(terrorMessage, 1.9f);

        terrorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        executed = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
         if (!executed && other.gameObject.CompareTag("Player"))
         {
             StartCoroutine(ShowTerrorMessage());
         }
    }
    
    
}
