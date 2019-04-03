using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direk_temas : MonoBehaviour
{
    public AudioSource hedefe_ulasma;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "top")
        {
            hedefe_ulasma.Play();
        }
    }
}
