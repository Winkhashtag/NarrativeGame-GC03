using UnityEngine;
using System.Collections;
using Yarn.Unity;
public class Game : MonoBehaviour
{
   public static Game Instance { get; private set; }


    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
                return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

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

        while (time < duration) //as long as its running
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration); //lerp the values
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }
}
