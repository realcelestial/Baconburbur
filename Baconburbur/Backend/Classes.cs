using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace hamburburPluginTemplate.Backend
{
    internal class Classes
    {
        public static void AntiRPCs()
        {
            try
            {
                MonkeAgent gnot = MonkeAgent.instance;
                gnot.logErrorMax = int.MaxValue;
                gnot.rpcCallLimit = int.MaxValue;
                gnot.rpcErrorMax = int.MaxValue;
                PhotonNetwork.SendAllOutgoingCommands();
                PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
                PhotonNetwork.QuickResends = int.MaxValue;
            }
            catch (Exception e)
            {
            }
        }
    }
}
