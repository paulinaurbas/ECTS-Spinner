using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class SimpleMove : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float horizontalSpeed = 0.5f;
    public float verticalSpeed = 5.0f;
    private GameObject _cylinder;

    private void Start()
    {
        _cylinder = GameObject.FindGameObjectWithTag("cylinderMain");
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed;
        float vertical = verticalSpeed;

        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, vertical);
        _cylinder.transform.RotateAround(new Vector3(0, 0, 1), horizontal);
        //controller.SimpleMove(new Vector3(horizontal, 0.0f, vertical));
    }
}
