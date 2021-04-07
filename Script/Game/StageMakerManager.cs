using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMakerManager : MonoBehaviour
{
    public GameObject blockSectorObj;
    public static int[,] stage = new int[9,9];
    public Sprite[] blockSpr;
    public Sprite[] hardnessSpr;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("customStage")){
            PlayerPrefs.SetString("customStage", "0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0\n0 0 0 0 0 0 0 0 0");
        }
        Debug.Log(PlayerPrefs.GetString("customStage"));
        string str = PlayerPrefs.GetString("customStage");
        string[] strs = str.Split('\n');
        for (int j = 0; j < 9; j++)
        {
            string strj = strs[j];
            string[] strjs = strj.Split(' ');
            for (int i = 0; i < 9; i++)
            {
                int id = int.Parse(strjs[i]);
                stage[i, j] = id;
                GameObject cloneObj = Instantiate(blockSectorObj, new Vector3((i - 4) * 0.6f, (j - 4) * 0.6f + 1.3f, 0), Quaternion.identity);
                cloneObj.GetComponent<BlockSector>().setAddr(i, j);
                cloneObj.GetComponent<SpriteRenderer>().sprite = blockSpr[id % 10];
                int hardness = id / 10;
                if (hardness == 0)
                {
                    cloneObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().enabled = false;
                    cloneObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().sprite = null;
                }
                else
                {
                    cloneObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().enabled = true;
                    cloneObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().sprite = hardnessSpr[hardness - 1];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        string str = "";
        for(int i=0; i < stage.GetLength(0); i++)
        {
            for (int j= 0; j < stage.GetLength(1); j++)
            {
                str += stage[j,i];
                str += " ";
            }
            str.Substring(0, str.Length-1);
            str += "\n";
        }
        str.Substring(0, str.Length - 1);
        PlayerPrefs.SetString("customStage", str);
        PlayerPrefs.SetInt("stageIdCurrent", -1);
        PlayerPrefs.Save();
        Debug.Log(str);
        SceneManager.LoadScene("Stage", LoadSceneMode.Single);
    }
}
