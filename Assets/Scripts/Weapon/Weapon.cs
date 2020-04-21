using Photon.Pun;
using Photon;
using UnityEngine;

public abstract class Weapon : MonoBehaviourPun
{
    private GameObject ShootPoint;
    private string WeaponName;
    private int WeaponDamage;
    private int WeaponBulletSpeed;
    private float WeaponCd;
    private float shootDelay = 0f;

    public Weapon(string WeaponName, int WeaponDamage, int WeaponBulletSpeed, float WeaponCd) {
        this.WeaponName = WeaponName;
        this.WeaponDamage = WeaponDamage;
        this.WeaponBulletSpeed = WeaponBulletSpeed;
        this.WeaponCd = WeaponCd;
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
        bullet.name = "bullet " + photonView.Owner.NickName;
        Rigidbody2D br = bullet.GetComponent<Rigidbody2D>();
        br.velocity = transform.right * WeaponBulletSpeed;
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
