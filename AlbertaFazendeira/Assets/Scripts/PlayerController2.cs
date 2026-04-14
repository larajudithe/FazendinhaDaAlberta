using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class PlayerController2 : MonoBehaviour
{
    [Header("PLAYER")]
    public InputActionAsset InputActions;
    private InputAction pauseActionPlayer;
    private InputAction pauseActionUI;


    [Header("MOVIMENTO")]
    public float speed = 20f;
    public float xRange = 15f;
    private InputAction moveAction;

    [Header("DISPARO")]
    public GameObject projectilePrefab;
    private InputAction fireAction;


    [Header("HUD")]
    public TextMeshProUGUI pointText;
    public Image displayLife;
    public Sprite[] spritesLife;
    private int life = 3;
    public int point = 0;






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
        AtualizarHUD();
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
            // StartCoroutine(Ghost(2));

        }

        PauseGame();
    }

    // private IEnumerator Ghost(float waitTime)
    // {
    //     // torna player invisível
    //     yield return new WaitForSeconds(waitTime);
    //     // torna player visível
    // }

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
            InputActions.FindActionMap("UI").Disable();
            InputActions.FindActionMap("Player").Enable();
            stoped.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Animais"))
        {
            var random = GetComponentInChildren<TurnIntoGhost>();
            Debug.Log(random);
            Debug.Log(random.ghosted);
            if (random.ghosted)
            {
                print("AUUUUUUUUU baby iam praying u tonight");
            }
            else
            {
                Demage();
                Destroy(other.gameObject);
            }

        }
    }
    public void AddPoints(int valor)
    {
        point += valor;
        
        print (valor);
        AtualizarHUD();

    }

    private void Demage()
    {
        life--;
        if (life < 0) life = 0;

        AtualizarHUD();


        // if (life <= 0)
        // {
        //     //GameOver();
        // }
    }

    void AtualizarHUD()
    {
        if (pointText != null) pointText.text = " " + point;

        if (displayLife != null && spritesLife.Length > life)
        {
            displayLife.sprite = spritesLife[life];
        }
    }

}











