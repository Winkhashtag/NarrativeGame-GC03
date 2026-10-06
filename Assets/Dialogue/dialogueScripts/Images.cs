using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Images", menuName = "Scriptable Objects/Images")]
public class Images : ScriptableObject
{
    public Image _image;
    public string _description;
    public AudioSource _audio;
    public Image _BKG;

}
