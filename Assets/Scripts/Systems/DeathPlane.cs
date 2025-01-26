using System.Collections;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BurstBubble(other));
        }
    }
    private IEnumerator BurstBubble(Collider other)
    {
        other.GetComponent<BubbleMovement>().Burst();
        GameManager.ManagerInstance.BubbleBursted(true);
        yield return new WaitForSeconds(1f);
        GameManager.ManagerInstance.OnBubbleBurst?.Invoke();

    }
}
