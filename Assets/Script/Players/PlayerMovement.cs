using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PathPointParent pathPointParent;

    private int diceNumber;
    private int numberOfStepsAlreadyMoved;

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
        diceNumber = 50;

        for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + diceNumber); i++)
        {
            transform.position = _path[i].transform.position;
            yield return new WaitForSeconds(0.5f);
        }

        numberOfStepsAlreadyMoved += diceNumber;
    }
}
