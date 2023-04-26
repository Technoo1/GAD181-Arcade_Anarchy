using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.05f;

    public void ShakeScreen()
    {
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = originalPos.x + Mathf.PerlinNoise(0f, Time.time * 10f) * 2f - 1f;
            float y = originalPos.y + Mathf.PerlinNoise(Time.time * 10f, 0f) * 2f - 1f;
            float z = originalPos.z;

            transform.position = new Vector3(x, y, z) * shakeIntensity;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos;
    }
}
