using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
  public float speed = 5f;
    public GameObject Fireball;
    private Rigidbody2D rigidbody;
   
    public GameObject circle;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
      // rigidbody.velocity = Vector2.up;             
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0 , y = 0;

        if (Input.GetKey("w")) y = 1;
        if (Input.GetKey("s")) y = -1;
        if (Input.GetKey("a")) x = -1;
        if (Input.GetKey("d")) x = 1;

        Vector3 diagonal = new Vector3(x, y, 0).normalized;
        
        transform.position += diagonal * speed * Time.deltaTime ;

        if (Input.GetKeyDown("space"))
        {
            GameObject fireball = Instantiate(Fireball, circle.transform.position, Quaternion.identity);

        }
     //   Instantiate(prefab, Vector3.zero, Quaternion.identity);
     //   Destroy(obj, 5);
    
    }
}
