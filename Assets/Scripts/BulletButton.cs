using UnityEngine;

public class BulletButton : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text text;
    private bool toggle = false;

    private void Start()
    {
        text.SetText(BulletBehavior.bulletType.ToString());
    }
    public void OnButtonPress()
    {
        Debug.Log("Bullet type switched");
        if (toggle)
        {
            text.SetText("Normal");
            BulletBehavior.setBulletType(BulletBehavior.BulletType.Normal);
        }
        else
        {
            text.SetText("Physics");
            BulletBehavior.setBulletType(BulletBehavior.BulletType.Physics);
        }
    }
}
