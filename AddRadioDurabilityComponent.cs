using EXILED.Extensions;
using UnityEngine;

namespace BetterRadio
{
    public class AddRadioDurabilityComponent : MonoBehaviour
    {
        private float Timer = 0.0f;
        private readonly float TimeIsUp = 5.0f;

        public void Update()
        {
            Timer += Time.deltaTime;
            if (Timer > TimeIsUp)
            {
                Timer = 0.0f;

                foreach (ReferenceHub referenceHub in Player.GetHubs())
                {
                    if (referenceHub.GetTeam() == Team.SCP || referenceHub.GetRole() == RoleType.Spectator)
                        continue;

                    for (int i = 0; i < referenceHub.inventory.items.Count; i++)
                    {
                        if (referenceHub.inventory.items[i].id == ItemType.Radio)
                        {
                            Inventory.SyncItemInfo item = referenceHub.inventory.items[i];
                            item.durability = 100.0f;
                            referenceHub.inventory.items[i] = item;
                        }
                    }
                }
            }
        }
    }
}