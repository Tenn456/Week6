using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public TMP_Text scoreText;
    int score = 0;
    bool letMove = true;

    public float speed;

    public gameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    

    // Update is called once per frame
    void Update(){

        if (letMove){
            Vector3 newPos = transform.position;

            if(Input.GetKey(KeyCode.W)){
                newPos.z = newPos.z + speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.S)){
                newPos.z = newPos.z - speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.A)){
                newPos.x = newPos.x - speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D)){
                newPos.x = newPos.x + speed * Time.deltaTime;
            }

            transform.position = newPos;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < myManager.enemyNum; i++)
          {
            if (Vector3.Distance(transform.position, myManager.enemies[i].transform.position) < 2f)
            {
                Vector3 enemyPos = myManager.enemies[i].transform.position;
                Vector3 resetPos = new Vector3(Random.Range(-2, 20), enemyPos.y, Random.Range(-2, 15));
                myManager.enemies[i].transform.position = resetPos;
                Debug.Log("near an enemy!!!");
            }
          }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collect")
        {
            score++;
            scoreText.text = score.ToString();
            myManager.allCollectables.Remove(other.gameObject);
            Destroy(other.gameObject);
        }

        for(int i = 0; i < myManager.enemyNum; i++){
            if(other.gameObject == myManager.enemies[i])
            {
                letMove = false;
                Debug.Log("hit!");
            }
        }
    }
}
