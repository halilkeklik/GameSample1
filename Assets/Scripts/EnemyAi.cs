using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAi : MonoBehaviour
{
    private const string LEFT = "left";
    private const string RIGHT = "right";
    private string facingDirection;
    [SerializeField] private Transform castPos;
    [SerializeField] private float baseCastDis;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    private Vector2 distance;
    Rigidbody2D rb2d;
    private Vector3 baseScale;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6,6);
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float vX = moveSpeed;
        
        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }

        distance = new Vector2(transform.position.x - player.transform.position.x,
            transform.position.y - player.transform.position.y);
        
        Vector2 current = new Vector2(transform.position.x, transform.position.y);
        Vector2 target = new Vector2(player.transform.position.x, transform.position.y);
        if (distance.x < 5 && -4 < distance.y && distance.y < 4) 
        {
            transform.position = Vector2.MoveTowards(current, target, moveSpeed * Time.deltaTime);
        }
        else
        {
            rb2d.velocity = new Vector2(vX, rb2d.velocity.y);
            if (isHittingWall() || isNearEdge())
            {
                if (facingDirection == LEFT)
                {
                    changeFacingDirection(RIGHT);
                }
                else
                {
                    changeFacingDirection(LEFT);
                }
            }
        }
    }

    void changeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;
        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;
        facingDirection = newDirection;
    }
    
    bool isHittingWall()
    {
        bool val = false;
        float castDist = baseCastDis;
        if (facingDirection == LEFT)
        {
            castDist = -baseCastDis;
        }
        else
        {
            castDist = baseCastDis;
        }

        Vector3 targetPos = castPos.position;
        targetPos.x += castDist / 5f;
        
        Debug.DrawLine(castPos.position,targetPos,Color.red);
        
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }
        
        return val;
    }
    
    bool isNearEdge()
    {
        bool val = true;
        float castDist = baseCastDis;

        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position,targetPos,Color.blue);
        
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }
        
        return val;
    }
}
