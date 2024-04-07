using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUnit : MonoBehaviour, IUnit
{


    public UnitStatistics Stats { get; set; }

    public double CurrentHealthPoints;
    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; }
    public bool IsAttackingLeader { get; set; }


    private Rigidbody2D rb;

    public bool isPlayer;

    private BattleSystem battleSystem;

    private bool canAttack;
    private float attackCooldown;
    private float maxAttackCooldown;


    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletTimeToLive;


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
        IsAttackingLeader = false;

        isPlayer = _isPlayer;

        if (!isPlayer)
        {
            Stats.unitMovementSpeed *= -1.0;
        }

        CurrentHealthPoints = Stats.unitHealthPoints;

        attackCooldown = 1.0f / (float)Stats.unitAttackSpeed;
        maxAttackCooldown = attackCooldown;

        CurrentHealthPoints = Stats.unitHealthPoints;

        GetComponent<SpriteRenderer>().sprite = fraction.rangeUnit.unitSprite;
    }
    public void Attack(IUnit otherUnit)
    {
    }

    public void TakeDamage(double damage)
    {
        CurrentHealthPoints -= damage;
        CurrentHealthPoints = Mathf.Clamp((float)CurrentHealthPoints, 0.0f, (float)Stats.unitHealthPoints);
        if (CurrentHealthPoints <= 0.0f)
        {

            if(isPlayer)
            {
                battleSystem.enemyGold += Stats.unitGoldIncome;
            }
            else
            {
                battleSystem.playerGold += Stats.unitGoldIncome;
            }


            Destroy(gameObject);
        }
    }

    public void Move()
    {
        rb.velocity = new Vector2((float)Stats.unitMovementSpeed, 0);
    }

    public void Distance()
    {

    }

    public void AttackLeader()
    {
        battleSystem.onLeaderHit(!isPlayer, Stats.unitDamage);
    }

    private void AttackRange()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        string tag = "";
        string layer = "";
        Vector2 velocity = new Vector2(0.0f,0.0f);
        if (isPlayer)
        {
            tag = "PlayerBullet";
            layer = "PlayerBullet";
            velocity.x = (float)Stats.unitMovementSpeed * 2.0f;
        }
        else
        {
            tag = "EnemyBullet";
            layer = "EnemyBullet";
            float v = (float)Stats.unitMovementSpeed * 2.0f;
            if (v > 0.0f) v *= -1.0f;
            velocity.x = v;

        }
        bullet.gameObject.tag = tag;
        bullet.gameObject.layer = LayerMask.NameToLayer(layer);
        bullet.GetComponent<Bullet>().velocity = velocity;
        bullet.GetComponent<Bullet>().damage = Stats.unitDamage;


        Destroy(bullet, bulletTimeToLive);


    }


    private void FixedUpdate()
    {
        if (IsMoving)
            Move();

        if (attackCooldown > 0.0f)
        {
            attackCooldown -= Time.deltaTime;
        }
        else
        {
            AttackRange();
            attackCooldown = maxAttackCooldown;
        }


        if (IsAttackingLeader)
        {
            if (attackCooldown > 0.0f)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                AttackLeader();
                attackCooldown = maxAttackCooldown;
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(gameObject.tag == "PlayerUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("EnemyUnit"))
            {
                IsMoving = false;
                rb.velocity = Vector2.zero;
            }
        }

        if (gameObject.tag == "EnemyUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("PlayerUnit"))
            {
                IsMoving = false;
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
            }
        }

        if (gameObject.tag == "EnemyUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("PlayerUnit"))
            {
                IsMoving = true;
            }
        }
    }
}
