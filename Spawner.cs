using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject food;
    public GameObject virus;
    public int dangerNum;
    void Start()
    {
      //  dangerNum = PlayerPrefs.GetInt("virus");
        for(int i = 0; i < 8; i++)
        {
            float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x);

            Vector3 spawnPos = new Vector3(spawnX, spawnY, 1);
            Instantiate(food, spawnPos, Quaternion.identity);
        }
        print("at spawner" + "-----" + dangerNum);
        for(int i = 0; i < dangerNum; i++)
        {
            float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x);

            Vector3 spawnPos = new Vector3(spawnX, spawnY, 1);
            Instantiate(virus, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
