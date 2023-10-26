using UnityEngine;

public class WanderBehaviour : SteeringBehaviour
{
    SteeringBehaviour testing;

    private void FixedUpdate()
    {
        Wander();
        AvoidCollisions();
        ApplySteering();
        Reset();
    }
}
