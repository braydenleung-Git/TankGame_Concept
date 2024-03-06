using UnityEngine;
using System.Threading;
using UnityEngine.InputSystem;

public class AimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject Tank;
    [SerializeField] private GameObject barrelPivot;
    [SerializeField] private GameObject bullet;
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
        //Gets the current position of the cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        Vector3 direction = (mousePosition - transform.position).normalized;
        //using Atan(Trig Ratio to Angles) to get the angle relative to the tank
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        //Offsetting angles of the tank such that the angle of the cannon is relative to tank
        currentAngle = Tank.transform.rotation.normalized.eulerAngles.z;//The current angle of the tank
        if(currentAngle > 180)
        {
            //change the angles from 180-360, to less than 180
            currentAngle -= 360;
            currentAngle = Mathf.Abs(currentAngle);
        }
        //Debug.Log(currentAngle);
        float rotated_Angles = Mathf.Clamp(angle, minRotationAngle+Mathf.Abs(currentAngle),maxRotationAngle+Mathf.Abs(currentAngle));
        barrelPivot.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,rotated_Angles));
    }
    void handleShooting()
    {
        if(fireAction.triggered)
        {
            //spawn bullet
            //Debug.Log("Bullets triggered ");
            bulletInstance = Instantiate(bullet, bulletSpawnPoint.position,barrelPivot.transform.rotation);
        }
    }
}
