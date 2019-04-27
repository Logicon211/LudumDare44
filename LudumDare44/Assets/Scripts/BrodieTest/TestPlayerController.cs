using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{

    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float verticalSpeed = speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        
        transform.position += new Vector3(horizontalSpeed, verticalSpeed);
    }
}
