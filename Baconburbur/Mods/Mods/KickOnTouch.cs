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
    [hamburburmod("Elevator Kick On Touch [NEED MASTER]", "Kicks the person you are touching!",
        ButtonType.Togglable, AccessSetting.Public, EnabledType.Disabled, 0)]
    public class ElevatorKickTouch : hamburburmod
    {
        public static float delay;

        protected override void Update()
        {
            if (PhotonNetwork.IsMasterClient == true)
            {
                foreach (var rig in VRRigCache.ActiveRigs)
                {
                    if (!rig.isLocal)
                        continue;
                    {
                        var hand = GorillaTagger.Instance.rightHandTransform.transform.position;
                        var hand2 = GorillaTagger.Instance.leftHandTransform.transform.position;
                        var person = rig.bodyTransform.position;
                        if (Vector3.Distance(hand, person) < 0.7f || Vector3.Distance(hand2, person) < 0.7f)
                            continue;
                        {
                            if (Time.time > delay)
                            {
                                GRElevatorManager._instance.SendRPC("RemoteActivateTeleport", rig.Creator.GetPlayerRef(), new object[] { GRElevatorManager._instance.currentLocation, GRElevatorManager.ElevatorLocation.GhostReactor, PhotonNetwork.LocalPlayer.ActorNumber });
                                delay = Time.time + 0.75f;
                                Classes.AntiRPCs();
                            }
                        }
                    }
                }
            }
        }
    }
}
