using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrinicipalController : MonoBehaviour
{
    [SerializeField] private string NomeLevelJogo;
    [SerializeField] private string NomeMenu;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpc;
    //[SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelSairMsm;

    public void Jogar()
    {
        SceneManager.LoadScene(NomeLevelJogo);
    }

    public void Sair()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void VoltarMenu()
    {

        SceneManager.LoadScene(NomeMenu);
    }


    public void OpenOpcao()
    {
        painelMenuInicial.SetActive(false);
        painelOpc.SetActive(true);

    }

    public void CloseOpcao()
    {
        painelMenuInicial.SetActive(true);
        painelOpc.SetActive(false);
    }

    public void OpenSairOpcao()
    {
        painelMenuInicial.SetActive(false);
        painelSairMsm.SetActive(true);
    }

    public void CloseSairOpcao()
    {
        painelMenuInicial.SetActive(true);
        painelSairMsm.SetActive(false);
    }
}


