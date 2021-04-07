using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButtonGen : MonoBehaviour
{
    public GameObject stageBtnObj;
    GameObject customStageButton;
    // Start is called before the first frame update
    void Start()
    {
        customStageButton = GameObject.Find("CustomStageButton");
        Debug.Log(((BlockGen.blockDatas.GetLength(0) - 1) / 5));
        customStageButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -700 - ((BlockGen.blockDatas.GetLength(0) - 1) / 5+1) * 150, 0);
        if(BlockGen.blockDatas.GetLength(0)-1<=PlayerPrefs.GetInt("stageIdBest")) customStageButton.GetComponent<Button>().interactable = true;

        for (int i=0; i<BlockGen.blockDatas.GetLength(0); i++)
        {
            GameObject canvasObj = GameObject.Find("Canvas");
            GameObject obj = Instantiate(stageBtnObj, canvasObj.transform);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-300 + (i%5) * 150, -700 - (i / 5) * 150, 0);
            obj.GetComponent<StageButtonMain>().init(i);
            if(i> PlayerPrefs.GetInt("stageIdBest"))
            {
                obj.GetComponent<Button>().interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CustomStageMaker()
    {
        SceneManager.LoadScene("StageMaker", LoadSceneMode.Single);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
    }
}
