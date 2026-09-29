using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public InputActionReference Move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var move = Move.action.ReadValue<Vector2>();
        Vector3 move = Move.action.ReadValue<Vector2>();
        // if (Input.GetKeyDown(KeyCode.W))
        // if (Keyboard.current.wKey.IsPressed())

        transform.position += move * Time.deltaTime;
    }
}
