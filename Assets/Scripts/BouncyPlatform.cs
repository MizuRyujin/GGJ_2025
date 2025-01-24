using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private float _bounceStrenght;

    private void OnCollisionEnter(Collision other)
    {
        other.collider.attachedRigidbody.AddForce(0, _bounceStrenght, 0);
    }
}
