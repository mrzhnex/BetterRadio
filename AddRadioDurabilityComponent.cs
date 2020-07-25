using Exiled.API.Features;
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

                foreach (Player player in Player.List)
                {
                    if (player.Team == Team.SCP || player.Role == RoleType.Spectator)
                        continue;
                    for (int i = 0; i < player.Inventory.items.Count; i++)
                    {
                        if (player.Inventory.items[i].id != ItemType.Radio)
                            continue;
                        if (Global.IsFullRp)
                        {
                            if (!PlayersRadioDurability.ContainsKey(player.Id))
                            {
                                PlayersRadioDurability.Add(player.Id, player.Inventory.items[i].durability);
                            }
                            if (PlayersRadioDurability[player.Id] - 10.0f >= player.Inventory.items[i].durability)
                            {
                                Inventory.SyncItemInfo item = player.Inventory.items[i];
                                item.durability += 5.0f;
                                player.Inventory.items[i] = item;
                                PlayersRadioDurability[player.Id] = player.Inventory.items[i].durability;
                            }
                            else if (PlayersRadioDurability[player.Id] < player.Inventory.items[i].durability)
                            {
                                PlayersRadioDurability[player.Id] = player.Inventory.items[i].durability;
                            }
                        }
                        else
                        {
                            Inventory.SyncItemInfo item = player.Inventory.items[i];
                            item.durability = 100.0f;
                            player.Inventory.items[i] = item;
                        }
                    }                   
                }         
            }
        }
        private readonly Dictionary<int, float> PlayersRadioDurability = new Dictionary<int, float>();
    }
}