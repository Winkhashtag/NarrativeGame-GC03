using UnityEngine;
using Yarn.Unity;

public class Interactable : MonoBehaviour
{
    public DialogueRunner Dialogue;

public void StartInteraction()
    {

        Debug.Log("start interaction");
        Dialogue.StartDialogue("Guy");
    }
}
