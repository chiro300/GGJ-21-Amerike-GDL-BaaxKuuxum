using UnityEngine;

namespace Assets.Scripts.Behaivors
{
    public class WalkingBeheivor : MonoBehaviour
    {
        [Header("Speed")]
        public float WalkSpeed = 6f;
        
        public float MovementSpeedMultiplier = 1f;
        public LayerMask collisionLayers;

        public float horizontalMovement;
        public float verticalMovement;
        public bool walking = true;

        public enum FacingDirections { Left, Right, Up, Down }

        public FacingDirections facingDirection = FacingDirections.Down;

        private void FixedUpdate()
        {            
            Walking();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (LayerHelper.LayerInLayerMask(collision.gameObject.layer, collisionLayers))
            {
                SetHorizontalMove(Random.Range(-1f, 1f));
                SetVerticalMove(Random.Range(-1f, 1f));
            }
        }

        protected void Walking()
        {
            if (walking)
            {
                float horizontalMovementSpeed = horizontalMovement * WalkSpeed * MovementSpeedMultiplier * Time.deltaTime;
                float verticalMovementSpeed = verticalMovement * WalkSpeed * MovementSpeedMultiplier * Time.deltaTime;

                gameObject.transform.position += new Vector3(horizontalMovementSpeed, verticalMovementSpeed, 0);
            }
        }
        
        public virtual void SetHorizontalMove(float value)
        {
            horizontalMovement = value;
        }
        
        public virtual void SetVerticalMove(float value)
        {
            verticalMovement = value;
        }

        public void StopWalking()
        {
            walking = false;
        }

        public void StartWalking()
        {
            walking = true;
        }
    }
}
