using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    private Transform _transform;
    private Rigidbody _rb;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveBubble();
        RotateBubble();
    }

    private void MoveBubble()
    {
        Vector3 newPos = Vector3.zero;
        if (Input.GetAxis("Horizontal") != 0)
        {
            newPos += _transform.right * Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            newPos += _transform.forward * Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        }
        _rb.linearVelocity += newPos;
    }

    private void RotateBubble()
    {
        float yRot = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;

        if (Input.GetAxis("Mouse X") != 0)
        {
            _rb.rotation *= Quaternion.Euler(0, yRot, 0);
        }
    }
}
