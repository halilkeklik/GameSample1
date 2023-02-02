using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    //Move
    [SerializeField] private float RotateSpeed;
    [SerializeField] private float Radius;
    private Vector2 _centre;
    private float _angle;
    //Projectile
    [SerializeField] private Transform player;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float attackRange; 
    private bool isRange;
    [SerializeField] private float startTimeBtwShoots;
    private float timeBtwShoots;
    //BigProjectile
    [SerializeField] private GameObject bigProjectile;
    [SerializeField] private float bStartTimeBtwShoots;
    private float bTimeBtwShoots;
    [SerializeField] private Health health;
    
    private void Start()
    {
        _centre = transform.position;
    }
 
    private void Update()
    {
        Move();
        Projectile();
        if (health.health <= health.maxHealth / 2)
        {
            BigProjectile();
        }
    }

    void Move()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle) * 1.2f, Mathf.Cos(_angle) * 0.4f) * Radius;
        transform.position = _centre + offset;
    }

    void Projectile()
    {
        Vector3 difference = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ-90f);

        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            if (timeBtwShoots <= 0)
            {
                Instantiate(projectile, shotPoint.position, shotPoint.transform.rotation);
                timeBtwShoots = startTimeBtwShoots;
            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }
    }

    void BigProjectile()
    {
        Vector3 difference = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ-90f);

        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            if (bTimeBtwShoots <= 0)
            {
                Instantiate(bigProjectile, shotPoint.position, shotPoint.transform.rotation);
                bTimeBtwShoots = bStartTimeBtwShoots;
            }
            else
            {
                bTimeBtwShoots -= Time.deltaTime;
            }
        }
    }
}
        
