using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 1f;
    private Rigidbody2D _rb;
    private bool _isFacingRight;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _isFacingRight = true;
        _isGrounded = true;
    }
    
    // FixedUpdate is for physics
    void FixedUpdate() {
    }

    // Update is called once per frame
    void Update() {
        float xInput = Input.GetAxis("Horizontal");

        //If we are facing right and moving left, or facing left and moving right, flip the way the character is facing
        if ((xInput < 0 && _isFacingRight) || (xInput > 0 && !_isFacingRight)) {
            FlipFacing();
        }

        _isGrounded = IsGrounded();
        if (Input.GetButton("Jump") && _isGrounded) {
            _isGrounded = false;
            _rb.AddForce(new Vector2(0f, _jumpForce));
        }

        float movement = xInput * _speed;// * Time.deltaTime;

        _rb.velocity = new Vector2(movement, _rb.velocity.y);
    }

    private void FlipFacing() {
        _isFacingRight = !_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private bool IsGrounded() {
        bool touchingLayer = _rb.IsTouchingLayers(LayerMask.GetMask("Ground"));

        ContactPoint2D[] contactPoints = new ContactPoint2D[5];
        _rb.GetContacts(contactPoints);
        for (int i = 0; i < contactPoints.Length; i++) {
            ContactPoint2D contactPoint = contactPoints[i];
            if (contactPoint.normal.Equals(Vector2.up)) {
                return true && touchingLayer;
            }
        }
        return false;
    }
}
