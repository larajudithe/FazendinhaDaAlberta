using UnityEngine;
using UnityEngine.InputSystem;
public class TurnIntoGhost : MonoBehaviour
{
    private bool ghosted = false;
    private Renderer playerRender;
    private InputAction ghostAction;
    public InputActionAsset InputActions;

    void Start()
    {
        playerRender = GetComponent<Renderer>();

    }
    private void Awake()
    {

        ghostAction = InputSystem.actions.FindAction("Ghost");
    }
    void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    void Updade()
    {
        if (ghostAction.WasPressedThisFrame())
        {
            Ghost();
        }
    }

    private void Ghost()
    {
        if (!ghosted)
        {
            playerRender.enabled = false;
            ghosted = true;
        }
        else
        {
            playerRender.enabled = true;
            ghosted = false;
        }
    }

}
