using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public InputActionReference Move;

    private void Update()
    {
        float delta = Time.deltaTime;
        Vector2 move = Move.action.ReadValue<Vector2>();
        //moving towards the forward transform position
        transform.position += transform.forward * speed * move.y * delta;  //
         //rotate around the given axis however much is wanted //rotating up axis means rotating on the ground
        transform.Rotate(Vector3.up, rotationSpeed * move.x * delta);  
    }

    private void OnTriggerEnter(Collider collision)
    {
        Interactable other = collision.gameObject.GetComponent<Interactable>();
            if (other)
        {
            other.StartInteraction();
        }
    }
}
