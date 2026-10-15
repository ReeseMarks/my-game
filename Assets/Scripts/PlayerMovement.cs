using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Class Level Variables
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (mainCamera != null)
        {
            Vector3 cameraForward = Vector3.ProjectOnPlane(mainCamera.transform.forward, Vector3.up);
            Vector3 cameraRight = Vector3.ProjectOnPlane(mainCamera.transform.right, Vector3.up);

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                moveDirection += cameraForward.normalized;
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                moveDirection -= cameraForward.normalized;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDirection -= cameraRight.normalized;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection += cameraRight.normalized;
            }
        }

        if (moveDirection != Vector3.zero)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
