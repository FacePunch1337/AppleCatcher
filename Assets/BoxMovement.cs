using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Rigidbody boxRigidbody;

    private void Awake()
    {
        boxRigidbody = GetComponent<Rigidbody>();
        boxRigidbody.constraints = RigidbodyConstraints.FreezePositionZ; // Замораживаем позицию по оси Z
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * movementSpeed;

        Vector3 velocity = new Vector3(movement, 0f, 0f);
        boxRigidbody.velocity = velocity;
    }
}
