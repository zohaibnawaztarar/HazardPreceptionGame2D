using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float carSpeed;
    
    Vector3 pos;

    public float maxPos = 2.1f;

    public uiManager ui;

    public audioManager am;
    
    bool currentPlatformAndroid = false;
    
    void Awake()
    {
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

        }
        else
        {
            // input for window/linux
            pos.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            pos.x = Mathf.Clamp(pos.x, -2.1f, 2.1f);

            transform.position = pos;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
            ui.gameOverActivated();

            am.carSound.Stop ();
        }
    }
}
