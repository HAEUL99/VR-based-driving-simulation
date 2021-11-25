﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteNavigationController_hj : MonoBehaviour
{
    public float movementSpeed = 1;
    public float rotationSpeed = 120;
    public float stopDistance = 2f;
    public Animator animator;
    public bool reachedDestination;

    public Vector3 destination;
    public Vector3 lastPosition;
    Vector3 velocity;

    private void Awake()
    {
        //움직이는 속도 랜덤값 주기
        //movementSpeed = Random.Range(0.8f, 2f);
        movementSpeed = Random.Range(0.0f, 0.2f);
        // Animation 갖고오기
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 목적지와 객체의 포지션이 일치하지 않으면, 
        if (transform.position != destination) 
        {
            // 목적지로의 벡터를 구함
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            // 목적지까지의 거리 변수
            float destinationDistance = destinationDirection.magnitude;
            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                // destinationDirectin으로 방향 회전하고, 이동
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else 
            {
                reachedDestination = true;
            }
            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            // velocityMagnitude는 velocity의 크기를 갖는다
            float velocityMagnitude = velocity.magnitude;
            //velocity는 방향 벡터
            velocity = velocity.normalized;
            // Dot: 두벡터의 벡터곱
            // fwdDotProduct = 앞과 진행방향의 벡터곱
            // rightDotProduct = 오른쪽방향과 진행방향의 벡터곱
            float fwdDotProcduct = Vector3.Dot(transform.forward, velocity);
            float rightDotProduct = Vector3.Dot(transform.right, velocity);
    
            animator.SetFloat("right_left", rightDotProduct);
            animator.SetFloat("farward", fwdDotProcduct);

        }

        lastPosition = transform.position;
    }


    public void SetDestination(Vector3 destination) 
    {
        this.destination = destination;
        reachedDestination = false;
    }

}
