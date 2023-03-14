using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int objNum;
    public GameObject objCollect;

    public int enemyNum;
    public GameObject enemy;

    public GameObject[] enemies;

    public Transform leftTop;
    public Transform rightBottom;

    public List<GameObject> allCollectables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[enemyNum];

        for(int i = 0; i < objNum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
            GameObject newObj = Instantiate(objCollect, newPos, Quaternion.identity);
            allCollectables.Add(newObj);
        }

        for(int i = 0; i < enemyNum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newPos = new Vector3(newX, transform.position.y - 0.5f, newZ);
            GameObject newObj = Instantiate(enemy, newPos, Quaternion.identity);
            enemies[i] = newObj;
        }
    }

    void Update()
    {
        Debug.Log(allCollectables.Count);
    }
}

