using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public Collider2D astroide;
    Laser laser;
    public GameObject piuPiu;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 2);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Laser")
        {
            Destroy(this.gameObject);
        }
        
       
    }
}
