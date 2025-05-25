using UnityEngine;
using System.Collections;


public class fadeOutScript : MonoBehaviour
{
    
    void OnEnable()
    {
        
        SpriteRenderer originColor = GetComponent<SpriteRenderer>();
        // originColor.a = 1f; doesnt work because its a sprite renderer, must use conver to color and back again
        Color tempColor = originColor.color;
        tempColor.a = 1f;
        originColor.color = tempColor; 
        StartCoroutine(fadeOverTime(originColor,originColor.color, new Color(1f, 1f, 1f, 0f), 5f));
        
    }

    IEnumerator fadeOverTime(SpriteRenderer originColor, Color startColor, Color endColor, float duration)
    {

        
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            originColor.color = Color.Lerp(startColor, endColor, normalizedTime);
            yield return null;
        }
       
        
    }
}
