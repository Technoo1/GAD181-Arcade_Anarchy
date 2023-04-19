using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public IEnumerator Shake ()
    {
        float duration = 0.6f;
        float magnitude = 0.2f;
        Debug.Log("ScreenShake has been called");
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void ShakeScreen()
    {
        StartCoroutine(Shake());
    }
}
