using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed; // m/s
    private CharacterController controller;
    private Vector3 movement = new Vector3();
    private Vector2 mouseScreen = new Vector2();

    private Plane plane = new Plane(Vector3.up, Vector3.zero);
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Assert.IsNotNull(controller, "PlayerController needs a CharacterController");
    }

    // Update is called once per frame
    void Update()
    {
        // Find Rotation using mouse coordinate
        var ray = Camera.main.ScreenPointToRay(mouseScreen);
        if (plane.Raycast(ray, out var enter))
        {
            var hitPoint = ray.GetPoint(enter);
            Vector3 playerPositionOnPlane = plane.ClosestPointOnPlane(gameObject.transform.position);
            Vector3 forward = hitPoint - playerPositionOnPlane;
            gameObject.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }

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
        if (context.performed)
        {
            mouseScreen = context.ReadValue<Vector2>();
        }
    }
}
