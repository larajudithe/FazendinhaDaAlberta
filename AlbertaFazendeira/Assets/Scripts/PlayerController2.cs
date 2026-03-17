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
    private InputAction pauseAction;
    private bool Pause = false;
    public GameObject stoped;

    void Start()
    {
        Pause = false;
        stoped.SetActive(false);
    }
    private void OnEnable()
    {
        Pause = false;
        pauseAction = InputSystem.actions.FindAction("Pause");
        stoped.SetActive(false);
        InputActions.FindActionMap("Player").Enable();
        InputActions.FindActionMap("UI").Disable();
    }
    private void OnDisable()
    {
        Pause = true;
        pauseAction = InputSystem.actions.FindAction("Pause");
        stoped.SetActive(true);
        InputActions.FindActionMap("UI").Enable();
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("move");
        fireAction = InputSystem.actions.FindAction("Jump");
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


        }

        if (pauseAction.WasPressedThisFrame())
        {
            if (Pause == false)
            {
                OnDisable();
            }
            else
            {
                OnEnable();
            }
        }
}

}



