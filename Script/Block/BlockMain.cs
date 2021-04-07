using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMain : MonoBehaviour
{
    public int score;
    public int hardness;
    public bool spawn;
    public float star;//star duration
    public GameObject ballObj;
    SpriteRenderer hardnessRen;
    public Sprite[] hardnessSrt;
    public AudioClip[] clips;
    BoxCollider2D bc;
    // Start is called before the first frame update
    public void init(int hardness_)
    {
        hardness = hardness_;
        hardnessRen = transform.Find("Hardness").gameObject.GetComponent<SpriteRenderer>();
        hardnessRen.sprite = hardness<=0 ? null : hardnessSrt[hardness-1];
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.bmbm.star>0)
        {
            bc.isTrigger = true;
        }
        else
        {
            bc.isTrigger = false;
        }
    }

    public int getScore()
    {
        return score + hardness;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollide(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollide(collision.gameObject);
    }

    void OnCollide(GameObject colideObj)
    {
        //is ball star?
        BallMain bm = colideObj.GetComponent<BallMain>();
        AudioSource auso = gameObject.GetComponents<AudioSource>()[0];
        auso.pitch = Random.Range(0.5f, 1.5f);
        if (bm.star > 0)
        {
            auso.clip = clips[1];
            ScoreMain.addScore(getScore());
            PreDestory(bm);
        }
        else
        {
            auso.clip = clips[0];
            ScoreMain.addScore(1);
            if (hardness == 0)
            {
                PreDestory(bm);
            }
            else
            {
                gameObject.GetComponents<AudioSource>()[0].Play();
                hardness--;
                hardnessRen.sprite = hardness <= 0 ? null : hardnessSrt[hardness - 1];
            }
        }
    }

    private void PreDestory(BallMain bm)
    {
        gameObject.GetComponents<AudioSource>()[0].Play();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        transform.Find("Hardness").gameObject.SetActive(false);
        if (spawn)
        {
            AudioSource auso = gameObject.GetComponents<AudioSource>()[1];
            auso.pitch = Random.Range(0.5f, 1.5f);
            auso.Play();
            Instantiate(ballObj, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Cloned");
        }
        else if (star > 0)
        {
            bm.star = Mathf.Max(0, bm.star);
            bm.star += star;
        }

        Invoke("DestroyThis", 0.5f);
        return;
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
