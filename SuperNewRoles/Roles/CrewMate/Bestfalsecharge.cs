using HarmonyLib;
using Hazel;

namespace SuperNewRoles.Roles
{
    public class Bestfalsecharge
    {
        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))]
        public class MeetingEnd
        {
            static void Prefix(MeetingHud __instance)
            {
                if (AmongUsClient.Instance.AmHost && !RoleClass.Bestfalsecharge.IsOnMeeting)
                {
                    foreach (PlayerControl p in RoleClass.Bestfalsecharge.BestfalsechargePlayer)
                    {
                        MessageWriter RPCWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.CustomRPC.ExiledRPC, Hazel.SendOption.Reliable, -1);
                        RPCWriter.Write(p.PlayerId);
                        AmongUsClient.Instance.FinishRpcImmediately(RPCWriter);
                        CustomRPC.RPCProcedure.ExiledRPC(p.PlayerId);
                    }
                    RoleClass.Bestfalsecharge.IsOnMeeting = true;
                }


                //===========以下さつまいも===========//
                if (RoleClass.SatsumaAndImo.TeamNumber == 1)//クルーなら
                {
                    RoleClass.SatsumaAndImo.TeamNumber = 2;//マッドに
                }
                else if (RoleClass.SatsumaAndImo.TeamNumber == 2)//マッドなら
                {
                    RoleClass.SatsumaAndImo.TeamNumber = 1;//ジャカフレに
                }
            }
        }
    }
}
