using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private float RotateSpeed;
    [SerializeField] private float Radius;

    private Vector2 _centre;
    private float _angle;
 
    private void Start()
    {
        _centre = transform.position;
    }
 
    private void Update()
    {
 
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle) * 1.5f, Mathf.Cos(_angle) * 0.4f) * Radius;
        transform.position = _centre + offset;
    }
}
        
