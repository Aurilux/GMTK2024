using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 30f;
    private Rigidbody2D _rb;
    private bool _isFacingRight;
    private bool _isGrounded;
    private GameObject _jekyllObject;
    private GameObject _hydeObject;
    private GameObject _activeCharacter;
    private PlayerCapabilities playerCapabilities;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        playerCapabilities = GetComponent<PlayerCapabilities>();
        _isFacingRight = true;
        _isGrounded = true;
        _jekyllObject = transform.GetChild(0).gameObject;
        _hydeObject = transform.GetChild(1).gameObject;
    }
    
    // FixedUpdate is for physics
    void FixedUpdate() {
    }

    // Update is called once per frame
    void Update() {
        float xInput = Input.GetAxis("Horizontal");
        if (playerCapabilities._isJekyll) {
            _activeCharacter = _jekyllObject;
        }
        else {
            _activeCharacter = _hydeObject;
        }

        if (xInput != 0f) {
            _activeCharacter.GetComponent<Animator>().SetBool("Walking", true);
            //If we are facing right and moving left, or facing left and moving right, flip the way the character is facing
            if ((xInput < 0 && _isFacingRight) || (xInput > 0 && !_isFacingRight)) {
                FlipFacing();
            }
        }
        else {
            _activeCharacter.GetComponent<Animator>().SetBool("Walking", false);
        }

        _isGrounded = IsGrounded();
        if (_isGrounded) {
            _activeCharacter.GetComponent<Animator>().SetBool("Jumping", false);
            if (Input.GetButton("Jump") && playerCapabilities._isJekyll) {
                _isGrounded = false;
                _rb.AddForce(new Vector2(0f, _jumpForce));
                _activeCharacter.GetComponent<Animator>().SetBool("Jumping", true);
            }
        }

        float movement = xInput * (_isGrounded ? _speed : (_speed / 2));// * Time.deltaTime;

        _rb.velocity = new Vector2(movement, _rb.velocity.y);
    }

    private void FlipFacing() {
        _isFacingRight = !_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private bool IsGrounded() {
        return _rb.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
