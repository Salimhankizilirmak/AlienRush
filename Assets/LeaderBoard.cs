using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
   /* public GameObject playersHolder;
    [Header("Options")] 
    public float refreshRate = 1.0f;
    [Header("UI")] 
    public GameObject[] slots;
    [Space] 
    public TextMeshProUGUI[] scoreTexts;
    public TextMeshProUGUI[] nameTexts;
    private void Start()
    {
        InvokeRepeating(nameof(Refresh),1f, refreshRate);
    }
    public void Refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }
        var sortedPlayerList=(from player in PhotonNetwork.PlayerList orderby player descending select player).ToList();
        int i = 0;
        foreach(var player in sortedPlayerList){
            slots[i].SetActive(true);
            if(player.NickName== "")
            player.NickName="unknown";
            nameTexts[i].text= player.NickName; 
          //  scoreTexts[i].text=player.GetScore().ToString();
            i++;
        }
       
    }
    
    private void Update(){
    playersHolder.SetActive(Input.GetKey(KeyCode.Tab));       
    }*/
}

