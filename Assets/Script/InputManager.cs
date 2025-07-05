using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private InputActionAsset inputActions;

    private InputAction clickAction;
    private Camera mainCamera;

    public static event Action<GameObject> OnObjectClicked;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mainCamera = Camera.main;

        clickAction = inputActions.FindAction("Clicked");
        clickAction.performed += OnClick;
        clickAction.Enable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Vector2 screenPosition = GetInputPosition();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null)
        {
            OnObjectClicked?.Invoke(hit.collider.gameObject);
        }
    }

    private Vector2 GetInputPosition()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            return Touchscreen.current.primaryTouch.position.ReadValue();
        }
        return Mouse.current.position.ReadValue();
    }

    void OnDestroy()
    {
        if (clickAction != null)
        {
            clickAction.performed -= OnClick;
            clickAction.Disable();
        }
    }
}