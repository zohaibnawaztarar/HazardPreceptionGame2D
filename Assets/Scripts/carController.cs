using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public float carSpeed;
    
    Vector3 pos;

    public float maxPos = 2.1f;
   
 

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
       pos.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

       pos.x = Mathf.Clamp(pos.x, -2.1f, 2.1f);

        transform.position = pos;

      


    }
}
