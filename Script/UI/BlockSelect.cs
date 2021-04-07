using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockSelect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int blockId;
    RectTransform rt;
    Vector3 defPos;//default position
    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        defPos = rt.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BlockSector");
        GameObject nearestObj = null;
        float nearestDist = float.PositiveInfinity;
        foreach (GameObject obj in objs)
        {
            float dist = Vector2.Distance(obj.transform.position, Camera.main.ScreenToWorldPoint(rt.position));
            if (dist < 0.5 && dist < nearestDist)
            {
                nearestDist = dist;
                nearestObj = obj;
                //Debug.Log("find!");
            }
        }
        if (nearestObj != null)
        {
            //nearestObj.SetActive(false);
            nearestObj.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<Image>().sprite;
            int hardness = (int)GameObject.Find("HardnessSlider").GetComponent<Slider>().value;
            int x = nearestObj.GetComponent<BlockSector>().x;
            int y = nearestObj.GetComponent<BlockSector>().y;
            if (blockId != 0)
            {
                nearestObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().sprite = transform.Find("Hardness").GetComponent<Image>().sprite;
                
                if (hardness > 0)
                {
                    nearestObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    nearestObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().enabled = false;
                }
                StageMakerManager.stage[x, y] = blockId + hardness * 10;
            }
            else
            {
                StageMakerManager.stage[x, y] = blockId;
                nearestObj.transform.Find("Hardness").GetComponent<SpriteRenderer>().enabled = false;
            }
            
            //Debug.Log(blockId + (int)GameObject.Find("HardnessSlider").GetComponent<Slider>().value * 10);
        }
        else
        {
            
        }
        rt.position = defPos;
    }
}
