using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

   
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
