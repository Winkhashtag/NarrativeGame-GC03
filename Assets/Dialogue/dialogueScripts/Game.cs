using UnityEngine;
using System.Collections;
using Yarn.Unity;
using Unity.VisualScripting;
using UnityEngine.UI;
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


        _image.enabled = false;
      
        
    
}

    [SerializeField] private CanvasGroup _fade;

  
    [YarnCommand("fade")]
    public static Coroutine FadeScreen(float targetAlpha, float duration)
    {
        //wait for finish
        return Instance.StartCoroutine(Instance.FadeRoutine(targetAlpha, duration));
    }

    private IEnumerator FadeRoutine(float targetAlpha, float duration)
    {
        float startAlpha = _fade.alpha;
        float time = 0;

        while (time < duration) //as long as its running
        {
            time += Time.deltaTime;
            _fade.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration); //lerp the values
            yield return null;
        }

        _fade.alpha = targetAlpha;
    }

    [SerializeField] private Image _image;

    [YarnCommand("image_Coroutine")]
    public static Coroutine ImageCoroutine(float duration)
    {
        return Instance.StartCoroutine(ImageRoutine(duration));
    }
    private static IEnumerator ImageRoutine(float duration)
    {
        Debug.Log("message");
        Instance._image.enabled = true;
        yield return new WaitForSeconds(duration);
        Instance._image.enabled = false;
        Debug.Log("2 seconds");
    }

    [YarnCommand("image_enable")]
    public static void ImageOn(GameObject image)
    {

    }    
}
