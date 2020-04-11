using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class SimpleMove : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float horizontalSpeed = 1.0f;
    public float verticalSpeed = 5.0f;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed;
        float vertical = verticalSpeed;

        transform.Rotate(new Vector3(vertical, 0, horizontal));
        controller.SimpleMove(new Vector3(horizontal, 0.0f, vertical));
    }
}
