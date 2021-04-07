
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGen : MonoBehaviour
{
    public GameObject[] blocks_;
    public static GameObject[] blocks;
    public static int[,,] blockDatas = {{//upside down!!!
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 1, 1, 1, 0, 0, 0  },
        {0, 0, 0, 1, 1, 1, 0, 0, 0  },
        {0, 0, 0, 1, 1, 1, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 1, 0, 0, 0, 0  },
        {0, 0, 0, 1, 1, 1, 0, 0, 0  },
        {0, 0, 1, 1, 2, 1, 1, 0, 0  },//register id 2 block
        {0, 0, 0, 1, 1, 1, 0, 0, 0  },
        {0, 0, 0, 0, 1, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 1, 1, 1, 1, 1, 0, 0  },
        {0, 0, 1, 0, 0, 0, 1, 0, 0  },
        {0, 0, 1, 0, 2, 0, 1, 0, 0  },//register id 2 block
        {0, 0, 1, 0, 0, 0, 1, 0, 0  },
        {0, 0, 1, 0, 0, 0, 1, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 1, 11, 1, 0, 0, 0  },
        {0, 0, 0, 11, 22, 11, 0, 0, 0  },//register id 2 block
        {0, 0, 0, 1, 11, 1, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 11, 0, 11, 0, 0, 0 },
        {0, 0, 0, 11, 0, 11, 0, 0, 0  },
        {0, 0, 0, 11, 0, 11, 0, 0, 0  },//register id 2 block
        {0, 0, 0, 11, 0, 11, 0, 0, 0  },
        {11, 11, 11, 11, 0, 11, 11, 11, 11 },
        {2, 0, 0, 0, 2, 0, 0, 0, 2  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 21, 21, 21, 21, 21, 0, 0  },
        {0, 0, 11, 11, 11, 11, 11, 0, 0  },
        {0, 0, 11, 11, 11, 11, 11, 0, 0  },
        {0, 0, 1, 1, 1, 1, 1, 0, 0  },//register id 2 block
        {0, 0, 1, 1, 1, 1, 1, 0, 0  },
        {0, 0, 32, 32, 32, 32, 32, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 3, 0, 0, 0, 0  },
        {0, 0, 0, 11, 21, 11, 0, 0, 0  },
        {0, 0, 11, 21, 31, 21, 11, 0, 0  },//register id 2 block
        {0, 0, 0, 11, 21, 11, 0, 0, 0  },
        {0, 0, 0, 0, 11, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 1, 11, 0, 11, 1, 0, 0  },
        {0, 0, 11, 21, 0, 21, 11, 0, 0  },
        {0, 0, 11, 21, 13, 21, 11, 0, 0  },//register id 2 block
        {0, 0, 11, 21, 21, 21, 11, 0, 0  },
        {0, 0, 1, 11, 11, 11, 1, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 1, 0, 0, 0, 1, 0, 0  },
        {0, 0, 11, 21, 0, 21, 11, 0, 0  },
        {0, 0, 11, 21, 13, 21, 11, 0, 0  },//register id 2 block
        {0, 0, 11, 21, 0, 21, 11, 0, 0  },
        {0, 0, 21, 0, 0, 0, 21, 0, 0  },
        {0, 21, 0, 0, 0, 0, 0, 21, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 1, 1, 2, 1, 1, 0, 0  },
        {0, 0, 1, 2, 1, 2, 1, 0, 0  },
        {0, 0, 2, 1, 2, 1, 2, 0, 0  },//register id 2 block
        {0, 0, 1, 2, 1, 2, 1, 0, 0  },
        {0, 0, 1, 1, 2, 1, 1, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
        {0, 0, 0, 0, 0, 0, 0, 0, 0  },
    },

    };

    // Start is called before the first frame update
    void Awake()
    {
        blocks = blocks_;
        Generate(GameManager.stageId);
    }

    public static void Generate(int stage)
    {
        if (stage >= 0)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Debug.Log(blockDatas[j, i]);
                    int id = blockDatas[stage, j, i];
                    GameObject obj = blocks[id % 10];
                    if (obj == null) continue;
                    GameObject cloneObj = Instantiate(obj, new Vector3((i - 4) * 0.6f, (j - 4) * 0.6f + 1.3f, 0), Quaternion.identity);
                    BlockMain bm = cloneObj.GetComponent<BlockMain>();
                    bm.init(id / 10);
                }
            }
        }
        else
        {
            string str = PlayerPrefs.GetString("customStage");
            string[] strs = str.Split('\n');
            Debug.Log(str);
            for (int j = 0; j < 9; j++)
            {
                string strj = strs[j];
                string[] strjs = strj.Split(' ');
                for (int i = 0; i < 9; i++)
                {
                    //Debug.Log(blockDatas[j, i]);
                    //int id = blockDatas[stage, j, i];
                    int id = int.Parse(strjs[i]);
                    GameObject obj = blocks[id % 10];
                    if (obj == null) continue;
                    GameObject cloneObj = Instantiate(obj, new Vector3((i - 4) * 0.6f, (j - 4) * 0.6f + 1.3f, 0), Quaternion.identity);
                    BlockMain bm = cloneObj.GetComponent<BlockMain>();
                    bm.init(id / 10);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
