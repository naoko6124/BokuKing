using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Shared.Player.Scripts
{
    public class JumpMovement : MonoBehaviour
    {
        [Header("Animation")]
        public Animator animator;
        
        [Header("Jump")]
        public float jumpForce;
        public float timerMax;

        [Header("Materials")]
        public PhysicsMaterial2D bouncy;
        public PhysicsMaterial2D noBouncy;
        
        [Header("Debug")]
        public Vector2 moveInput;
        public float timer;

        private bool _holding;
        
        private GameInput _input;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _sprite;
        
        public void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _sprite = animator.gameObject.GetComponent<SpriteRenderer>();
            
            _input = new GameInput();
            _input.Enable();

            _input.Movement.Touch.performed += StartTouch;
            _input.Movement.Touch.canceled += EndTouch;
        }
        
        public void OnDisable()
        {
            _input.Movement.Disable();
            _input.Disable();
            _input.Dispose();
            _input = null;
        }

        private void Update()
        {
            if (_holding)
                timer += Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.y > 0f)
            {
                _rigidbody.gravityScale = 3.0f;
                _rigidbody.sharedMaterial = bouncy;
            }
            else if (_rigidbody.velocity.y < 0f)
            {
                _rigidbody.gravityScale = 5.0f;
                _rigidbody.sharedMaterial = noBouncy;
            }
            
            animator.SetFloat("Speed", _rigidbody.velocity.y);
            
            if (_rigidbody.velocity.x > 0f)
                _sprite.flipX = false;
            if (_rigidbody.velocity.x < 0f)
                _sprite.flipX = true;
        }

        private void StartTouch(InputAction.CallbackContext context)
        {
            if (!gameObject.activeInHierarchy) return;
            
            _holding = true;
            timer = 0f;
            animator.SetBool("Crouch", true);
        }
        private void EndTouch(InputAction.CallbackContext context)
        {
            if (!gameObject.activeInHierarchy) return;
            
            _holding = false;
            Vector2 screenInput = _input.Movement.Position.ReadValue<Vector2>();
            moveInput = Camera.main.ScreenToWorldPoint(screenInput);
            Vector2 direction = moveInput - new Vector2(transform.position.x, transform.position.y);
            direction.Normalize();
            timer = Mathf.Clamp(timer, 0f, timerMax) / timerMax;
            _rigidbody.AddForce(direction * jumpForce * timer, ForceMode2D.Impulse);

            StartCoroutine(WaitAndDo(0.1f, () =>
            {
                animator.SetBool("Crouch", false);
            }));
        }
        
        IEnumerator WaitAndDo (float time, Action action) {
            yield return new WaitForSeconds (time);
            action();
        }
    }
}
