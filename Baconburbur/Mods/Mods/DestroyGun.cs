using hamburbur.Managers;
using hamburbur.Mod_Backend;
using hamburburPluginTemplate.Backend;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using static hamburburPluginTemplate.Mods.SimulateGun;

namespace hamburburPluginTemplate.Mods.Mods
{
    [hamburburPlugin(PluginCategory.Bacon)]
    [hamburburmod("Destroy Gun", "When a new player joins, he/she CAN'T see the target!",
      ButtonType.Togglable, AccessSetting.Public, EnabledType.Disabled, 0)]
    public class DestroyGun : hamburburmod
    {
        public static float delay;
        protected override void Update()
        {
            SimulateGun.ShowGun();
            if (isnowlocking == true)
            {
                if (Time.time > delay)
                {
                    PhotonNetwork.OpRemoveCompleteCacheOfPlayer(locked.Creator.ActorNumber);
                    Classes.AntiRPCs();
                    NotificationManager.SendNotification("Baconburbur", "Destroyed!", 3f, true, true);
                    delay = Time.time + 2f;
                }
            }
        }
    }
}
