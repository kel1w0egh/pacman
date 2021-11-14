using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Transform _transform;
    private Animator _animator;
    private Rigidbody _rigidbody;
    public float Speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity *= 0.95f;
        _animator.SetBool("KeyUnPass", true);
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("KeyUnPass", false);
            _animator.SetBool("MoveF", true);
            _animator.SetBool("MoveB", false);
            _rigidbody.AddForce(_transform.forward * Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("KeyUnPass", false);
            _animator.SetBool("MoveF", false);
            _animator.SetBool("MoveB", true);
            _rigidbody.AddForce(-_transform.forward * Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Animator>().Play("WalkLeft", 0, 0.25f);
            _transform.Rotate(0, (-80 * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Animator>().Play("WalkRight", 0, 0.25f);
            _transform.Rotate(0, (80 * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit(0);
        }
    }
}
