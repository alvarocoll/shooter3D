
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterPlayer : MonoBehaviour
{
   private Vector2 movimiento;
   private Vector2 mouseDelta;
   public Rigidbody rb;
   public float speed = 5;
    public LayerMask groundLayer;
  [Header ("Shooting")]
   public Bullet bulletPrefab;
   public Transform spawnPoint;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, groundLayer))
        {
            Vector3 hitPoint = hit.point;
            transform.forward = hitPoint - transform.position;
        }
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

    public void OnClick (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPoint.position;
            bullet.transform.up = transform.forward;
        }
    }

    /*public void OnLook (InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }*/
}
