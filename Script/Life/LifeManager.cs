using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject lifeUiObj_;
    public static GameObject lifeUiObj;
    public static GameObject thisObj;
    // Start is called before the first frame update
    void Start()
    {
        lifeUiObj = lifeUiObj_;
        thisObj = gameObject;
        ChangeLife();
    }

    public static void ChangeLife()
    {
        //Debug.Log("Life Changed");
        //Debug.Log(thisObj.transform.childCount);
        //Debug.Log(thisObj.transform.childCount != 0);
        //if (thisObj.transform.childCount != 0) Debug.Log(thisObj.transform.GetChild(0).gameObject);
        for (int i=0; i<thisObj.transform.childCount;i++) Destroy( thisObj.transform.GetChild(i).gameObject);
        //Debug.Log(thisObj.transform.childCount);
        //while (thisObj.transform.childCount>0) Destroy(thisObj.transform.GetChild(thisObj.transform.childCount-1));
        for (int i = 0; i < GameManager.life; i++)
        {
            GameObject obj = Instantiate(lifeUiObj, thisObj.transform);//obj, parent
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250 - i * 120, -85, 0);
            obj.name = "Ball " + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
