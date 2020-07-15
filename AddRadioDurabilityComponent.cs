using EXILED.Extensions;
using System.Collections.Generic;
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
                if (Global.IsFullRp)
                {
                    foreach (ReferenceHub referenceHub in Player.GetHubs())
                    {
                        if (referenceHub.GetTeam() == Team.SCP || referenceHub.GetRole() == RoleType.Spectator)
                            continue;

                        for (int i = 0; i < referenceHub.inventory.items.Count; i++)
                        {
                            if (referenceHub.inventory.items[i].id == ItemType.Radio)
                            {
                                if (!PlayersRadioDurability.ContainsKey(referenceHub.GetPlayerId()))
                                {
                                    PlayersRadioDurability.Add(referenceHub.GetPlayerId(), referenceHub.inventory.items[i].durability);
                                }

                                if (PlayersRadioDurability[referenceHub.GetPlayerId()] - 10.0f >= referenceHub.inventory.items[i].durability)
                                {
                                    Inventory.SyncItemInfo item = referenceHub.inventory.items[i];
                                    item.durability += 5.0f;
                                    referenceHub.inventory.items[i] = item;
                                    PlayersRadioDurability[referenceHub.GetPlayerId()] = referenceHub.inventory.items[i].durability;
                                }
                                else if (PlayersRadioDurability[referenceHub.GetPlayerId()] < referenceHub.inventory.items[i].durability)
                                {
                                    PlayersRadioDurability[referenceHub.GetPlayerId()] = referenceHub.inventory.items[i].durability;
                                }
                            }
                        }
                    }
                }
                else
                {
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
        private readonly Dictionary<int, float> PlayersRadioDurability = new Dictionary<int, float>();
    }
}