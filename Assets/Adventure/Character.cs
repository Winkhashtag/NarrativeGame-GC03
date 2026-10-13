using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public InputActionReference Move;
   
    bool allowMove;
 
    private void Update()
    {
     //   dialogue.Instance.Runner.onDialogueComplete.AddListener(onDialogueComplete)

       // if (dialogue.Instance.Runner.IsDialogueRunning == false) 
        if (!dialogue.Instance.Runner.IsDialogueRunning) 
        {
            float delta = Time.deltaTime;
            Vector2 move = Move.action.ReadValue<Vector2>();
            //moving towards the forward transform position
            transform.position += transform.forward * speed * move.y * delta;  
          //rotate around the given axis however much is wanted //rotating up axis means rotating on the ground
            transform.Rotate(Vector3.up, rotationSpeed * move.x * delta); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.gameObject.GetComponent<Interactable>();
        if (interactable)
        {
            interactable.StartInteraction();
            allowMove = false;
            Debug.Log("Stopped moving");
        }
        

        collectable collectable = other.gameObject.GetComponent<collectable>();
        if (collectable)
        {
            collectable.Collect();
        }
    }
}
