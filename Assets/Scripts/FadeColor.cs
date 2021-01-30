using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeColor : MonoBehaviour
{
    public bool FadeOnAwake = false;
    public Color FinalColor = Color.clear;
    public Graphic Target;
    public float FadeInSeconds = 2;

    void Start()
    {
        if (FadeOnAwake)
        {
            StartCoroutine(fade());
        }
    }

    public void StartFade()
    {
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    {
        Color startColor = Target.color;

        float fadeTime = 0;
        while (fadeTime < FadeInSeconds)
        {
            fadeTime += Time.deltaTime;
            Target.color = Color.Lerp(startColor, FinalColor, fadeTime / FadeInSeconds);
            yield return null;
        }
    }
}
