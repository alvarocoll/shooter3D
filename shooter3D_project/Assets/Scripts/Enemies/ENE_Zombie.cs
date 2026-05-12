using UnityEngine;

public class ENE_Zombie : MonoBehaviour
{
    private ShooterPlayer _player;
    private UImanager uiManager;

    void Start()
    {
        _player = FindFirstObjectByType<ShooterPlayer>();
        uiManager = FindFirstObjectByType<UImanager>();

    }

    
    void Update()
    {
        transform.forward = _player.transform.position - transform.position;
        transform.position += transform.forward * 3 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Bullet>())
        {
            uiManager.AddScore(100);
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
}
