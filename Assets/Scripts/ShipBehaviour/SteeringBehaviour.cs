using System.Xml.Serialization;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public abstract class SteeringBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mObjectToMove = null;
    [SerializeField] protected EnemyShipData mEnemyConfig = null;
    private Vector2 mSteering = Vector2.zero;
    private float mWanderAngle;

   /* public float mWanderAngle { get; set; }

    public float WanderAngle => mWanderAngle;

    public float GetWanderAngle() { return  mWanderAngle; }
    public void SetWanderAngle(float wanderAngle) { mWanderAngle = wanderAngle; }
*/
    public void Reset()
    {
        mSteering = Vector2.zero;
    }

    public void Seek(Vector3 position, float slowingRadius = 0.0f)
    {
        mSteering += DoSeek(position, slowingRadius);
    }

    public void Flee(Vector2 position)
    {
        mSteering += DoFlee(position);
    }

    public void Wander()
    {
        mSteering += DoWander();
    }

    public void AvoidCollisions()
    {
        mSteering += DoAvoidCollisions(mEnemyConfig.AvoidDistance);
    }

    public Vector2 DoSeek(Vector3 position, float slowingRadius)
    {
        //calculate a vector in the direction of the target
        var desiredVelocity = position - transform.position;

        //calculate the distance to the target
        var distance = desiredVelocity.magnitude;

        // check if the ship nees to slow down
        if(distance < slowingRadius)
        {
            //reduce speed based relative to proximity (closer = slower) 
            desiredVelocity = desiredVelocity.normalized * mEnemyConfig.MaxSpeed * (distance / slowingRadius);
        }
        else
        {
            //outside slowing radius, so go full speed
            desiredVelocity = desiredVelocity.normalized * mEnemyConfig.MaxSpeed;
        }

        return desiredVelocity - (Vector3)mObjectToMove.velocity;
    }

    private Vector2 DoFlee(Vector3 position)
    {
        //calculate a vector away from target
        var desiredVelocity = transform.position - position;

        //var distance = desiredVelocity.magnitude;

        //change speed to flee the target
        desiredVelocity = desiredVelocity.normalized * mEnemyConfig.MaxSpeed;

        return desiredVelocity - (Vector3)mObjectToMove.velocity;
    }

    //wander aimlessly
    private Vector2 DoWander()
    {
        //calculate the wander circle center point
        var circleCenter = mObjectToMove.velocity.normalized * mEnemyConfig.WanderCircleDistance;

        //create a displacement vector in local space
        var displacement = new Vector2(0, mEnemyConfig.WanderCircleRadius);

        //transform the vector by the desired wander angle.
        displacement = SetAngle(displacement, mWanderAngle);

        //randomly change wander angle for the next direction update
        mWanderAngle += Random.Range(-1f, 1f) * mEnemyConfig.WanderAngleAdjustment;

        return circleCenter + displacement;
    }

    private Vector2 SetAngle(Vector2 vector, float rotation)
    {
        var length = vector.magnitude;
        vector.x = Mathf.Cos(rotation) * length;
        vector.y = Mathf.Sin(rotation) * length;
        return vector;
    }

    public void ApplySteering()
    {
        //limit the turning distance to the turning max speed
        if(mSteering.magnitude > mEnemyConfig.TurnSpeed)
        {
            mSteering = mSteering.normalized * mEnemyConfig.TurnSpeed;
        }

        var velocity = mObjectToMove.velocity + mSteering;

        //limit velocity to max speed
        if(velocity.magnitude > mEnemyConfig.MaxSpeed)
        {
            velocity = velocity.normalized * mEnemyConfig.MaxSpeed;
        }

        //set velocity to new direction and speed
        mObjectToMove.velocity = velocity;
        mObjectToMove.transform.rotation = Quaternion.LookRotation(Vector3.forward, mObjectToMove.velocity);
    }

    private Vector2 DoAvoidCollisions(float distance)
    {
        //move the raycast out of the hull of the ship
        var originPoint = transform.position + transform.up * 1.75f;
        var hit = Physics2D.Raycast(originPoint, mObjectToMove.velocity, distance, mEnemyConfig.AvoidThese);

        //check if raycast hit something we're trying to avoid
        if (hit)
        {
            //create a steering vector to avoid the collision
            var desiredVelocity = (hit.transform.position - transform.position).normalized * mEnemyConfig.MaxSpeed;
            return desiredVelocity - (Vector3)mObjectToMove.velocity;
        }

        return Vector2.zero;
    }
}
