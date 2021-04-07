using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.gameEnd) return;
        GameObject obj = collision.gameObject;
        if (GameManager.gameOver == false && obj.name == "BallMain")
        {
            GameManager.subLife();
            obj.GetComponent<BallMain>().Reset();
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Fell into void");
        }
    }   
}
