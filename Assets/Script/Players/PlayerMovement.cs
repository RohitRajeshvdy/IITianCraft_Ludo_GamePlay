using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private PlayerColor playerColor;
    [SerializeField] private int playerID;

    private PathPointParent pathPointParent;
    private int diceNumber;
    private int numberOfStepsAlreadyMoved;
    private int startingPathIndex;

    private void Awake()
    {
        pathPointParent = Object.FindFirstObjectByType<PathPointParent>();
        startingPathIndex = (playerID * 13) + 1;
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
            int currentPathIndex = (startingPathIndex + numberOfStepsAlreadyMoved + i) % pathPointParent.OuterPathPoints.Length;
            transform.position = pathPointParent.OuterPathPoints[currentPathIndex].transform.position;
            yield return new WaitForSeconds(0.5f);
        }

        numberOfStepsAlreadyMoved += diceNumber;
    }
}