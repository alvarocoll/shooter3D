using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public ShooterPlayer player;
  public Vector3 offset;
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
