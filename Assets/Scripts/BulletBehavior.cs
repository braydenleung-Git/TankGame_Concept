using UnityEngine;

/*
 Current issues :
    bullet destroy's itself after the timer, instead of "spawning" other instances of the bullet
 */

public class BulletBehavior : MonoBehaviour
{
    public enum BulletType
    {
        Normal,
        Physics,
        Dummy
    }
    [Header("Game Object passthrough")]
    [SerializeField] private GameObject bullet;

    [Header("General Bullet Stats")]
    [SerializeField] public BulletType bulletType;
    [SerializeField] private LayerMask whatDestroyBullet;
    [SerializeField] private float destroyAfter = 10f;
    [SerializeField] private float scaleChanges = 10f;
    
    
    [Header("Normal Bullet Stats")]
    [SerializeField] private float normalSpeed = 10f;
    
    [Header("Physics Bullet Stats")]
    [SerializeField] private float physicsSpeed = 15f;
    [SerializeField] private float gravityValue = 3f;
    private Rigidbody2D rb;

   

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x+scaleChanges, transform.localScale.y + scaleChanges, transform.localScale.z + scaleChanges);
        rb = bullet.GetComponent<Rigidbody2D>();
        SetDestroyTime();
        //set velocity based on bullet type 
        InitializeBulletStats();
    }
    private void InitializeBulletStats()
    {
        //Debug.Log("Bullet type:" + bulletType);
        //Debug.Log(BulletType.Normal);
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

            case BulletType.Dummy:
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision within the whatDestroyBullet layermask;
        if((whatDestroyBullet.value & (1<<collision.gameObject.layer))>0)
        {
            Destroy(bullet);
        }
    }
    private void SetPhysicsVelocity()
    {
        rb.velocity = bullet.transform.right * physicsSpeed;
    }
    private void SetStraightVelocity()
    {
        rb.velocity = bullet.transform.right * normalSpeed;
    }
    private void SetDestroyTime()
    {
        Destroy(bullet,destroyAfter);
    }
   
    private void FixedUpdate()
    {
        if(bulletType == BulletType.Physics)
        {
            bullet.transform.right = rb.velocity;
        }
    }
    public void setBulletType(BulletType type)
    {
        bulletType = type;
    }
    public BulletType getBulletType()
    {
        return bulletType;
    }
}
