using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mRigidbody = null;
    [SerializeField] private float mRunSpeed;
    [SerializeField] private float mJumpForce;
    [SerializeField] private Animator mAnimator = null;
    [SerializeField] private AudioSource mJumpSFX = null;
    [SerializeField] private AudioSource mCoinCollectSFX = null;
    [SerializeField] private PlayerData mPlayerConfig = null;
    [SerializeField] private ParticleSystem mParticle = null;

    private float mHorizontalMovement;
    private float mVerticalMovement;
    private float mMoveSpeed;

    private bool mIsMoving;
    private bool mIsOnGround;

    private const string FORWARD = "Forward";
    private const string BACKWARD = "Backward";
    private const string LEFT = "Left";
    private const string RIGHT = "Right";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string JUMP = "Jump";

    private void Start()
    {
        mIsOnGround = true;
        mRunSpeed = 2;
        mHorizontalMovement = 0;
        mVerticalMovement = 0;
        mMoveSpeed = mPlayerConfig.MovementSpeed;
        mIsMoving = false;
    }

    private void FixedUpdate()
    {
        //mHorizontalMovement = Input.GetAxis(HORIZONTAL);
        //mVerticalMovement = Input.GetAxis(VERTICAL);

        mRigidbody.velocity = new Vector2(mHorizontalMovement * mMoveSpeed, mRigidbody.velocity.y/*mVerticalMovement * mMoveSpeed*/);
    }

    // Update is called once per frame
    void Update()
    {
        //ResetAnimation();

        if(mHorizontalMovement != 0 /*|| mVerticalMovement != 0*/)
        {
            mIsMoving = true;

            //mAnimator.SetLayerWeight(1, 1);

           /* if(mHorizontalMovement != 0)
            {
                mAnimator.SetBool(mHorizontalMovement < 0 ? LEFT : RIGHT, true);
            }
            else if(mVerticalMovement != 0)
            {
                mAnimator.SetBool(mVerticalMovement < 0 ? FORWARD : BACKWARD, true);
            }*/
        }
        else
        {
            mIsMoving = false;
            /*mAnimator.SetLayerWeight (1, 0);
            mAnimator.SetLayerWeight (2, 0);*/
        }

        /*if (Input.GetButtonDown(JUMP) && mIsOnGround)
        {
            mRigidbody.AddForce(Vector2.up * mJumpForce);
        }*/

        //mMoveSpeed = (Input.GetKey(KeyCode.LeftShift) ? mRunSpeed * 2 : mRunSpeed);
        //mAnimator.SetLayerWeight(2, mIsMoving ? 1 : 0);
    }

    void ResetAnimation()
    {
        mAnimator.SetBool(FORWARD, false);
        mAnimator.SetBool(BACKWARD, false);
        mAnimator.SetBool(LEFT, false);
        mAnimator.SetBool(RIGHT, false);
    }

    public void OnMovement(InputValue value)
    {
        mHorizontalMovement = value.Get<Vector2>().x;
    }

    public void OnJump()
    {
        if (mIsOnGround)
        {
            mRigidbody.AddForce(Vector2.up * mJumpForce);
            mJumpSFX.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mIsOnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        mIsOnGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Actions.IncreaseScore?.Invoke(100);
            collision.gameObject.SetActive(false);
            mCoinCollectSFX.Play();
            //mParticle.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
