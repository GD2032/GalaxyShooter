using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool tripleShoot;
    int cont = 0;
    public GameObject laser;
    public GameObject escudo;
    public GameObject asteroide;
    public GameObject[] PowerUps;
    private GameObject PowerUp1;
    private GameObject PowerUp2;
    private GameObject PowerUp3;

    public float speed;
    public float antspeed;
    public float  fireRate = 1 ;
    public float nextFire= 0;
    public float asterouidePraChegar;
    public float TempodeAsteroide =0;
    float tempoCorrido;
    float tempoInicio = 0.5f;
    private int ContadorTripleShoot = 0;
    public bool ETiro;
    public bool Turbo;
    public bool Shild;
    public int NumeroPowerUps;
    public float PowerUpPraChegar;
    public float TempodePowerUp = 0;

    void Update()
    {
        PowerUp1 = GameObject.FindWithTag  ("PowerUp1");
        PowerUp2 = GameObject.FindWithTag("PowerUp2");
        PowerUp3 = GameObject.FindWithTag("PowerUp3");
        NumeroPowerUps = Random.Range(0, 3);
        if (Time.time >= TempodePowerUp)
        {
            TempodePowerUp = Time.time + PowerUpPraChegar;
            Vector2 posicao = new Vector2(Random.Range(9.0f, -9.0f), Random.Range(5.96f, -5.96f));
            Instantiate(PowerUps[NumeroPowerUps], posicao, Quaternion.identity);
        }
            if (Time.time >=TempodeAsteroide)
        {
            TempodeAsteroide = Time.time + asterouidePraChegar;
            Vector2 position = new Vector2(Random.Range(9.0f, -9.0f), 5.96f);
            Instantiate(asteroide, position, Quaternion.identity);
        }
        if (Turbo == true)
        {


            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(12, 0);

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(-12, 0);

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 12);

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -12);

            }
        }
        if (Turbo == false)
        {


            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(antspeed, 0);

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 6);

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -6);

            }
        }// ------------------------------------------
        if (transform.position.x <= -7.93f)
        {
            transform.position = new Vector2(-7.93f, transform.position.y);
        }
        if (transform.position.x >= 7.93f)
        {
            transform.position = new Vector2(7.93f, transform.position.y);
        }
        if (transform.position.y >= 3.84f)
        {
            transform.position = new Vector2(transform.position.x, 3.84f);
        }
        if (transform.position.y <= -3.84f)
        {
            transform.position = new Vector2(transform.position.x, -3.84f);
        }// ------------------------------------------
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ETiro == false)
            {
                Shoot();
            }
                if (ETiro)
                {
                    TripleShoot();
                    ContadorTripleShoot++;
                }
        }
        
        if (Shild)
        {
            escudo.GetComponent<SpriteRenderer>().enabled = true;
        }
        else { escudo.GetComponent<SpriteRenderer>().enabled = false; }
    }
    void Shoot() {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laser, transform.position + new Vector3(0, 0.8f), Quaternion.identity);

        }
        

        

    }
    void TripleShoot()
    {

        if (Time.time > nextFire)
        {
            tripleShoot = true;
            if(tripleShoot)
            Instantiate(laser, transform.position + new Vector3(0, 0.8f), Quaternion.identity);
            Instantiate(laser, transform.position + new Vector3(-0.4f, 0.2f), Quaternion.identity);
            Instantiate(laser, transform.position + new Vector3(0.4f, 0.2f), Quaternion.identity);
            StartCoroutine(coroutine);

        }


    }
     IEnumerator CorroutineTripleShoot()
    {
        yield return new WaitForSeconds(5);
        tripleShoot = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp1")
        {
            Turbo = true;
            Destroy(PowerUp1);
            
        }
        if (collision.gameObject.tag == "PowerUp2")
        {
            Shild = true;
            Destroy(PowerUp2);
            
        }
        if (collision.gameObject.tag == "PowerUp3")
        {
            ETiro = true;
            Destroy(PowerUp3);
           
        }
    }
}
