using System;
using Framework.Game;
using UnityEngine;

namespace Framework.Level
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class LevelMovement : MonoBehaviour
    {
        [HideInInspector] public BoxCollider2D box;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            box = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            _rigidbody.velocity = new Vector2(0, -GameManager.Instance.levelSpeed);
        }

        private void Update()
        {
            if (transform.position.y < -16f)
                Destroy(gameObject);
        }
    }
}
