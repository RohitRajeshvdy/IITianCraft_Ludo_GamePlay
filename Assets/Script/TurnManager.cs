using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public enum PlayerColor { Yellow, Blue, Red, Green }
    private PlayerColor currentTurn = PlayerColor.Yellow;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public bool IsPlayerTurn(PlayerColor player)
    {
        return currentTurn == player;
    }

    /// <summary>
    /// Loops the turn in order of color
    /// </summary>
    public void EndTurn()
    {
        
        currentTurn = (PlayerColor)(((int)currentTurn + 1) % System.Enum.GetValues(typeof(PlayerColor)).Length);
    }
}
