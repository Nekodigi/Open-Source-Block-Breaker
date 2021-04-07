using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButtonMain : MonoBehaviour
{
    public int stageId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void init(int stageId_)
    {
        stageId = stageId_;
        transform.Find("Text").GetComponent<Text>().text = (stageId+1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log(stageId);
        PlayerPrefs.SetInt("stageIdCurrent", stageId);
        SceneManager.LoadScene("Stage");
    }


    
}
