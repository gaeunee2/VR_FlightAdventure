using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength = 100f;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //Enable
    private void OnEnable()
    {
        thrust.Enable();
    }
    private void FixedUpdate()
    {
        if(thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
}
