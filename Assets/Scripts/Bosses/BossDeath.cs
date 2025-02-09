using Managers;

namespace Bosses
{
    public class BossDeath : BossBaseState
    {
        public override void RunState()
        {
            base.RunState();
            
            EndGameManager.Instance.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}