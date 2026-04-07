using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TurnIntoGhost : MonoBehaviour
{
    private bool ghosted = false;
    private bool TimeEnd = true;

    private Renderer playerRender;
    private InputAction ghostAction;
    public InputActionAsset InputActions;

    void Start()
    {
        playerRender = GetComponent<Renderer>();
          //print ("AUUUUUUU baby i'm paryin u tonaith");

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
    void Update()
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
            StartCoroutine(GhostStop());
        }
        else
        {
            playerRender.enabled = true;
            ghosted = false;
            StartCoroutine(GhostStart());
        }
    }

    private IEnumerator GhostStop()
    {
        yield return new WaitForSeconds(2);
        if (ghosted)
        {
            Ghost();
        }
    }
    private IEnumerator GhostStart()
    {
        TimeEnd = false;
        yield return new WaitForSeconds(2);
        TimeEnd = true;
    }

}
