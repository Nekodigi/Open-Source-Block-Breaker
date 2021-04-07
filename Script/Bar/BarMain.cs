using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMain : MonoBehaviour
{
    AudioSource auso;
    // Start is called before the first frame update
    void Start()
    {
        auso = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {//https://docs.unity3d.com/ja/current/ScriptReference/Camera.ScreenToWorldPoint.html
        float mouseX = Input.mousePosition.x;
        float worldX = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0, 0)).x;
        gameObject.transform.position = new Vector3(worldX, -4.5f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        auso.Play();
    }
}
