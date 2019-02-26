using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject[] ecars;
    int carNo;
    public float maxPos = 2.1f;

    public float delayTimer = 1.5f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) { 
        Vector3 carPos = new Vector3(Random.Range(-2.1f, 2.1f), transform.position.y, transform.position.z);
            carNo = Random.Range (0,4);
            Instantiate(ecars[carNo], carPos, transform.rotation);
            timer = delayTimer;
        }
    }

}
