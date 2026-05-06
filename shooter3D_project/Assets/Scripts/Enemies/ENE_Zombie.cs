using UnityEngine;

public class ENE_Zombie : MonoBehaviour
{
    private ShooterPlayer _player;

    void Start()
    {
        _player = FindFirstObjectByType<ShooterPlayer>();
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
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
}
