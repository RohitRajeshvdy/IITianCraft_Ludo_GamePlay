using UnityEngine;

public class GreenPlayer : PlayerMovement
{
    void OnEnable() => InputManager.OnObjectClicked += HandleClick;
    void OnDisable() => InputManager.OnObjectClicked -= HandleClick;

    private void HandleClick(GameObject clickedObject)
    {
        if (clickedObject == gameObject && TurnManager.Instance.IsPlayerTurn(TurnManager.PlayerColor.Green))
        {
            MovePlayer(pathPointParent.GreenPathPoints);
        }
    }

}
