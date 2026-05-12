using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.up * 100f * Time.deltaTime; 
    }
}
