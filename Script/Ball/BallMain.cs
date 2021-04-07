using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMain : MonoBehaviour
{
    Rigidbody2D rb;
    bool resetting;
    AudioSource auso;
    public AudioClip[] audioClips;
    public static GameObject thisObj;
    public float star;
    // Start is called before the first frame update
    void Start()
    {
        //thisObj = GameObject.Find("BallMain");
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        if (gameObject.name == "BallMain") {
            thisObj = gameObject;
            Reset(); }
        if (gameObject.name != "BallMain") gameObject.GetComponent<TrailRenderer>().enabled = false;
        auso = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        star -= Time.deltaTime;
        if (rb.velocity != new Vector2(0, 0)) { 
        float vx = rb.velocity.x;
        if (vx < 1 && vx > 0) rb.velocity += new Vector2(1, 0);
        if (vx <= 0 && vx > -1) rb.velocity += new Vector2(-1, 0);
        float vy = rb.velocity.y;
        if (vy < 1 && vy > 0) rb.velocity += new Vector2(rb.velocity.x, 1);
        if (vy <= 0 && vy > -1) rb.velocity += new Vector2(rb.velocity.x, -1);
            rb.velocity = rb.velocity.normalized * 6;
        }
        if (resetting && Input.GetMouseButtonDown(0))//how detect ball?
        {
            GameObject barObj = GameObject.Find("Bar");
            thisObj.transform.position = new Vector3(barObj.transform.position.x, -4, 0);
            thisObj.GetComponent<TrailRenderer>().Clear();
            thisObj.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5);
            resetting = false;
            //Time.timeScale = 1;
        }
        if (gameObject.name == "BallMain")
        {
            if (star > 0)
            {
                gameObject.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                gameObject.GetComponent<ParticleSystem>().Stop();
            }
        }
    }

    public void Reset()
    {
        thisObj = gameObject;//some strange bug happening to thisObj
        thisObj.transform.position = new Vector3(0, -9, 0);
        thisObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        resetting = true;
        //Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        auso.clip = audioClips[Random.Range(0, audioClips.Length)];
        auso.pitch = Random.Range(0.5f, 1.5f);
        if(collision.gameObject.name == "Wall" || collision.gameObject.name == "Corner")auso.Play();
    }
}
