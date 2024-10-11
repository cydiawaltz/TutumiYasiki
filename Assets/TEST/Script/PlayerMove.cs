using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float groundDrag;

    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Vector3 velocity;

    CharacterController controller;


    void Start()
    {
        // CharacterControllerの参照を取得
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 地面と接しているかを判断
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;  // プレイヤーを地面に固定するための処理
        }

        ProcessInput();
        MovePlayer();
    }

    private void ProcessInput()
    {
        // 入力を取得
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // 向いている方向に進む
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (this.gameObject.GetComponent<CharacterController>().enabled)
        {
            controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        // 重力を適用
        velocity.y += Physics.gravity.y * Time.deltaTime;
        if(this.gameObject.GetComponent<CharacterController>().enabled)
        {
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
