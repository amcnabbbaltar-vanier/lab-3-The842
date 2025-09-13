using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

   void Update()
   {

    //Button is released
    if (Input.GetButtonUp("Fire1"))
    {
        shootBullet();
        isCharging = false;
    }

    //Button is pressed
    if (Input.GetButtonDown("Fire1"))
    {
        chargeTime = 0.0f;
        isCharging = true;
    }

    //Button is held
    if (Input.GetButton("Fire1"))
    {
        chargeTime +=  Time.deltaTime;
        chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
    }
   }

   void shootBullet()
   {
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    Rigidbody rb = bullet.GetComponent<Rigidbody>();

    float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;

    rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
   }
}
