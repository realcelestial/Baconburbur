using hamburbur.Mod_Backend;
using hamburbur.Mods.Console;
using hamburburPluginTemplate.Backend;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace hamburburPluginTemplate.Mods.Mods
{
    [hamburburPlugin(PluginCategory.Bacon)]
    [hamburburmod("Send Elevator to Ghost Reactor", "It closes the Elevator Door and goes to GR",
         ButtonType.Fixed, AccessSetting.Public, EnabledType.Disabled, 0)]
    public class CloseElevatorDoor : hamburburmod
    {
        public static float delay;
        protected override void Pressed()
        {
            PhotonHandler.SendAsap = true;
            GRElevatorManager._instance.SendRPC("RemoteElevatorButtonPress", RpcTarget.MasterClient, new object[] { GRElevator.ButtonType.GhostReactor, GRElevatorManager._instance.currentLocation });
            Classes.AntiRPCs();
        }
    }
}
