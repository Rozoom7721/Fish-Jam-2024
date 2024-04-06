using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerUnit : MonoBehaviour, IUnit
{

 
    public UnitStatistics Stats { get; set; }


    public double CurrentHealthPoints { get; set; }
    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; }

    public bool isPlayer;

    private Rigidbody2D rb;

    private void Awake()
    {
        Stats = GetComponent<UnitStatistics>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = spriteRenderer.bounds.size;
        }
    }
    public void init(Fraction fraction, bool _isPlayer)
    {
        Stats.init(fraction);
        IsMoving = true;
        isPlayer = _isPlayer;
        GetComponent<SpriteRenderer>().sprite = fraction.healerUnit.unitSprite;
    }

    public void Attack(IUnit otherUnit)
    {

    }

    public void TakeDamage(double damage)
    {

    }

    public void Move()
    {
        rb.velocity = new Vector2((float)Stats.unitMovementSpeed, 0);
    }

    public void Distance()
    {

    }

    private void FixedUpdate()
    {
        if (IsMoving)
            Move();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (gameObject.tag == "PlayerUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("EnemyUnit"))
            {
                IsMoving = false;
                IsAttacking = true;
                rb.velocity = Vector2.zero;
            }
        }

        if (gameObject.tag == "EnemyUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("PlayerUnit"))
            {
                IsMoving = false;
                IsAttacking = true;

                rb.velocity = Vector2.zero;
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.tag == "PlayerUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("EnemyUnit"))
            {
                IsMoving = true;
                IsAttacking = false;
            }
        }

        if (gameObject.tag == "EnemyUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("PlayerUnit"))
            {
                IsMoving = true;
                IsAttacking = false;

            }
        }
    }

}
