using UnityEngine;

namespace BetterRadio
{
    internal class SetEvents
    {
        internal void OnRoundStart()
        {
            GameObject.FindWithTag("FemurBreaker").AddComponent<AddRadioDurabilityComponent>();
        }
    }
}