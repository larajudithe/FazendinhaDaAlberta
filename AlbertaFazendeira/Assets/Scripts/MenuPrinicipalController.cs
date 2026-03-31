using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrinicipalController : MonoBehaviour
{
    [SerializeField] public string NomeLevelJogo;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeLevelJogo);
    }

     public void Sair()
    {
        Application.Quit();
    }

    //  public void Opcao()
    // {
        
    // }
}


