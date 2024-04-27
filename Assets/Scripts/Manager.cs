using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Manager : MonoBehaviourPun {
    public GameObject playerPrefab;
	void Start ()
    {
        SpawnPlayer();

    }


    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position,playerPrefab.transform.rotation);
    }
    
}
