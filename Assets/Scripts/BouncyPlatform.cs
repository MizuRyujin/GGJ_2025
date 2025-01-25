using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private float _bounceStrenght;
    private Animator _animator;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        other.collider.attachedRigidbody.AddForce(0, _bounceStrenght, 0);
        _animator.SetTrigger("Bounce");
    }
}
