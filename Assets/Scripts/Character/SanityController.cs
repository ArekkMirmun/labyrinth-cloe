using System.Collections;
using TMPro;
using UnityEngine;

public class SanityController : MonoBehaviour
{
    private int _sanity;
    private float _sanityTimer;
    private bool _timerRunning;

    public float timeToSanityDecrease;
    public int percentageOfSanityDecrease; 
    public CharacterController characterController;
    public int paranormalActivitySanityDecrease;
    
    public TextMeshProUGUI sanityText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sanity = 100;
        UpdateSanityText();
        _timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Stop update execution if timer not running
        if (!_timerRunning) return;
        
        //Each timeToSanityDecrease seconds, we execute the DecreaseSanity method
        if (_sanityTimer > 0)
        {
            _sanityTimer -= Time.deltaTime;
        }
        else
        {
            _timerRunning = false;
            DecreaseSanity(percentageOfSanityDecrease);
        }
    }

    //Function that decreases the sanity given the percentageOfSanityDecrease value.
    void DecreaseSanity(int sanityDecrease)
    {
        _sanity -= sanityDecrease;
        UpdateSanityText();
        if (_sanity > 0)
        {
            ResetSanityTimer();
        }
        else
        {
            GameOver();
        }
    }

    public void ParanormalEvent()
    {
        DecreaseSanity(paranormalActivitySanityDecrease);
    }

    public void ConsumibleEvent(int sanityIncrease)
    {
        IncreaseSanity(sanityIncrease);
    }

    void IncreaseSanity(int sanityIncrease)
    {
        _timerRunning = false;
        _sanity += sanityIncrease;
        UpdateSanityText();
        _timerRunning = true;
    }

    //Function executed when sanity hits 0 or less
    private void GameOver()
    {
        Destroy(characterController.gameObject);
    }
    
    void ResetSanityTimer()
    {
        _sanityTimer = timeToSanityDecrease;
        _timerRunning = true;
    }

    public int GetSanity()
    {
        return _sanity;
    }

    public void UpdateSanityText()
    {
        sanityText.text = "Sanity: "+ _sanity.ToString()+ "%";
    }
    
    private void Awake()
    {
        int numInstancias = FindObjectsByType<SanityController>(FindObjectsSortMode.None).Length;
        if (numInstancias > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
