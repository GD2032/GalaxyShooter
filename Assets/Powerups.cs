using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<PlayerScript>().TripleShoot();
        }
    }
//    if (collision.gameObject.tag == "PowerUp1")
//        {
//            Turbo = true;
//            Destroy(PowerUp1);

//}
//        if (collision.gameObject.tag == "PowerUp2")
//        {
//            Shild = true;
//            Destroy(PowerUp2);
            
//        }
//        if (collision.gameObject.tag == "PowerUp3")
//        {
//            ETiro = true;
//            Destroy(PowerUp3);
           
//        }
}