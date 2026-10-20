using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public InputActionReference Move;

    public bool IsTankControls;

    public Camera camera;
   
    bool allowMove;
 
    private void Update()
    {

    float delta = Time.deltaTime;
    Vector2 move = Move.action.ReadValue<Vector2>();

        if (IsTankControls)
      {
    if (!dialogue.Instance.Runner.IsDialogueRunning) 
        {
            
            //moving towards the forward transform position
            transform.position += transform.forward * speed * move.y * delta;  
          //rotate around the given axis however much is wanted //rotating up axis means rotating on the ground
            transform.Rotate(Vector3.up, rotationSpeed * move.x * delta); 
        }
    }
        else
        {
           Vector3 forward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
           Vector3 right = Vector3.ProjectOnPlane(camera.transform.right, Vector3.up);

           //transform.position += move.y * speed * delta * forward;
          // transform.position += move.x * speed * delta * right;

          Vector3 moveDir = move.y * forward + move.x * right;

          transform.position += moveDir * speed * delta;
          transform.forward = Vector3.RotateTowards(transform.forward, moveDir, Mathf.Deg2Rad * rotationSpeed * delta, 0f);
        }
     //   dialogue.Instance.Runner.onDialogueComplete.AddListener(onDialogueComplete)

       // if (dialogue.Instance.Runner.IsDialogueRunning == false) 
        
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
