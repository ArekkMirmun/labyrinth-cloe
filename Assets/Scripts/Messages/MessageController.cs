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
        Destroy(terrorMessageTrigger);
        characterController.FreezeCharacter();
        Destroy(terrorMessage, 1.9f);

        terrorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        characterController.UnFreezeCharacter();
        executed = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

         Debug.Log(other.gameObject.name);
         print(terrorMessage.name);
         print(terrorMessageTrigger.name);
         if (!executed && other.gameObject.CompareTag("Player"))
         {
             StartCoroutine(ShowTerrorMessage());
         }
    }
    
    
}
