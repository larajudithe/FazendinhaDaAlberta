using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrinicipalController : MonoBehaviour
{
    [SerializeField] public string NomeLevelJogo;
    [SerializeField] public string NomeMenu;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeLevelJogo);
    }

     public void Sair()
    {
        Application.Quit();
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(NomeMenu);
    }


    //  public void Opcao()
    // {
        
    // }
}


