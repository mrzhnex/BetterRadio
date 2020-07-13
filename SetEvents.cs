using EXILED;
using UnityEngine;

namespace BetterRadio
{
    internal class SetEvents
    {
        internal void OnRoundStart()
        {
            GameObject.FindWithTag("FemurBreaker").AddComponent<AddRadioDurabilityComponent>();
        }

        internal void OnWaitingForPlayers()
        {
            try
            {
                Global.IsFullRp = Plugin.Config.GetBool("IsFullRp");
            }
            catch (System.Exception ex)
            {
                Log.Info("Catch an exception while getting boolean value from config file: " + ex.Message);
                Global.IsFullRp = false;
            }
            Log.Info(nameof(Global.IsFullRp) + ": " + Global.IsFullRp);
        }
    }
}