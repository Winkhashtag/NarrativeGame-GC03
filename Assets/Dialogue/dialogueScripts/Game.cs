using UnityEngine;
using System.Collections;
using Yarn.Unity;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;
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

    [SerializeField] private Image Co_image;

    [YarnCommand("image_Coroutine")]
    public static Coroutine ImageCoroutine(float duration)
    {
        return Instance.StartCoroutine(ImageRoutine(duration));
    }
    private static IEnumerator ImageRoutine(float duration)
    {
        Debug.Log("message");
        Instance.Co_image.enabled = true;
        yield return new WaitForSeconds(duration);
        Instance.Co_image.enabled = false;
        Debug.Log("2 seconds");
    }

    public RawImage _image;
    public List<RawImage> _imageList;

    [YarnCommand("img_ctrl")]
    public static void ImageControl(int index)
    {
        Instance._image.texture = Instance._imageList[index].texture;
        Instance._image.gameObject.SetActive(true);
        Instance._image.enabled = true;

    }

    public AudioSource sfx;
    public List<AudioClip> sfxOptions;
    public AudioSource bgMusic;
    public List<AudioClip> bgMusicOptions;

    [YarnCommand("play_sfx")]
    public static void SFX(int index)
    {
        Instance.sfx.PlayOneShot(Instance.sfxOptions[index]);
        Debug.Log("played SFX " + index);
    }

    [YarnCommand("play_BGM")]
    public static void BGMusic(int index)
    {
        Instance.bgMusic.clip = Instance.bgMusicOptions[index];
        Instance.bgMusic.Play();
        Debug.Log("played BGM " + index);
    }

}
