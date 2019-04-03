using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class top_hareket : MonoBehaviour
{
    bool durum1 = false;
    bool durum2 = false;
    bool bekleme = false;
    Vector3 ileri, zipla;
    public Text mesaj;
    public AudioSource ziplama;
    public Button gizle;


    void Start()
    {
        ileri = new Vector3(4, 0, 0);
        zipla = new Vector3(0, 300, 0);
        gizle.gameObject.SetActive(false);

    }


    void Update()
    {


        if (bekleme == false)
        {
            if (durum1)
            {
                transform.Translate(ileri * Time.deltaTime);
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        {
                            GetComponent<Rigidbody>().AddForce(zipla);
                            durum2 = true;
                            ziplama.Play();
                            break;
                        }

                    case TouchPhase.Ended:
                        {

                            break;
                        }


                }
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(zipla);
                durum2 = true;
                ziplama.Play();
            }


        }


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (durum2)
        {
            if (collision.gameObject.tag == "alt" || collision.gameObject.tag == "ust")
            {
                SceneManager.LoadScene("bayrak");
            }
        }

        if (collision.gameObject.tag == "direk")
        {
           // GetComponent<top_hareket>().enabled = false;
           // GetComponent<Rigidbody>().isKinematic = true;      
            bekleme = true;
            mesaj.text = "TEBRİKLER KAZANDINIZ!";
            gizle.gameObject.SetActive(true);
            GetComponent<Rigidbody>().isKinematic = true;


        }


    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "alt")
        {
            durum1 = true;
        }

    }


    public void yenidenBaslat()
    {
        SceneManager.LoadScene("bayrak");
    }
    
   
    
}
