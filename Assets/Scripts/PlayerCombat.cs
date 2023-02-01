using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shotPoint;

    private float timeBtwShoots;
    [SerializeField] private float startTimeBtwShoots;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shotPoint.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShoots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShoots = startTimeBtwShoots;
            }
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
