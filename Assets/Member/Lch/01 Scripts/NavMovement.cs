using System;
using UnityEngine;
using UnityEngine.AI;

namespace Blade.Enemies
{
    public class NavMovement : MonoBehaviour , IEntityComponet
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float stopOffset = 0.05f;

        private Entity _entity;
        [SerializeField] private const float RotateSpeed = 10f;

        public bool IsArrived => !agent.pathPending &&  agent.remainingDistance < agent.stoppingDistance + stopOffset;
        public float RemainDistance => agent.pathPending ? -1 : agent.remainingDistance;

        public void Initialize(Entity entity)
        {
            _entity = entity;
            agent.speed = moveSpeed;
        }

        private void Update()
        {
             if(agent.hasPath && agent.isStopped == false && agent.path.corners.Length >= 0)
            {
                LookAtTarget(agent.steeringTarget);
            }
        }

        public Quaternion LookAtTarget(Vector3 target,bool isSmoth = true)
        {
            Vector3 direction = target - _entity.transform.position;
            direction.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            if(isSmoth)
            {
                _entity.transform.rotation = Quaternion.Slerp(_entity.transform.rotation,
                 lookRotation, Time.deltaTime *RotateSpeed);
            }
            else
            {

                 _entity.transform.rotation = lookRotation;
            }

            return lookRotation;
        }

        public void SetStop(bool isStop) => agent.isStopped = isStop;
        public void SetVelocity(Vector3 velocity) => agent.velocity = velocity;
        public void SetSpeed(float speed) => agent.speed = speed;
        public void SetSpeedMultiply(float value) => agent.speed *= value;
        public void SetSpeedDivide(float value) => agent.speed /= value;
        public void SetDestination(Vector3 destination) => agent.SetDestination(destination);
    }
}
