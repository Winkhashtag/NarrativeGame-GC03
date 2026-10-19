using Unity.Cinemachine;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Attributes;

public class Interactable : MonoBehaviour
{
    public YarnProject Project;
    public CinemachineCamera camera;

    [YarnNode("Project")]
    public string Node;
    void Start()
    {
        DialogueRunner runner = dialogue.Instance.Runner;
        dialogue.Instance.Runner.onDialogueComplete.AddListener(OnDialogueComplete);
    }
    public void StartInteraction()
    {
        Debug.Log("start interaction");
        dialogue.Instance.Runner.StartDialogue(Node);

        camera.gameObject.SetActive(true);
    }

  void OnDialogueComplete()
    {
        Debug.Log($"dialogue completed for {name}");
        camera.gameObject.SetActive(false);
    }

}
