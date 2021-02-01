

using Assets.Scripts.Behaivors;

namespace Assets.Scripts.AISystem.AIActions
{
    public class AIDoNothingAction : AIAction
    {
        protected WalkingBeheivor walkingBeheivor;

        private void Awake()
        {
            walkingBeheivor = gameObject.GetComponent<WalkingBeheivor>();
        }

        public override void Action()
        {
            walkingBeheivor.StopWalking();
        }

        public override void ExitAction()
        {
            walkingBeheivor.StartWalking();
        }
    }
}
