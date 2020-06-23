using System.Collections;
using System.Collections.Generic;
using Tools.Monster;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
public class MonsterController : MonoBehaviour
{
    private const string DOWNABLE_PLATFORM_LAYER = "DownablePlatform";
    
    private Rigidbody2D _rigi2D;
    public Transform GroundCheck;
    
    public Vector2 moveInput;
    public float jumpSpeed;
    public float moveSpeed;
    
    [HideInInspector]
    public bool isGround = false;
    
    private MonsterInfo _monsterInfo;
    
     
    // Start is called before the first frame update
    void Awake()
    {
        _rigi2D = GetComponent<Rigidbody2D>();
         
        GloablManager.Instance.GameInput.MonsterControll.Jump.performed += callBack=>Jump();
        SetMonster(new MonsterInfo(MonsterSet.Get(1)));
    }

 
 
    public void SetMonster(MonsterInfo monsterInfo)
    {
        _monsterInfo = monsterInfo;
        GloablManager.Instance.PlayerInfo.currentMonster = monsterInfo;
    }
    public void Move(float moveDir)
    {
        _rigi2D.velocity = new Vector2( moveDir * moveSpeed,_rigi2D.velocity.y);
    }

     
    public void Jump()
    {
     
        if (!isGround)
        {
            return;
        }
     
        if (moveInput.y < 0)
        {
            var collider2D = Physics2D.OverlapCircle(GroundCheck.position, 2, LayerMask.GetMask(DOWNABLE_PLATFORM_LAYER));
            if (collider2D != null)
            {
                collider2D.GetComponent<PlatformEffector2D>().SetRotationOffset_180();
            }
        }
        else
        {
            JumpExcute();
        }
    }

    public void JumpExcute()
    {
        _rigi2D.velocity = new Vector2(_rigi2D.velocity.x, jumpSpeed);
    }
 
    // Update is called once per frame
    void Update()
    {
        
        if (_monsterInfo!=null)
        {
            foreach (var equipSkill in _monsterInfo.monSkillPool)
            {
                equipSkill.Value.skillSet.OnUpdate(this);
            }
        }
        moveInput = GloablManager.Instance.GameInput.MonsterControll.Move.ReadValue<Vector2>();
        isGround = Physics2D.OverlapCircle(GroundCheck.position,0.1f,LayerMask.GetMask(DOWNABLE_PLATFORM_LAYER)|LayerMask.GetMask("Ground")) && _rigi2D.velocity.y == 0;
    }

    private void FixedUpdate()
    {
        Move(moveInput.x);
    }
}
