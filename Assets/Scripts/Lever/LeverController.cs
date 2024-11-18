using UnityEngine;

public class LeverController : MonoBehaviour
{

    private bool _used;
    public Sprite leverTriggeredSprite;
    public SpriteRenderer leverSprite;
    public bool triggerAble = false;
    public GameObject keyHint;
    private GameController gc;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyHint.SetActive(false);
        gc = FindObjectsByType<GameController>(FindObjectsSortMode.None)[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_used && triggerAble && Input.GetKeyDown(KeyCode.E))
        {
            _used = true;
            leverSprite.sprite = leverTriggeredSprite;
            DecreaseRemainingLevers();
        }
    }

    void DecreaseRemainingLevers()
    {
        print("Lever used");
        
        int remainingLevers = gc.DecreaseAndGetNumberOfLevers();
        
        if (remainingLevers == 0)
        {
            OpenExit();
        }
    }

    private void OpenExit()
    {
        print("Open exit");
        
        gc.OpenExit();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!_used && other.gameObject.CompareTag("Player"))
        {
            keyHint.SetActive(true);
            triggerAble = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        keyHint.SetActive(false);
        triggerAble = false;
    }
}
