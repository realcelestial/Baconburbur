using hamburbur.Libs;
using hamburbur.Managers;
using hamburbur.Mod_Backend;
using hamburbur.Mods.OP;
using hamburbur.Tools;
using hamburburPluginTemplate.Backend;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static hamburburPluginTemplate.Mods.SimulateGun;

namespace hamburburPluginTemplate.Mods.Mods
{
    [hamburburPlugin(PluginCategory.Bacon)]
    [hamburburmod("Elevator Kick Gun [NEED MASTER]", "Kicks the person you are locking!",
         ButtonType.Togglable, AccessSetting.Public, EnabledType.Disabled, 0)]
    public class ElevatorKickGun : hamburburmod 
    {
        public static float delay;
       protected override void Update()
       {
            SimulateGun.ShowGun();
            if (isnowlocking == true)
            {
                if (PhotonNetwork.IsMasterClient == true)
                    if (Time.time > delay)
                    {
                        GRElevatorManager._instance.SendRPC("RemoteActivateTeleport", locked.Creator.GetPlayerRef(), new object[] { GRElevatorManager._instance.currentLocation, GRElevatorManager.ElevatorLocation.GhostReactor, PhotonNetwork.LocalPlayer.ActorNumber });
                        delay = Time.time + 0.75f;
                        Classes.AntiRPCs();
                    }
            }
        }
    }
}
