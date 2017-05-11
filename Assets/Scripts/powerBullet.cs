using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerBullet : MonoBehaviour {

    void Start()
    {
    }
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Blocker")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

        }

    }
}
