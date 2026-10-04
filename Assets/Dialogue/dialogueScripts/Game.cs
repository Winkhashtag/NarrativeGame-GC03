using UnityEngine;
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

  
}
