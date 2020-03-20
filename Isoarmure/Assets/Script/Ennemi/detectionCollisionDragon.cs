using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionCollisionDragon : MonoBehaviour
{
    public PlayerCC player;
    ennemiController ennemi;
    float tempsAttaque = 1f;
    float cooldown;
    // Start is called before the first frame update

    private void Awake()
    {
        ennemi = GetComponent<ennemiController>();
    }
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Update is called once per frame
        if (player.getAnimationSwordLance())
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("HitSword") && Time.time > cooldown)
            {
                cooldown = Time.time + tempsAttaque;
                ennemi.RecevoirDegat(10);
                Debug.Log("Hit Sword ! ");

            }
        }
    }
}
