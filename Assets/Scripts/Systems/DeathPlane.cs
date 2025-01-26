using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BubbleMovement>().Burst();
            GameManager.ManagerInstance.OnBubbleBurst?.Invoke();
        }    
    }
}
