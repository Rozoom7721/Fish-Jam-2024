using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : MonoBehaviour, IUnit
{
 

   
    public UnitStatistics Stats { get ; set; }
    public double CurrentHealthPoints { get ; set; }
    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; }

    private Rigidbody2D rb;

    public bool isPlayer;

    private IUnit otherUnit;

    private BattleSystem battleSystem;


    private void Awake()
    {
        Stats = GetComponent<UnitStatistics>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();

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
        GetComponent<SpriteRenderer>().sprite = fraction.meleeUnit.unitSprite;
    }

    public void Attack(IUnit otherUnit)
    {
        if(otherUnit != null)
        {

        }
        
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
        if(IsMoving)
            Move();
        
        if(IsAttacking)
        {
            Attack(otherUnit);
        }



    }


    private void getOtherUnitFromCollision(Collision2D collision)
    {
        MeleeUnit meleeUnit;
        collision.gameObject.TryGetComponent<MeleeUnit>(out meleeUnit);
        if (meleeUnit != null)
        {
            otherUnit = meleeUnit;
            return;
        }

        RangeUnit rangeUnit;
        collision.gameObject.TryGetComponent<RangeUnit>(out rangeUnit);
        if (rangeUnit != null)
        {
            otherUnit = rangeUnit;
            return;
        }

        TankUnit tankUnit;
        collision.gameObject.TryGetComponent<TankUnit>(out tankUnit);
        if (tankUnit != null)
        {
            otherUnit = tankUnit;
            return;
        }

        HealerUnit healerUnit;
        collision.gameObject.TryGetComponent<HealerUnit>(out healerUnit);
        if (healerUnit != null)
        {
            otherUnit = healerUnit;
            return;
        }
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
                getOtherUnitFromCollision(collision);

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
                getOtherUnitFromCollision(collision);

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
                otherUnit = null;
            }
        }

        if (gameObject.tag == "EnemyUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("PlayerUnit"))
            {
                IsMoving = true;
                IsAttacking = false;
                otherUnit = null;


            }
        }
    }

}
