using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
   
    [Header("General Bullet Stats")]
    [SerializeField] private LayerMask whatDestroyBullet;
    [SerializeField] private float destroyAfter = 10f;
    
    
    [Header("Normal Bullet Stats")]
    [SerializeField] private float normalSpeed = 10f;
    
    [Header("Physics Bullet Stats")]
    [SerializeField] private float physicsSpeed = 15f;
    [SerializeField] private float gravityValue = 3f;
    private Rigidbody2D rb;

    public enum BulletType
    {
        Normal,
        Physics
    }
    public BulletType bulletType;

    private void Start()
    {
        //GetComponent<SpriteRenderer>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
        SetRBStats();
        SetDestroyTime();
        //set velocity based on bullet type 
        InitializeBulletStats();
    }
    private void InitializeBulletStats()
    {
        switch(bulletType)
        {
            case BulletType.Normal:
            rb.gravityScale = 0f;
            SetStraightVelocity();
            break;

            case BulletType.Physics:
            rb.gravityScale = gravityValue;
            SetPhysicsVelocity();
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision within the whatDestroyBullet layermask;
        if((whatDestroyBullet.value & (1<<collision.gameObject.layer))>0)
        {
            Destroy(gameObject);
        }
    }
    private void SetPhysicsVelocity()
    {
        rb.velocity = transform.right * physicsSpeed;
    }
    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalSpeed;
    }
    private void SetDestroyTime()
    {
        Destroy(gameObject,destroyAfter);
    }
    private void SetRBStats()
    {
        
    }
    private void FixedUpdate()
    {
        if(bulletType == BulletType.Physics)
        {
            transform.right = rb.velocity;
        }
    }
}
