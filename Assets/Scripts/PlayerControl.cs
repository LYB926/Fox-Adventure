using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, jumpForce;
    private float horizontalMove;
    bool jumpPressed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //获得组件 刚体
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }
    private void FixedUpdate()  //该函数会在一个固定帧率的帧时被调用
    {
        GroundMovement();
        Jump();
    }
    void GroundMovement()   //地面移动
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");  //只返回-1，0，1 获取整数
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1); //改变朝向
        }
    }
    void Jump() //跳跃
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);   //y轴纵向有跳跃力
            jumpPressed = false;
        }
    }
}