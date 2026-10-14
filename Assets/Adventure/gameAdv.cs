using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class gameAdv : MonoBehaviour
{
    public AudioSource sfx;
    public List<AudioClip> sfxOptions;
    public AudioSource bgMusic;
    public List<AudioClip> bgMusicOptions;

    [YarnCommand("play_sfx2")]
    public void SFX(int index)
    {
        sfx.PlayOneShot(sfxOptions[index]);
        Debug.Log("played SFX " + index);
    }

    [YarnCommand("play_BGM2")]
    public void BGMusic(int index)
    {
        bgMusic.clip = bgMusicOptions[index];
        bgMusic.Play();
        Debug.Log("played BGM " + index);
    }

}
