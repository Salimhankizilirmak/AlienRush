using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last : MonoBehaviour
{
    public float Duration = 3f;
    private Win winScript;
    public GameObject playerPrefab;
    

    void Start()
    {
        winScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Win>();

    }

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        winScript.win();
    }
}

    IEnumerator Stopped()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(Duration);
        Time.timeScale = 1f;
    }


}
