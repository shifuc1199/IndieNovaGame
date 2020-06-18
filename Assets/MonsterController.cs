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
    private MonsterControlInput _input ;

    private Vector2 moveInput;
    public float jumpSpeed;
    public float moveSpeed;

    public Transform GroundCheck;

    private bool isGround = false;
     
    public AssetReference monsterSet;
    // Start is called before the first frame update
    void Awake()
    {
        _rigi2D = GetComponent<Rigidbody2D>();
        _input = new MonsterControlInput();
        _input.MonsterControll.Jump.performed += callBack=>Jump();

        monsterSet.LoadAssetAsync<MonsterSet>().Completed += op =>
        {
            GloablManager.Instance.PlayerInfo.currentMonster = new MonsterInfo(op.Result);
        };
        
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public void Move(float moveDir)
    {
        _rigi2D.velocity = new Vector2( moveDir * moveSpeed,_rigi2D.velocity.y);
    }

   
    public void Jump()
    {
        if (moveInput.y < 0)
        {
            var collider2D = Physics2D.OverlapCircle(GroundCheck.position,2,LayerMask.GetMask(DOWNABLE_PLATFORM_LAYER));
            if (collider2D != null)
            { 
                collider2D.GetComponent<PlatformEffector2D>().SetRotationOffset_180();
            }
        }
        else
        {   
            if(!isGround)
                return;
            
            _rigi2D.velocity = new Vector2(_rigi2D.velocity.x, jumpSpeed);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        moveInput = _input.MonsterControll.Move.ReadValue<Vector2>();
        isGround = Physics2D.OverlapCircle(GroundCheck.position,0.1f,LayerMask.GetMask(DOWNABLE_PLATFORM_LAYER)|LayerMask.GetMask("Ground"));
    }

    private void FixedUpdate()
    {
        Move(moveInput.x);
    }
}
