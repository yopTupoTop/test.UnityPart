using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * _rotSpeed;
        float move = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.rotation *= Quaternion.Euler(0f, rotation, 0f);
        rb.MovePosition(transform.position + transform.forward * move);
    }
}
