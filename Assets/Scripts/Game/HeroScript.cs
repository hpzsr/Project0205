using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour {

    Animator animator;
	CharacterController characterController;
	float speed = 0.05f;
    Consts.HeroState state = Consts.HeroState.idle;
    bool canMove = true;
    bool isAtking = false;

    void Start () {
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();
        Invoke("startGame", 0.2f);

        //Event.registerEvent("1",(Event.EventCallBackData data) =>
        //{
        //    Debug.Log("事件1回调");
        //});
        //Event.registerEvent("2", (Event.EventCallBackData data) =>
        //{
        //    Debug.Log("事件2回调");
        //});
    }

    void startGame()
    {
        FollowPlayer.s_instance.setTarget(gameObject);
    }

    void Update()
    {
    }
	
	void LateUpdate () {
        if (!characterController.isGrounded)
        {
            characterController.Move(Vector3.down * 10.0f);        // 10.0f代表重力
        }

        // 按键攻击
        {
            if (Input.GetMouseButtonDown(0))
            {
                setHeroState((Consts.HeroState)RandomUtil.getRandom(5, 8));
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                setHeroState(Consts.HeroState.atk1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                setHeroState(Consts.HeroState.atk2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                setHeroState(Consts.HeroState.atk3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                setHeroState(Consts.HeroState.atk4);
            }
        }

        if (canMove)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY() - 45, 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY() + 45, 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY() - 135, 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY() + 135, 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY(), 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY() - 90, 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY() + 180, 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, FollowPlayer.s_instance.getRotateY() + 90, 0);
                characterController.Move(transform.forward * speed);
                setHeroState(Consts.HeroState.run);
            }
            else if ((state == Consts.HeroState.walk) || (state == Consts.HeroState.run))
            {
                setHeroState(Consts.HeroState.idle);
            }
        }
    }

    public void Atk1_End()
    {
        setHeroState(Consts.HeroState.idle);
        canMove = true;
        isAtking = false;
    }

    public void Atk2_End()
    {
        setHeroState(Consts.HeroState.idle);
        canMove = true;
        isAtking = false;
    }

    public void Atk3_End()
    {
        setHeroState(Consts.HeroState.idle);
        canMove = true;
        isAtking = false;
    }

    public void Atk4_End()
    {
        setHeroState(Consts.HeroState.idle);
        canMove = true;
        isAtking = false;
    }

    public void setHeroState(Consts.HeroState _state)
    {
        //Debug.Log(_state + "   " + state);

        if(_state == state)
        {
            return;
        }
        switch(_state)
        {
            case Consts.HeroState.idle:
                {
                    animator.Play("Idle_A");
                    break;
                }

            case Consts.HeroState.walk:
                {
                    animator.Play("Walk");
                    break;
                }

            case Consts.HeroState.run:
                {
                    animator.Play("Run");
                    break;
                }

            case Consts.HeroState.jump:
                {
                    animator.Play("Jump");
                    break;
                }

            case Consts.HeroState.die:
                {
                    animator.Play("DieA");
                    break;
                }

            case Consts.HeroState.atk1:
                {
                    if(isAtking){return;}

                    canMove = false;
                    isAtking = true;
                    animator.Play("Atk1");
                    break;
                }

            case Consts.HeroState.atk2:
                {
                    if (isAtking) { return; }

                    canMove = false;
                    isAtking = true;
                    animator.Play("Atk2");
                    break;
                }

            case Consts.HeroState.atk3:
                {
                    if (isAtking) { return; }

                    canMove = false;
                    isAtking = true;
                    animator.Play("Atk3");
                    break;
                }

            case Consts.HeroState.atk4:
                {
                    if (isAtking) { return; }

                    canMove = false;
                    isAtking = true;
                    animator.Play("Atk4");
                    break;
                }

            case Consts.HeroState.damage:
                {
                    animator.Play("Damage");
                    break;
                }
        }

        state = _state;

        // animator.SetInteger("HeroState", (int)state);
    }
}
