
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShooterPlayer : MonoBehaviour
{
   private Vector2 movimiento;
   private Vector2 mouseDelta;
   public SkinnedMeshRenderer mesh;
   public UImanager uiManager;
    public Animator animator;
    [Header("Parameters")]
  public Rigidbody rb;
  public float speed = 5;
  public LayerMask groundLayer;
  [Header ("Shooting")]
   public Bullet bulletPrefab;
   public Transform spawnPoint;

  [Header("Live")]
    public int lives = 3;
    private bool _canGetHit = true;
    private float _noHitTime = 2f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        uiManager.SetNewLife(lives);
    }

    private void Update()
    {

        if (lives <= 0)
        {
            return;
        }
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, groundLayer))
        {
            Vector3 hitPoint = hit.point;
            transform.forward = hitPoint - transform.position;
        }

        animator.SetFloat("speed_anim", movimiento.magnitude);

        if (!_canGetHit)
        {
            _noHitTime -= Time.deltaTime;
            if (_noHitTime <= 0)
            {
                _canGetHit = true;
                Material material = new Material(mesh.material);
                material.color = Color.white;
                mesh.material = material;
                _noHitTime = 2f;
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ENE_Zombie>())
        {
          
            uiManager.AddScore(10);
            Destroy(collision.gameObject);
            if (_canGetHit)
            {
                _canGetHit = false;
                animator.SetTrigger("react");
                lives--;
                uiManager.SetNewLife(lives);
                Material material = new Material(mesh.material);
                material.color = Color.red;
                mesh.material = material;
                if (lives <= 0)
                {
                    uiManager.ShowEndGame();
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
           
        }
    }

    /*public void OnLook (InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }*/
}
