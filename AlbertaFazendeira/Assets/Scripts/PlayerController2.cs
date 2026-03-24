using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController2 : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction pauseActionPlayer;
    private InputAction pauseActionUI;

    public GameObject stoped;


    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        pauseActionPlayer = InputSystem.actions.FindAction("Player/Pause");
        pauseActionUI = InputSystem.actions.FindAction("UI/Pause");
    }
    void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        // dispara comida ao pressionar barra de espa�o

        if (fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            StartCoroutine(Ghost(2));

        }

       PauseGame();
    }

    private IEnumerator Ghost(float waitTime)
    {
        // torna player invisível
        yield return new WaitForSeconds(waitTime);
        // torna player visível
    }

    private void PauseGame()
    {
        if (pauseActionPlayer.WasPressedThisFrame())
        {
            InputActions.FindActionMap("Player").Disable();
            InputActions.FindActionMap("UI").Enable();
            stoped.SetActive(true);

        }
        else if (pauseActionUI.WasPressedThisFrame())
        {
            InputActions.FindActionMap("Player").Enable();
            InputActions.FindActionMap("UI").Disable();
            stoped.SetActive(false);
        }
    }
}



