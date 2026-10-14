using UnityEngine;
using Yarn.Unity;

public class dialogue : MonoBehaviour
{
    const string k_CollectableVariableName = "$collectables";
    const string k_candy = "$candy";
    public static dialogue Instance;

    public DialogueRunner Runner;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnCollect()
    {
        //increment the $collectable variable by 1
        VariableStorageBehaviour variableStorage = Runner.VariableStorage; //able to send the variables to Yarn

        //usually Try functions return a bool, and sets an "out parameter"
        //you would expect something like this if it was a get value function
        //float currentCount = variableStorage.GetValue("$collectable")
        bool hasValue = variableStorage.TryGetValue(k_CollectableVariableName, out float collectables);

        collectables += 1;

        variableStorage.SetValue(k_CollectableVariableName, collectables);

        bool hasValue2 = variableStorage.TryGetValue(k_candy, out float candy);

        candy += 1;

        variableStorage.SetValue(k_candy, candy);
    }

    public void StartNode(string node)
    {
        Runner.StartDialogue(node);
    }

   
}
