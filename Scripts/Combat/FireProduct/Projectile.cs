using UnityEngine;
using ResourceClasses;

public class Projectile : MonoBehaviour
{

    private int Damage;
    private int Speed;
    private int TravelDist;
    private int EnemyPushVel;

    private Vector2 MoveDir;
    private Vector2 StartPos;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = MoveDir * Speed;

        if (Vector2.Distance(StartPos, transform.position) > TravelDist)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Resource>() != null)
        {
            //AttackDetails details = new AttackDetails(Damage, EnemyPushVel * MoveDir);
            //collision.GetComponent<Resource>().ModifyValue(details);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    public void SetData(int Damage, int Speed, int TravelDist, int EnemyPushVel, Vector2 MoveDir)
    {
        this.Damage = Damage;
        this.Speed = Speed;
        this.TravelDist = TravelDist;
        this.EnemyPushVel = EnemyPushVel;
        this.MoveDir = MoveDir;
    }

    public void SetRigidBodyRotation(float angle)
    {
        rb.rotation = angle;
    }
}
