using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PathPointParent pathPointParent;

    private int numberOfStepsAlreadyMoved;

    public DiceGenerator diceGenerator;

    private void Awake()
    {
        pathPointParent = Object.FindFirstObjectByType<PathPointParent>();
    }

    public void MovePlayer(PathPoints[] _path)
    {
        StartCoroutine(MovePiece(_path));
    }

    private IEnumerator MovePiece(PathPoints[] _path)
    {

        for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + diceGenerator.diceNumber); i++)
        {
            transform.position = _path[i].transform.position;
            yield return new WaitForSeconds(0.5f);
        }

        numberOfStepsAlreadyMoved += diceGenerator.diceNumber;

        TurnManager.Instance.EndTurn();
    }
}
