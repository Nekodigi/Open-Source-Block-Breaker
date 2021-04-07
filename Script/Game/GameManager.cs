using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int maxScore;
    public static int life;
    public int life_;
    public static bool gameClear;
    public static bool gameOver;
    public static bool gameEnd;
    static GameObject gameOverObj;
    static GameObject gameClearObj;
    static GameObject gameClearMakerObj;
    static GameObject completeObj;
    static GameObject stageObj;
    static GameObject pauseObj;
    public static GameObject ballMain;
    public static BallMain bmbm;//main ball ball main component
    public static int stageId;
    Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(BlockGen.blockDatas.GetLength(0));
        //PlayerPrefs.SetInt("stageIdBest", 2);
        //PlayerPrefs.Save();
        //stageId = PlayerPrefs.GetInt("stageIdBest");
        stageId = PlayerPrefs.GetInt("stageIdCurrent");
        Advertisement.Initialize("4054297", false);
        canvas = GameObject.Find("Canvas").transform;
        gameOverObj = canvas.Find("GAME OVER").gameObject;
        gameClearObj = canvas.Find("GAME CLEAR").gameObject;
        gameClearMakerObj = canvas.Find("GAME CLEAR MAKER").gameObject;
        stageObj = canvas.Find("STAGE").gameObject;
        completeObj = canvas.Find("COMPLETE").gameObject;
        pauseObj = canvas.Find("PAUSED").gameObject;
        ballMain = GameObject.Find("BallMain").gameObject;
        bmbm = ballMain.GetComponent<BallMain>();
        setStage();
        ResetUI();
        //if (Advertisement.IsReady())
        //{
        //    Advertisement.Show();
        //    Debug.Log("REady");
        //}
        //else
        //{
        //    Debug.Log("Not Ready");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //ShowAd();
        if (!(gameEnd == false && ScoreMain.score == maxScore)) return;
        Debug.Log(maxScore);
        gameClear = true;
        gameEnd = true;
        //Debug.Log("GameClear");
        if (stageId + 1 >= BlockGen.blockDatas.GetLength(0))
        {
            stageId = BlockGen.blockDatas.GetLength(0) - 1;
            completeObj.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("stageIdBest", Mathf.Max(PlayerPrefs.GetInt("stageIdBest"), stageId + 1));//save data
            PlayerPrefs.SetInt("stageIdCurrent", stageId + 1);//save data
            stageObj.SetActive(false);
            if (stageId >= 0) gameClearObj.SetActive(true);
            else gameClearMakerObj.SetActive(true);
        }
        PlayerPrefs.Save();
    }

    public static void subLife()
    {
        if (gameEnd) return;
        life--;
        LifeManager.ChangeLife();
        if (life == 0)
        {
            gameOver = true;
            gameEnd = true;
            //Debug.Log("GameOver");//FAILED
            gameOverObj.SetActive(true);
        }
    }

    public static void setLife(int life_)
    {
        life = life_;
        LifeManager.ChangeLife();
    }

    public void Pause()
    {
        if (gameEnd != true)
        {
            stageObj.SetActive(false);
            Time.timeScale = 0;
            pauseObj.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseObj.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
    }

    public void Next()//when ad ends.. show title
    {
        stageId++;
        //if (stageId + 1 >= BlockGen.blockDatas.GetLength(0))
        //{
        //    stageId = BlockGen.blockDatas.GetLength(0) - 1;
        //    Debug.Log("ALL STAGE COMPLETED!");
        //    return;
        //}
        setStage();
        //Debug.Log("maxScore: " + maxScore);
        if (Advertisement.IsReady())//shouldn't show ad when score is too low
        {
            Time.timeScale = 0;
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(options);
            //Debug.Log("REady");
        }
        else
        {
            //Debug.Log("Not Ready");
        }
    }

    public void Retry()
    {
        setStage();
        gameOverObj.SetActive(false);
        //Debug.Log(maxScore);
        if (Advertisement.IsReady())//shouldn't show ad when score is too low
        {
            Time.timeScale = 0;
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(options);
            //Debug.Log("REady");
        }
        else
        {
            //Debug.Log("Not Ready");
        }
    }

    private void ResetUI()
    {
        GameObject stageObj = canvas.Find("STAGE").gameObject;
        stageObj.SetActive(false);
        stageObj.SetActive(true);
        bmbm.Reset();
        Time.timeScale = 1;
    }

    private void HandleShowResult(ShowResult result)
    {
        ResetUI();
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    void setStage()
    {
        if (stageId >= 0)
        {
            stageObj.GetComponent<Text>().text = "STAGE " + (1 + stageId);
            ballMain.GetComponent<BallMain>().Reset();
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject obj in objs)
            {
                if (obj.name != "BallMain") Destroy(obj);
            }
            gameClearObj.SetActive(false);
            setLife(3);
            ScoreMain.setScore(0);
            objs = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject obj in objs)
            {
                Destroy(obj);
                obj.SetActive(false);
            }
            BlockGen.Generate(stageId);
            gameOver = false;
            gameEnd = false;
            objs = GameObject.FindGameObjectsWithTag("Block");
            maxScore = 0;
            foreach (GameObject obj in objs)
            {
                maxScore += obj.GetComponent<BlockMain>().getScore();
                //Debug.Log("getScore"+obj.GetComponent<BlockMain>().getScore());
            }
        }
        else
        {
            stageObj.GetComponent<Text>().text = "CUSTOM STAGE";
            ballMain.GetComponent<BallMain>().Reset();
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject obj in objs)
            {
                if (obj.name != "BallMain") Destroy(obj);
            }
           // gameClearObj.SetActive(false);
            setLife(3);
            ScoreMain.setScore(0);
            objs = GameObject.FindGameObjectsWithTag("Block");
            foreach (GameObject obj in objs)
            {
                Destroy(obj);
                obj.SetActive(false);
            }
            BlockGen.Generate(stageId);
            gameOver = false;
            gameEnd = false;
            objs = GameObject.FindGameObjectsWithTag("Block");
            maxScore = 0;
            foreach (GameObject obj in objs)
            {
                maxScore += obj.GetComponent<BlockMain>().getScore();
                //Debug.Log("getScore"+obj.GetComponent<BlockMain>().getScore());
            }
        }
    }

    public void Edit()
    {
        SceneManager.LoadScene("StageMaker", LoadSceneMode.Single);
    }
}
