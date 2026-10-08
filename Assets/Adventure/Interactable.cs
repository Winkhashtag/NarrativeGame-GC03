using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Attributes;

public class Interactable : MonoBehaviour
{
    public YarnProject Project;

    [YarnNode("Project")]
    public string Node;
    public DialogueRunner Dialogue;

public void StartInteraction()
    {
        Debug.Log("start interaction");
        Dialogue.StartDialogue(Node);
    }
}
