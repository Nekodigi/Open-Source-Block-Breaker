using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardnessSlider : MonoBehaviour
{
    public Text hardnessText;
    public Sprite[] hardnessSpr;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUpdate()
    {
        int value = (int)slider.value;
        Debug.Log(value);
        hardnessText.text = "Hardness " + value;
        GameObject[] BlockSelectors = GameObject.FindGameObjectsWithTag("BlockSelector");
        foreach (GameObject BlockSelector in BlockSelectors)
        {
            //Debug.Log(BlockSelector.name);
            if (BlockSelector.GetComponent<BlockSelect>().blockId != 0)
            {
                if (value == 0)
                {
                    BlockSelector.transform.Find("Hardness").GetComponent<Image>().enabled = false;
                    BlockSelector.transform.Find("Hardness").GetComponent<Image>().sprite = null;
                }
                else
                {
                    BlockSelector.transform.Find("Hardness").GetComponent<Image>().enabled = true;
                    BlockSelector.transform.Find("Hardness").GetComponent<Image>().sprite = hardnessSpr[value - 1];
                }
            }
        }
    }
}
