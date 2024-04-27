    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Photon.Pun;
    using System;
    using TMPro;
    public class MyPlayer : MonoBehaviourPun,IPunObservable {

        public PhotonView pv;

        public float moveSpeed = 6;
        public float jumpforce = 800;

        private Vector3 smoothMove;
        public float score;
        private GameObject sceneCamera;
        public GameObject playerCamera;

        public SpriteRenderer sr;
        public TMP_Text nameText;
        private Rigidbody2D rb;
        private bool IsGrounded;

        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        public Transform bulletSpawnLeft;
        void Start()
        { 
            if (photonView.IsMine)
            {
                nameText.text = PhotonNetwork.NickName;

                rb = GetComponent<Rigidbody2D>();
                sceneCamera = GameObject.FindWithTag("MainCamera");
                sceneCamera.SetActive(false);
                playerCamera.SetActive(true);
            }
            else {
                nameText.text = pv.Owner.NickName;
            }
        }
        void Update()
        {
            if (photonView.IsMine)
            {
                ProcessInputs();
            }
            else {
                smoothMovement();
        }
        score += 1 * Time.deltaTime;
        }
        public void Minus2Points()
        {
            score -= 2;
        }

        private void smoothMovement()
        {
            transform.position = Vector3.Lerp(transform.position,smoothMove,Time.deltaTime *10);
        }

        private void ProcessInputs()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0);
            transform.position += move * moveSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                sr.flipX = false;
                pv.RPC("OnDirectionChange_RIGHT",RpcTarget.Others);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                sr.flipX = true;
                pv.RPC("OnDirectionChange_LEFT", RpcTarget.Others);
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.U) && IsGrounded)
            {
                Shoot();
            }
        }
        public void OnRightButtonClicked()
    {
        sr.flipX = false;
        pv.RPC("OnDirectionChange_RIGHT", RpcTarget.Others);
    }
        public void Shoot(){
            GameObject bullet; 
        if(sr.flipX == true){
            bullet = PhotonNetwork.Instantiate(bulletPrefab.name, bulletSpawnLeft.position, Quaternion.identity);
        }else{
            bullet = PhotonNetwork.Instantiate(bulletPrefab.name, bulletSpawn.position, Quaternion.identity);
        }


        /* if(sr.flipX == true){
                bullet.GetComponent<PhotonView>().RPC("changeDirection",RpcTarget.AllBuffered);
            }*/

        }

        [PunRPC]
        void OnDirectionChange_LEFT()
        {
            sr.flipX = true;

        }

        [PunRPC]
        void OnDirectionChange_RIGHT()
        {
            sr.flipX = false;

        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (photonView.IsMine)
            { 
                if (col.gameObject.tag == "Ground")
                {
                    IsGrounded = true;
                }
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            if (photonView.IsMine)
            {
                if (col.gameObject.tag == "Ground")
                {
                    IsGrounded = false;
                }
            }
        }

        void Jump()
        {
            rb.AddForce(Vector2.up * jumpforce);
        }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
            }
            else if (stream.IsReading)
            {
                smoothMove = (Vector3) stream.ReceiveNext();
            }

        }
        
    /*  public float GetScore()
        {
        return score;
        }*/

    }
