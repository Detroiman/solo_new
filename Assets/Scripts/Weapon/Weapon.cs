using Photon.Pun;
using Photon;
using UnityEngine;

public abstract class Weapon : MonoBehaviourPun
{
    private GameObject ShootPoint;
    private string WeaponName;
    private int WeaponDamage;
    private float WeaponBulletSpeed;
    private float WeaponCd;
    private float WeaponBulletDistance;
    private float shootDelay = 0f;

    public Weapon(string WeaponName, int WeaponDamage, float WeaponBulletSpeed, float WeaponCd, float WeaponBulletDistance) {
        this.WeaponName = WeaponName;
        this.WeaponDamage = WeaponDamage;
        this.WeaponBulletSpeed = WeaponBulletSpeed;
        this.WeaponCd = WeaponCd;
        this.WeaponBulletDistance = WeaponBulletDistance;
    }

    public void Shoot() {

        if (shootDelay >= WeaponCd)
        {
            photonView.RPC("RPCShoot", RpcTarget.All);
            shootDelay = 0f;
        }
       

    }
    [PunRPC]
    public void RPCShoot() {
        GameObject bullet = Instantiate((GameObject)Resources.Load("Bullet"), ShootPoint.transform.position, ShootPoint.transform.rotation);
        bullet.name = photonView.Owner.NickName;
        Rigidbody2D br = bullet.GetComponent<Rigidbody2D>();
        Bullet brsc = bullet.GetComponent<Bullet>();      
        brsc.setBullet(WeaponDamage, WeaponBulletSpeed, WeaponBulletDistance);
        
    }
    private void Start()
    {
        shootDelay = WeaponCd;
        foreach (Transform t in gameObject.transform) {
            if (t.tag == "FirePoint") {
                ShootPoint = t.gameObject;
            
            }      
        }
        WeaponStart();
    }
    private void Update()
    {
        shootDelay += Time.deltaTime;
        WeaponUpdate();
    }
    public abstract void WeaponStart();
    public abstract void WeaponUpdate();
    
    
}
