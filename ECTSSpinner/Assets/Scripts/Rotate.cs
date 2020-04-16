using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate(rotateSpeed, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        controller.SimpleMove(new Vector3(0.0f, 0.0f, 0.0f));
    }
}
