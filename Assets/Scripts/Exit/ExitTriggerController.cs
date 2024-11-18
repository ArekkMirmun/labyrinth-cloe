using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTriggerController : MonoBehaviour
{
    public SceneController sceneController;
    
    // declare the enum somewhere visible
    public enum MyEnumeratedType 
    {
        Forest, Another
    }

// in your script, declare a public variable of your enum type
    public MyEnumeratedType option;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        switch (option)
        {
            case MyEnumeratedType.Forest: 
                sceneController.LoadForestLevel();
                break;
            case MyEnumeratedType.Another:
                throw new NotImplementedException();
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }
}
