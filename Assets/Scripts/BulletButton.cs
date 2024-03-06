using UnityEngine;

public class BulletButton : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private GameObject bullet;
    private bool toggle = false;
    private BulletBehavior script;

    private void Start()
    {
        script = bullet.GetComponent<BulletBehavior>();
        text.SetText(script.getBulletType().ToString());
    }
    public void OnButtonPress()
    {
        Debug.Log("Bullet type switched");
        if (toggle)
        {
            text.SetText("Normal");
            script.setBulletType(BulletBehavior.BulletType.Normal);
        }
        else
        {
            text.SetText("Physics");
            script.setBulletType(BulletBehavior.BulletType.Physics);
        }
    }
}
