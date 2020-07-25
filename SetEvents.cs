using UnityEngine;

namespace BetterRadio
{
    public class SetEvents
    {
        internal void OnRoundStarted()
        {
            GameObject.FindWithTag("FemurBreaker").AddComponent<AddRadioDurabilityComponent>();
        }
    }
}