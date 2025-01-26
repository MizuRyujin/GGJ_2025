using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _customGrav;
    private MeshRenderer _renderer;
    private Transform _transform;
    private Rigidbody _rb;
    private RigidbodyConstraints _rbConstraints;
    private Vector3 _velocityOnPause;
    private Vector3 _startPosition;
    private bool _paused;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _renderer = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _rbConstraints = _rb.constraints;
        _paused = true;
        _startPosition = _transform.position;
        GameManager.ManagerInstance.OnPauseGame += PauseBubble;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(_transform.up * 100f);
        }
    }

    private void FixedUpdate()
    {
        //! Should lock _rb position and perseve velocity value when pause
        if (_paused) return;
        ApplyGravity();
        MoveBubble();
        RotateBubble();

    }

    public void StartMove()
    {
        _paused = false;
        _rb.AddForce(_transform.up * 100);
    }

    public void Restart()
    {
        _rb.MovePosition(_startPosition);
        _transform.localScale = Vector3.zero;
        _renderer.enabled = true;

    }

    public void Burst()
    {
        // _paused = true;
        // _renderer.enabled = false;
        // _rb.linearVelocity = Vector3.zero;
    }

    private void ApplyGravity()
    {
        // Add custom gravity to Rigidbody's current velocity
        _rb.linearVelocity += new Vector3(
            0, _customGrav, 0) * Time.fixedDeltaTime;
    }

    private void MoveBubble()
    {
        //! Should have max vel
        Vector3 newVelocity = Vector3.zero;
        if (Input.GetAxis("Horizontal") != 0f)
        {
            newVelocity += _transform.right * Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
        }
        if (Input.GetAxis("Vertical") != 0f)
        {
            newVelocity += _transform.forward * Input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;
        }
        _rb.linearVelocity += newVelocity;
    }

    private void RotateBubble()
    {
        float yRot = Input.GetAxis("Mouse X") * _rotationSpeed * Time.fixedDeltaTime;

        if (Input.GetAxis("Mouse X") != 0f)
        {
            _rb.rotation *= Quaternion.Euler(0f, yRot, 0f);
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
        }
    }

    private void PauseBubble()
    {
        _paused = !_paused;
        if (_paused)
        {
            _velocityOnPause = _rb.linearVelocity;
            _rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            _rb.linearVelocity = _velocityOnPause;
            _rb.constraints = _rbConstraints;
        }
    }

}
