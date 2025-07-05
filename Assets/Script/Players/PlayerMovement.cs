using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private PlayerColor playerColor; // enum for colors
    [SerializeField] private int playerID; // 0, 1, 2, 3 for four players

    private PathPointParent pathPointParent;
    private Camera mainCamera;

    private int diceNumber;
    private int numberOfStepsAlreadyMoved;
    private int startingPathIndex;

    private void Awake()
    {
        pathPointParent = Object.FindFirstObjectByType<PathPointParent>();
        mainCamera = Camera.main;
        SetStartingPathIndex();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            CheckClick();
        }
    }

    private void SetStartingPathIndex()
    {
        // Set different starting positions for each player
        // Assuming each player starts 13 positions apart (52 total positions / 4 players)
        startingPathIndex = (playerID * 13) + 1;
    }

    private void CheckClick()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
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