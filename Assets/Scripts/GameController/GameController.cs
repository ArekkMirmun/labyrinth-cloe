using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public int numberOfLeversToFind;
    public GameObject doorObject;
    
    public int DecreaseAndGetNumberOfLevers()
    {
        numberOfLeversToFind--;
        return numberOfLeversToFind;
    }

    public void OpenExit()
    {
        Destroy(doorObject);
    }
}
