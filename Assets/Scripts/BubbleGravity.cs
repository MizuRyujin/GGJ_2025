using UnityEngine;

public class BubbleGravity : MonoBehaviour
{
    [SerializeField] private float _customGrav;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        // Add custom gravity to Rigidbody's current velocity
        _rb.linearVelocity += new Vector3(
            0, _customGrav, 0) * Time.fixedDeltaTime; 
    }
}
