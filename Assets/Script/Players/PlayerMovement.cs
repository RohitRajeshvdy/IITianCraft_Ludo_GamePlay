using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private PlayerColor playerColor;
    [SerializeField] private PathSelection selectedPathType;

    private PathPoints[] selectedPath;

    private int diceNumber;
    private int numberOfStepsAlreadyMoved;
    private int startingPathIndex;

    private void Awake()
    {
        var pathPointParent = Object.FindFirstObjectByType<PathPointParent>();

        selectedPath = selectedPathType switch
        {
            PathSelection.Yellow => pathPointParent.YellowPathPoints,
            PathSelection.Blue => pathPointParent.BluePoints,
            PathSelection.Red => pathPointParent.RedPathPoints,
            PathSelection.Green => pathPointParent.GreenPathPoints,
            _ => pathPointParent.OuterPathPoints
        };

        startingPathIndex = 0;
    }

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
            StartCoroutine(MovePiece());
        }
    }

    private IEnumerator MovePiece()
    {
        diceNumber = 4;

        for (int i = 0; i < diceNumber; i++)
        {
            int currentPathIndex = (startingPathIndex + numberOfStepsAlreadyMoved + i) % selectedPath.Length;
            transform.position = selectedPath[currentPathIndex].transform.position;
            yield return new WaitForSeconds(0.5f);
        }

        numberOfStepsAlreadyMoved += diceNumber;
    }
}

public enum PathSelection
{
    Yellow,
    Blue,
    Red,
    Green
}
public enum PlayerColor
{
    Yellow,
    Blue,
    Red,
    Green
}

