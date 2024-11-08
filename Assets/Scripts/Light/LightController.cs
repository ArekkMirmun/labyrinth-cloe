using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    
    public Light2D light;
    public bool enabled;
    public float delay;
    public int intensity;
    public bool destroyOnTrigger;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (destroyOnTrigger)
            {
                delay += 0.2f;
            }
            
            StartCoroutine(ChangeLightIntensity());
        }
    }

    private IEnumerator ChangeLightIntensity()
    {
        
        yield return new WaitForSeconds(delay);
        light.intensity = enabled ? intensity : 1;
        if (destroyOnTrigger)
        {
           Destroy(this.gameObject);
        }
    }
}
