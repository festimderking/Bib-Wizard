using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Fireball")]
    public GameObject Fireball;
    public GameObject circle;

    [Header("Mana System")]
    public float maxMana = 100f;
    public float currentMana;
    public float manaRegenRate = 5f;
    public float manaRegenInterval = 1f;
    private float manaTimer = 0f;
    public float spellCost = 20f;
    public Slider manaBar;

    private Rigidbody2D rigidbody;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        currentMana = maxMana;
        if (manaBar != null)
        {
            manaBar.maxValue = maxMana;
            manaBar.value = currentMana;
        }
    }

    void Update()
    {
        float x = 0, y = 0;

        if (Input.GetKey("w")) y = 1;
        if (Input.GetKey("s")) y = -1;
        if (Input.GetKey("a")) x = -1;
        if (Input.GetKey("d")) x = 1;

        Vector3 diagonal = new Vector3(x, y, 0).normalized;
        transform.position += diagonal * speed * Time.deltaTime;

        if (x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (x > 0)
            transform.localScale = new Vector3(1, 1, 1);

        animator.SetBool("move", x != 0 || y != 0);

        // Zauber (nur wenn genug Mana)
        if (Input.GetKeyDown("space") && currentMana >= spellCost)
        {
            currentMana -= spellCost;
            if (manaBar != null) manaBar.value = currentMana;

            GameObject fireball = Instantiate(Fireball, circle.transform.position, Quaternion.identity);
            Rigidbody2D fireballRigidbody = fireball.GetComponent<Rigidbody2D>();
            if (fireballRigidbody != null)
            {
                Vector2 direction = new Vector2(x, y).normalized;
                if (direction == Vector2.zero) direction = Vector2.right; // Standardrichtung
                fireballRigidbody.velocity = direction * 10f;
            }
        }

        // Mana-Regeneration
        manaTimer += Time.deltaTime;
        if (manaTimer >= manaRegenInterval)
        {
            currentMana += manaRegenRate;
            currentMana = Mathf.Min(currentMana, maxMana);
            manaTimer = 0f;
            if (manaBar != null) manaBar.value = currentMana;
        }
    }
}
