using TMPro;
using UnityEngine;

public class DiceGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI diceNumberText;

    public int GeneratedDiceValue;

    void OnEnable()
    {
        InputManager.OnObjectClicked += HandleClick;
    }

    void OnDisable()
    {
        InputManager.OnObjectClicked -= HandleClick;
    }

    private void HandleClick(GameObject clickedObject)
    {
        if (clickedObject == gameObject)
        {
            GeneratedDiceValue = Random.Range(1, 7);
            diceNumberText.text = GeneratedDiceValue.ToString();
        }
    }
}

