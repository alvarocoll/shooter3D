
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterPlayer : MonoBehaviour
{
   private Vector2 movimiento;
   public Rigidbody rb;
   public float speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 velocity = new Vector3(movimiento.x * speed, 0, movimiento.y * speed);

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }

  
    public void OnMove (InputAction.CallbackContext context)
    {
        movimiento = context.ReadValue<Vector2>();
    }
}
