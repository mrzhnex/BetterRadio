using EXILED;

namespace BetterRadio
{
    public class MainSettings : Plugin
    {
        public override string getName => "BetterRadio";
        private SetEvents SetEvents;

        public override void OnEnable()
        {
            SetEvents = new SetEvents();
            Events.RoundStartEvent += SetEvents.OnRoundStart;
        }

        public override void OnDisable()
        {
            Events.RoundStartEvent -= SetEvents.OnRoundStart;
        }

        public override void OnReload() { }
    }
}