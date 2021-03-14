using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f; // m/s
    private CharacterController controller;
    private Vector3 movement = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Assert.IsNotNull(controller, "PlayerController needs a CharacterController");
    }

    // Update is called once per frame
    void Update()
    {
        // apply movement every frame
        Vector3 velocity = movement * speed;
        controller.SimpleMove(velocity);
    }

    public void onMovementInput(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            Vector2 input = context.ReadValue<Vector2>();
            movement.x = input.x;
            movement.y = 0;
            movement.z = input.y; // forward is controlled by y input axis
        }
    }

    public void onAimInput(InputAction.CallbackContext context)
    {

    }
}
