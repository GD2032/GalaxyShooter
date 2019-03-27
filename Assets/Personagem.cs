using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float speed;
    public float antspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)){

            GetComponent<Rigidbody2D>().velocity = new Vector2( speed, 0f );

        }
        
    }
}
