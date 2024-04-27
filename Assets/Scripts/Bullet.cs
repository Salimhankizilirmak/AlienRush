using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    public float speed = 10f;
    public float destroyTime = 0.5f;
   public float destroyAlienTime = 0.01f;
    public bool shootLeft = false;
     private GameObject Alien;
    Collider2D collision;
    IEnumerator destroyBullet(){
        yield return new WaitForSeconds(destroyTime);
        this.GetComponent<PhotonView>().RPC("destroy",RpcTarget.AllBuffered);
        
    }
    /*IEnumerator Alienn(){
        this.GetComponent<PhotonView>().RPC("destroyAlien",RpcTarget.AllBuffered);
        yield return new WaitForSeconds(destroyAlienTime);
    }*/
void Start(){
       // Alien = GameObject.FindWithTag("Alien");
        StartCoroutine(destroyBullet());
       
        
    }
    // Update is called once per frame
    void Update()
    {
        if(!shootLeft){
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        transform.Translate(Vector2.right* Time.deltaTime * speed);
     
      
    }

    [PunRPC]
    public void destroy(){

        Destroy(this.gameObject);
       
    }
    /*[PunRPC]
    public void destroyAlien()
    {
        Destroy(this.gameObject);
        
    }*/
               
           
    [PunRPC]
    public void changeDirection(){
        shootLeft = true;
    }
}
