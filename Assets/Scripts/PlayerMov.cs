using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;

    Shooter shooter;

    void Awake()
    {
       shooter = GetComponent<Shooter>();   
    }

    void Start ()
    {
       InitBounds();
    }
    void Update()
    {
        Movement();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Movement()
    {
        Vector2 delta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPos = new()
        {
            x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingRight, maxBounds.x - paddingLeft),
            y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y+ paddingBottom, maxBounds.y- paddingTop)

        };
        transform.position = newPos;
        
          /* Vector2 newPos = new Vector2();
           newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
           newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
           (this is the lecture version, the one currently in use is recomm by vscode)  */
    
        float paddingHorizontal = gameObject.GetComponentInChildren<Renderer>().bounds.extents.x;
        float paddingVertical = gameObject.GetComponentInChildren<Renderer>().bounds.extents.y;
        float paddingX = paddingHorizontal/2f;
        float paddingY = paddingVertical/2f;
        paddingTop = paddingX + 5;
        paddingBottom =paddingX +2;
        paddingLeft = paddingY + 0.5f;
        paddingRight = paddingY + 0.5f; 
    }


    void OnMove(InputValue value)
    {
       rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
       if (shooter != null)
       {
         shooter.isFiring = value.isPressed;
       }
    }
}
