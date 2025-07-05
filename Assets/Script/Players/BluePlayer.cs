using UnityEngine;

public class BluePlayer : PlayerMovement
{
    void OnEnable() => InputManager.OnObjectClicked += HandleClick;
    void OnDisable() => InputManager.OnObjectClicked -= HandleClick;

    private void HandleClick(GameObject clickedObject)
    {
        if (clickedObject == gameObject)
        {
            MovePlayer(pathPointParent.BluePathPoints);
        }
    }
}
