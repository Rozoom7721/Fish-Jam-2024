using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public double damage;
    public Vector2 velocity;
    private IUnit otherUnit;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
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
        if (gameObject.tag == "PlayerBullet")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("EnemyUnit"))
            {
                getOtherUnitFromCollision(collision);
                otherUnit.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "EnemyBullet")
        {
            // Jeœli jednostka koliduje z jednostk¹ przeciwnika, zatrzymaj siê
            if (collision.gameObject.CompareTag("PlayerUnit"))
            {
                getOtherUnitFromCollision(collision);
                otherUnit.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

    }
}
