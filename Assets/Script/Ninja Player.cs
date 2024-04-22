using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPlayer : Character
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;
    [SerializeField ]private bool isAttack;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 350;

    [SerializeField] private Kunai kunaiPrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private GameObject attackArea;

    private float horizontal;
    private bool isJumping;
    private bool isDeath = false;

    private int coin = 0;

    private Vector3 savePoint;
    // Start is called before the first frame update

    // Update is called once per frame
    //Move
    
    void FixedUpdate()
    {
        if (isDeath)
        {
            return;
        }
        isGrounded = CheckGrounded();
        //-1,0,1
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isAttack )
        {
            return;
        }
        if (isGrounded)
        {
            //jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (isJumping)
            {
                return;
            }
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                //Debug.Log("move");
                ChangeAnim("Run");
            }
            //attack
            if (Input.GetKeyDown(KeyCode.Q)&& isGrounded)
            {
                Attack();

            }

            //throw
            if (Input.GetKeyDown(KeyCode.E) && isGrounded)
            {
                Throw();

            }
        }
        // check falling
        if (!isGrounded && rb.velocity.y < 0)
        {
            ChangeAnim("Fall");
            isJumping = false;
        }

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            ChangeAnim("Run");
            rb.velocity = new Vector2 (horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal >0 ? 0 : 180, 0));
            // horizontal > 0 -> tra ve 0 , ko thì tra ve 180
            //transform.localScale = new Vector3(horizontal, 1, 1);
        }
        else if(isGrounded)
        {
            ChangeAnim("Idle");
            rb.velocity = Vector2.zero;
        }
    }
    public override void OnInit()
    {
        base.OnInit();

        isDeath = false;
        isAttack = false;

        transform.position = savePoint;

        ChangeAnim("Idle");

        DeactiveAttack();

        savePoint = transform.position;
        SavePoint();
    }

    public override void OnDesparm()
    {
        base.OnDesparm();

        OnInit();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        //if (hit != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return hit.collider != null;
    }

    private void Attack()
    {
        ChangeAnim("Attack");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
        ActiveAttack();
        Invoke(nameof(DeactiveAttack), 1f); 

    }

    private void Throw()
    {
        ChangeAnim("Throw");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);

        Instantiate(kunaiPrefab, throwPoint.position, throwPoint.rotation);
    }

    private void ResetAttack()
    {
        ChangeAnim("Idle");
        isAttack = false;
    }
    private void Jump()
    {
        isJumping = true;
        ChangeAnim("Jump");
        rb.AddForce(jumpForce * Vector2.up);
    }


    internal void SavePoint()
    {
        savePoint = transform.position;
    }

    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }

    private void DeactiveAttack()
    {
        attackArea.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin") 
        {
            coin++;
            Destroy(collision.gameObject);  
        }
        if (collision.tag == "Deadzone")
        {
            isDeath = true;
            ChangeAnim("Dead");

            Invoke(nameof(OnInit), 1f) ;
        }    
    }
}

