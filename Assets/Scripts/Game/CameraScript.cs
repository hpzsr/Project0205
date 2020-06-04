using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	
	public static CameraScript s_instance;

	bool rotate_left_right = true;
	bool rotate_up_down = true;

	GameObject target = null;
	float distance_2D = 0;
	float distance_3D = 0;
	float speed = 0.05f;
	float rotatespeed = 2;

	void Start () 
	{
		s_instance = this;

		// 把鼠标锁定到屏幕中间
		Cursor.lockState = CursorLockMode.Confined;
	}

	public void setTarget(GameObject _target)
	{
		target = _target;
		distance_2D = CommonUtil.twoObjDistance_2D(gameObject, target);
		distance_3D = CommonUtil.twoObjDistance_3D(gameObject, target);
	}

	public float getRotateY()
	{
		return transform.eulerAngles.y;
	}
	
	void FixedUpdate() 
	{
		if(target == null)
		{
			return;
		}

		// 调整相机上下左右角度
		{
			// 左右
			if (rotate_left_right)
			{
				float pianyi_x = Input.GetAxis("Mouse X");
				transform.RotateAround(target.transform.position, new Vector3(0, 1, 0), pianyi_x * rotatespeed);

				//transform.eulerAngles += new Vector3(0, pianyi_x * rotatespeed, 0);

				//// 设置相机位置
				//{
				//	float angle = transform.eulerAngles.y;
				//	float z = distance_2D * Mathf.Cos(CommonUtil.angleToRadian(angle));
				//	float x = distance_2D * Mathf.Sin(CommonUtil.angleToRadian(angle));
				//	transform.position = new Vector3(target.transform.position.x - x, transform.position.y, target.transform.position.z - z);
				//}

			}

			// 上下
			if (rotate_up_down)
			{
				float pianyi_y = Input.GetAxis("Mouse Y");
				transform.RotateAround(target.transform.position, new Vector3(1, 0, 0), -pianyi_y * rotatespeed);

				//transform.eulerAngles += new Vector3(-pianyi_y * rotatespeed, 0, 0);

				//// 限制上下角度
				//if (true)
				//{
				//	if (pianyi_y > 0)
				//	{
				//		if ((transform.eulerAngles.x > 270) && (transform.eulerAngles.x < 280))
				//		{
				//			transform.eulerAngles = new Vector3(280, 0, transform.eulerAngles.z);
				//		}
				//	}
				//	else if (pianyi_y < 0)
				//	{
				//		if ((transform.eulerAngles.x > 80) && (transform.eulerAngles.x < 90))
				//		{
				//			transform.eulerAngles = new Vector3(80, 0, transform.eulerAngles.z);
				//		}
				//	}
				//}

				// 设置相机位置
				//{
				//	float angle = transform.eulerAngles.x;
				//	float z = distance_3D * Mathf.Cos(CommonUtil.angleToRadian(angle));
				//	float y = distance_3D * Mathf.Sin(CommonUtil.angleToRadian(angle));
				//	transform.position = new Vector3(target.transform.position.x, target.transform.position.y + y, target.transform.position.z - z);
				//}
			}

			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,0);

			// 滚轮调整相机与地面距离
			{
				if(Input.mouseScrollDelta.y > 0)
				{
					transform.position += new Vector3(0,speed * 4,0);
				}
				else if (Input.mouseScrollDelta.y < 0)
				{
					transform.position -= new Vector3(0, speed * 4, 0);
				}
			}
		}
	}
}
