using UnityEngine;

public class collectable : MonoBehaviour
{
 public void Collect()
    {
        dialogue.Instance.OnCollect();
        Destroy(gameObject);
    }
}
