using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Random_Dice_Generator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI diceNumberYellow;
    [SerializeField] private TextMeshProUGUI diceNumberBlue;
    [SerializeField] private TextMeshProUGUI diceNumberRed;
    [SerializeField] private TextMeshProUGUI diceNumberGreen;

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
            
        }
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            diceNumberYellow.text = Random.Range(1, 7).ToString();
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            diceNumberBlue.text = Random.Range(1, 7).ToString();
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            diceNumberRed.text = Random.Range(1, 7).ToString();
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            diceNumberGreen.text = Random.Range(1, 7).ToString();
        }
    }
}

