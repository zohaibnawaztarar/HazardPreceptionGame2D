﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float carSpeed;
    
    Vector3 pos;

    public float maxPos = 2.1f;

    public uiManager ui;

    public audioManager am;
    
    bool currentPlatformAndroid = true;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();

       // Remove below comments to test on android

      /* #if UNITY_ANDROID
        currentPlatformAndroid = true;
       #else
        currentPlatformAndroid = false;
       #endif */

        am.carSound.Play ();
    }

    // Start is called before the first frame update
    void Start()
    {
        //am.carSound.Play ();
        pos = transform.position;

        // code for debugging
        if (currentPlatformAndroid == true)
        {
            Debug.Log("Android");
           
        }
        else
        {
            Debug.Log("Windows");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlatformAndroid == true)
        {
            //input for android only
            // TouchMove ();  /// to enable touch button move

            AccelerometerMove ();

        }
        else
        {
            
            // input for window/linux
           // pos.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            //pos.x = Mathf.Clamp(pos.x, -2.1f, 2.1f);

            //transform.position = pos;
        }
        pos = transform.position;
         pos.x = Mathf.Clamp(pos.x, -2.1f, 2.1f);

         transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy Car")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            ui.gameOverActivated();

            am.carSound.Stop ();
        }
    }

    void TouchMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            float middle = Screen.width/2;
            if(touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft(); 
            }

            else if(touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight(); 
            }

            else
            {
                SetVelocityZero();
            }
        }
    }

    void AccelerometerMove()
    {
        float x = Input.acceleration.x;
        if (x < -0.2f )
        {
            MoveLeft();
        }
        else if (x > 0.2f )
        {
            MoveRight();
        }
        else
        {
            SetVelocityZero();
        }
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }
}
