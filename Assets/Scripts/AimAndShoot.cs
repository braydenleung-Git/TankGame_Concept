using UnityEngine;
using System.Threading;
using UnityEngine.InputSystem;

public class AimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject Tank;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    public float maxRotationAngle = 45f;
    public float minRotationAngle = -3f;
    //public float aimDelay = 1f;
    public InputAction fireAction;
    private GameObject bulletInstance;
    //Add particle of the shell ??

    private float currentAngle;
    void Start()
    {
        fireAction.Enable();
    }
    void FixedUpdate()
    {
        handleBarrelRotation();
        handleShooting();
    }

    void handleBarrelRotation()
    {
        //currentAngle = Tank.transformAxis.z*Mathf.Rad2Deg;
        //Gets the current position of the cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        Vector3 direction = mousePosition - transform.position;
        //using Atan(Trig Ratio to Angles) to get the angle relative to the tank
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        //Offsetting angles of the tank such that the angle of the cannon is relative to tank
        minRotationAngle+=currentAngle;
        maxRotationAngle+=currentAngle;
        
        angle = Mathf.Clamp(angle, minRotationAngle, maxRotationAngle);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void handleShooting()
    {
        if(fireAction.triggered)
        {
            //spawn bullet
            bulletInstance = Instantiate(Bullet, bulletSpawnPoint.position,this.transform.rotation);
        }
    }
}
