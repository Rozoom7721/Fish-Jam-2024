using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnit : MonoBehaviour, IUnit
{

    public DamagePlay damagePlay;

    public UnitStatistics Stats { get; set; }

    public double CurrentHealthPoints;
    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; }

    public bool IsAttackingLeader { get; set; }

    private Rigidbody2D rb;

    public bool isPlayer;

    private IUnit otherUnit;

    private BattleSystem battleSystem;

    private bool canAttack;
    private float attackCooldown;
    private float maxAttackCooldown;


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

        attackCooldown = 1.0f / (float)Stats.unitAttackSpeed;
        maxAttackCooldown = attackCooldown;

        CurrentHealthPoints = Stats.unitHealthPoints;


        GetComponent<SpriteRenderer>().sprite = fraction.tankUnit.unitSprite;
    }

    public void Attack(IUnit otherUnit)
    {
        if (otherUnit != null)
        {

            float crit = Random.RandomRange(0.0f, 1.0f);
            double damage = Stats.unitDamage;
            if (crit < Stats.unitCriticalHitChance)
            {
                damage = damage * 2.0f;
            }

            otherUnit.TakeDamage(damage);
        }
    }

    public void TakeDamage(double damage)
    {
        damagePlay.playThisSoundEffect();

        CurrentHealthPoints -= damage;
        CurrentHealthPoints = Mathf.Clamp((float)CurrentHealthPoints, 0.0f, (float)Stats.unitHealthPoints);

        if (CurrentHealthPoints <= 0.0f)
        {

            if (isPlayer)
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
    private void FixedUpdate()
    {
        if (IsMoving)
            Move();

        if (IsAttacking)
        {

            if (attackCooldown > 0.0f)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                Attack(otherUnit);
                attackCooldown = maxAttackCooldown;
            }


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
                IsAttackingLeader = false;
                rb.velocity = Vector2.zero;
                getOtherUnitFromCollision(collision);
            }

            if (collision.gameObject.CompareTag("EnemyLeader"))
            {
                IsMoving = false;
                IsAttacking = false;
                IsAttackingLeader = true;
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
                IsAttackingLeader = false;

                rb.velocity = Vector2.zero;
                getOtherUnitFromCollision(collision);

            }

            if (collision.gameObject.CompareTag("PlayerLeader"))
            {
                IsMoving = false;
                IsAttacking = false;
                IsAttackingLeader = true;
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
                IsAttackingLeader = false;
                otherUnit = null;
            }

            if (collision.gameObject.CompareTag("EnemyLeader"))
            {
                IsMoving = true;
                IsAttacking = false;
                IsAttackingLeader = false;
            }
        }

        if (gameObject.tag == "EnemyUnit")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("PlayerUnit"))
            {
                IsMoving = true;
                IsAttacking = false;
                IsAttackingLeader = false;

            }

            if (collision.gameObject.CompareTag("PlayerLeader"))
            {
                IsMoving = true;
                IsAttacking = false;
                IsAttackingLeader = false;
            }
        }
    }
}
