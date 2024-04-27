using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;
public class Win : MonoBehaviourPun
{
    public GameObject WinPanel;
    public TMP_Text messageText;
   public void win()
    {
        WinPanel.SetActive(true);
        messageText.text = "Congratulations!!! You Win " + PhotonNetwork.NickName;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("App Quit");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainScene");
    }
}

