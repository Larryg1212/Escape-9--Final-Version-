using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Imp")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

        }
      
    }
}
