using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BubbleState : MonoBehaviour
{
    public float BubbleStrenght { get; set; }
    [SerializeField] private float _boostCost;
    [SerializeField] private Image _bubbleStrenghtBar;
    private BubbleMovement _bubbleMovement;

    private void Awake()
    {
        _bubbleMovement = GetComponent<BubbleMovement>();
        BubbleStrenght = 100f;
    }

    // Update is called once per frame
    private void Update()
    {

        if (BubbleStrenght <= 0f)
        {
            StartCoroutine(BurstBubble());
        }

        if (!_bubbleMovement.Paused)
        {
            BubbleStrenght -= 1f * Time.deltaTime;
            // _bubbleStrenghtBar.fillAmount -= 
            UseBoost();
        }

    }

    private void UseBoost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BubbleStrenght -= _boostCost;
        }
    }

    private IEnumerator BurstBubble()
    {
        Debug.Log("Busrt Corotine");
        BubbleStrenght = 100f;
        GameManager.ManagerInstance.BubbleBursted(true);
        _bubbleMovement.GetComponent<BubbleMovement>().Burst();
        yield return new WaitForSeconds(1f);
        GameManager.ManagerInstance.OnBubbleBurst?.Invoke();
    }
}
