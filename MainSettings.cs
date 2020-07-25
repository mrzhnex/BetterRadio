using Exiled.API.Features;

namespace BetterRadio
{
    public class MainSettings : Plugin<Config>
    {
        public override string Name => nameof(BetterRadio);
        public SetEvents SetEvents { get; set; }

        public override void OnEnabled()
        {
            base.OnEnabled();
            try
            {

                Global.IsFullRp = Config.IsFullRp;
            }
            catch (System.Exception ex)
            {
                Log.Info("Catch an exception while getting boolean value from config file: " + ex.Message);
                Global.IsFullRp = false;
            }
            Log.Info(nameof(Global.IsFullRp) + ": " + Global.IsFullRp);
            SetEvents = new SetEvents();
            Exiled.Events.Handlers.Server.RoundStarted += SetEvents.OnRoundStarted;
            Log.Info(Name + " on");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.RoundStarted -= SetEvents.OnRoundStarted;
            Log.Info(Name + " off");
        }
    }
}