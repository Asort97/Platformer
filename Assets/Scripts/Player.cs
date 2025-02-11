using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float superJumpForce;
    [SerializeField] private float moveForce;
    [SerializeField] private float superMoveForce;
    [SerializeField] private Transform checkGroundPoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float superJumpTime;
    [SerializeField] private float moveTime;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private bool _isSuperJumped;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        CheckGround();

        if(_isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Jump();
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, superJumpForce);
                StartCoroutine(CheckHasReached());
            }
        }

        if(_isSuperJumped)
        {
            _rigidbody2D.velocity = new Vector2(superMoveForce, 0f);
        }
    }

    IEnumerator CheckHasReached()
    {
        yield return new WaitForSeconds(superJumpTime);
        _isSuperJumped = true;
        yield return new WaitForSeconds(moveTime);
        _rigidbody2D.velocity = new Vector2(0f, _rigidbody2D.velocity.y);
        _isSuperJumped = false;
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up*jumpForce + Vector2.right*moveForce, ForceMode2D.Impulse);
    }


    private void CheckGround()
    {
        // RaycastHit2D hit = Physics2D.Raycast(checkGroundPoint.position, -Vector2.up, 0.01f);
        Collider2D hit = Physics2D.OverlapCircle(checkGroundPoint.position, 1f, groundLayer);
        if(hit)
        {
            if(hit.transform.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
            else
            {
                _isGrounded = false;
            }
        }
        else
        {
            _isGrounded = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.SetParent(other.transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        transform.SetParent(null);
    }
}
