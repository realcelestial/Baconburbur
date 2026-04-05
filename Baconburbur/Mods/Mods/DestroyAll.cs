using hamburbur.Managers;
using hamburbur.Mod_Backend;
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
    [hamburburmod("Destroy All", "When a new player joins, he/she CAN'T see anyone!",
       ButtonType.Togglable, AccessSetting.Public, EnabledType.Disabled, 0)] // i put Togglable cuz with Fixed doesnt work... thats why i put delay
    public class DestroyAll : hamburburmod
    {
        public static float delay;
        protected override void Update()
        {
            foreach (var p in PhotonNetwork.PlayerListOthers)
            {
                if (Time.time > delay)
                {
                    PhotonNetwork.OpRemoveCompleteCacheOfPlayer(p.ActorNumber);
                    Classes.AntiRPCs();
                    NotificationManager.SendNotification("Baconburbur", "Destroyed!", 3f, true, true);
                    delay = Time.time + 2f;
                }
            }
        }
    }
}


