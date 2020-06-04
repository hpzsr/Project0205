using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static FollowPlayer s_instance;

    float distance = 0;
    float scrollSpeed = 10;
    float rotateSpeed = 3;

    private Transform player = null;
    private Vector3 offSetPostion;//镜头位置偏移量
    private bool isRotating = true;//鼠标水平滑动

    void Start()
    {
        s_instance = this;
    }

    public void setTarget(GameObject _target)
    {
        player = _target.transform;
        offSetPostion = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        transform.position = offSetPostion + player.position;

        //处理视野的旋转
        RotateView();

        //处理视野的拉近拉远效果
        //ScrollView();
    }

    void ScrollView()
    {
        distance = offSetPostion.magnitude;                             // 返回向量的长度
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;   // 返回虚拟轴的值Mouse ScrollWheel：鼠标滑轮
        distance = Mathf.Clamp(distance, 2, 18);                        // 限制镜头最近和最远距离
        offSetPostion = offSetPostion.normalized * distance;
    }

    void RotateView()
    {
        if (isRotating)
        {
            // 横向旋转
            transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X"));

            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;

            // 纵向旋转
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));
            float x = transform.eulerAngles.x;
            if (x > 80 || x < 10)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }

            offSetPostion = transform.position - player.position;
        }
    }

    public float getRotateY()
    {
        return transform.eulerAngles.y;
    }
}