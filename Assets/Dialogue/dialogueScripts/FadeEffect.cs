using System.Collections;
using UnityEngine;
using Yarn.Unity; 

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [YarnCommand("fade")]
    public Coroutine FadeScreen(float targetAlpha, float duration)
    {
        //wait for finish
        return StartCoroutine(FadeRoutine(targetAlpha, duration));
    }

    private IEnumerator FadeRoutine(float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }
}