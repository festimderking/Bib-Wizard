using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zielscheibe : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
