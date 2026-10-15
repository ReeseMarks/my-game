using UnityEngine;

public class CameraLockX : MonoBehaviour
{
    public Transform player;
    public float orbitRadius = 10f;
    public float orbitHeight = 4f;
    public float orbitSpeed = 90f;
    private float orbitAngle;

    void Start()
    {
        if (player != null)
        {
            orbitAngle = Mathf.Atan2(transform.position.z - player.position.z, transform.position.x - player.position.x) * Mathf.Rad2Deg;
        }
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        if (Input.GetKey(KeyCode.A))
        {
            orbitAngle += orbitSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            orbitAngle -= orbitSpeed * Time.deltaTime;
        }

        float x = player.position.x + Mathf.Cos(orbitAngle * Mathf.Deg2Rad) * orbitRadius;
        float z = player.position.z + Mathf.Sin(orbitAngle * Mathf.Deg2Rad) * orbitRadius;

        transform.position = new Vector3(x, player.position.y + orbitHeight, z);
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
