using UnityEngine;
using UnityEngine.AI;

namespace Code.Scripts.Enemy
{
    public class BaseEnemyController : BaseEnemy
    {
        public enum EnemyState
        {
            Patrol,
            Chase,
            Flee
        }

        [Header("Player Settings")]
        public Transform Player; // Reference to the player

        [Header("Attack Settings")]
        public float AttackRange = 1.5f; // Range within which the enemy can attack the player
        public float DetectionRange = 5.0f; // Range within which the enemy can detect the player
        public float AttackCooldown = 2.0f; // Cooldown time between attacks
        public EnemySword enemySword; // Reference to the rotating sword

        [Header("Patrol Settings")]
        public bool CanPatrol = true; // Can the enemy patrol?
        [SerializeField]
        public Transform[] PatrolPoints; // Array of patrol points
        public float PatrolPointTolerance = 0.2f; // Tolerance to consider the enemy at a patrol point

        [Header("Chase Settings")]
        public bool CanChase = true; // Can the enemy chase?

        [Header("Flee Settings")]
        public bool CanFlee = true; // Can the enemy flee?

        private NavMeshAgent2D NavMesh;
        private float LastAttackTime;
        private int CurrentPatrolIndex;
        private EnemyState CurrentState;
        private EnemyAnimation _ea;
        public float EnemyAngle { get; private set; }

        void Start()
        {
            _ea = GetComponent<EnemyAnimation>();
            NavMesh = GetComponent<NavMeshAgent2D>();
            LastAttackTime = -AttackCooldown;

            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                Player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player not found! Make sure the player GameObject is tagged as 'Player'.");
            }

            if (enemySword == null)
            {
                enemySword = GetComponentInChildren<EnemySword>();
                if (enemySword == null)
                {
                    Debug.LogError("Sword not found! Make sure the Sword script is attached to a child GameObject.");
                }
            }

            CurrentPatrolIndex = 0;
            CurrentState = EnemyState.Patrol;

            if (CanPatrol && PatrolPoints.Length > 0)
            {
                MoveToLocation(PatrolPoints[CurrentPatrolIndex].position);
            }
        }
      
        void FixedUpdate()
        {
     
            
            //if (Player == null) return;

            switch (CurrentState)
            {
                case EnemyState.Patrol:
                    Patrol();
                    break;

                case EnemyState.Chase:
                    if (CanChase)
                    {
                        Chase();
                    }
                    break;

                case EnemyState.Flee:
                    if (CanFlee)
                    {
                        // Flee logic can be implemented here, if required
                    }
                    break;
            }
        }


        void MoveToLocation(Vector3 destination)
        {
            if (NavMesh)
            {
                NavMesh.SetDestination(destination);
            }
        }

        bool IsPlayerDetected()
        {
            return Vector3.Distance(transform.position, Player.position) <= DetectionRange;
        }

        bool IsInRange(Vector3 target)
        {
            return Vector3.Distance(transform.position, target) <= AttackRange;
        }

        void Attack()
        {
            //if (enemySword != null)
            //{
                enemySword.Rotate();
                Debug.Log("Attacking the player with the sword!");
                LastAttackTime = Time.time;
            //}
        }

        bool IsLookingAt(Vector3 target)
        {
            Vector3 directionToTarget = (target - transform.position).normalized;
            float dotProduct = Vector3.Dot(transform.right, directionToTarget); // Assuming the sprite's right side is its forward direction

            return dotProduct > 0.95f; // Adjust the threshold as needed
        }

        void Patrol()
        {
            if (!CanPatrol || PatrolPoints.Length == 0) return;

            if (Vector3.Distance(transform.position, PatrolPoints[CurrentPatrolIndex].position) <= PatrolPointTolerance)
            {
                CurrentPatrolIndex = (CurrentPatrolIndex + 1) % PatrolPoints.Length;
                MoveToLocation(PatrolPoints[CurrentPatrolIndex].position);
                RotateTowards(PatrolPoints[CurrentPatrolIndex].position);
            }

            if (IsPlayerDetected())
            {
                CurrentState = EnemyState.Chase;
            }
        }

        void Chase()
        {
            if (IsInRange(Player.position))
            {
                if (Time.time >= LastAttackTime + AttackCooldown)
                {
                    Attack();
                }
            }
            else if (IsPlayerDetected())
            {
                MoveToLocation(Player.position);
            }
            else
            {
                CurrentState = EnemyState.Patrol;
                if (CanPatrol && PatrolPoints.Length > 0)
                {
                    MoveToLocation(PatrolPoints[CurrentPatrolIndex].position);
                    RotateTowards(PatrolPoints[CurrentPatrolIndex].position);
                    return;
                }
            }

            RotateTowards(Player.position); // Rotate to face the player
        }

        void Flee(Vector3 dangerPosition)
        {
            Vector3 fleeDirection = (transform.position - dangerPosition).normalized;
            Vector3 fleePosition = transform.position + fleeDirection * DetectionRange;

            MoveToLocation(fleePosition);
        }

        void RotateTowards(Vector3 target)
        {
            Vector3 direction = (target - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            EnemyAngle = angle;
            _ea.HandleAnimation();
            //Debug.Log("enemy angle is " + EnemyAngle);

            // Determine the relative position (left or right)
            if (direction.x < 0)
            {
                // Rotate to the left
                transform.rotation = Quaternion.Euler(new Vector3(0, 00, 0));
            }
            else
            {
                // Rotate to the right
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AttackRange);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, DetectionRange);

            if (CanPatrol && PatrolPoints != null)
            {
                Gizmos.color = Color.blue;
                foreach (Transform patrolPoint in PatrolPoints)
                {
                    if (patrolPoint != null)
                    {
                        Gizmos.DrawSphere(patrolPoint.position, 0.5f);
                    }
                }
            }
        }

        void OnValidate()
        {
            if (!CanPatrol)
            {
                PatrolPoints = new Transform[0];
            }
        }
    }
}
