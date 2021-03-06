using System;
using SuperNewRoles.Buttons;
using SuperNewRoles.CustomRPC;

namespace SuperNewRoles.Roles
{
    class Sheriff
    {
        public static void ResetKillCoolDown()
        {
            if (PlayerControl.LocalPlayer.isRole(RoleId.RemoteSheriff))
            {
                HudManagerStartPatch.SheriffKillButton.MaxTimer = RoleClass.RemoteSheriff.CoolTime;
                HudManagerStartPatch.SheriffKillButton.Timer = RoleClass.RemoteSheriff.CoolTime;
                RoleClass.Sheriff.ButtonTimer = DateTime.Now;
            }
            else
            {
                if (RoleClass.Chief.SheriffPlayer.Contains(CachedPlayer.LocalPlayer.PlayerId))
                {
                    HudManagerStartPatch.SheriffKillButton.MaxTimer = RoleClass.Chief.CoolTime;
                }
                else
                {
                    HudManagerStartPatch.SheriffKillButton.MaxTimer = RoleClass.Sheriff.CoolTime;
                }
                HudManagerStartPatch.SheriffKillButton.Timer = HudManagerStartPatch.SheriffKillButton.MaxTimer;
            }
        }
        public static bool IsSheriffKill(PlayerControl Target)
        {
            var roledata = CountChanger.GetRoleType(Target);
            if (roledata == TeamRoleType.Impostor) return true;
            if (Target.isMadRole() && RoleClass.Sheriff.IsMadRoleKill) return true;
            if (Target.isFriendRole() && RoleClass.Sheriff.IsMadRoleKill) return true;
            if (Target.isNeutral() && RoleClass.Sheriff.IsNeutralKill) return true;
            if (RoleClass.Sheriff.IsLoversKill && Target.IsLovers()) return true;
            if (Target.isRole(RoleId.HauntedWolf)) return true;
            return false;
        }
        public static bool IsChiefSheriffKill(PlayerControl Target)
        {
            var roledata = CountChanger.GetRoleType(Target);
            if (roledata == TeamRoleType.Impostor) return true;
            if (Target.isMadRole() && RoleClass.Chief.IsMadRoleKill) return true;
            if (Target.isFriendRole() && RoleClass.Chief.IsMadRoleKill) return true;
            if (Target.isNeutral() && RoleClass.Chief.IsNeutralKill) return true;
            if (RoleClass.Chief.IsLoversKill && Target.IsLovers()) return true;
            if (Target.isRole(RoleId.HauntedWolf)) return true;
            return false;
        }
        public static bool IsRemoteSheriffKill(PlayerControl Target)
        {
            var roledata = CountChanger.GetRoleType(Target);
            if (roledata == TeamRoleType.Impostor) return true;
            if (Target.isMadRole() && RoleClass.RemoteSheriff.IsMadRoleKill) return true;
            if (Target.isFriendRole() && RoleClass.RemoteSheriff.IsMadRoleKill) return true;
            if (Target.isNeutral() && RoleClass.RemoteSheriff.IsNeutralKill) return true;
            if (RoleClass.RemoteSheriff.IsLoversKill && Target.IsLovers()) return true;
            if (Target.isRole(RoleId.HauntedWolf)) return true;
            return false;
        }
        public static bool IsSheriff(PlayerControl Player)
        {
            if (Player.isRole(RoleId.Sheriff) || Player.isRole(RoleId.RemoteSheriff))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsSheriffButton(PlayerControl Player)
        {
            if (Player.isRole(RoleId.Sheriff))
            {
                if (RoleClass.Sheriff.KillMaxCount > 0)
                {
                    return true;
                }
            }
            else if (Player.isRole(RoleId.RemoteSheriff))
            {
                if (RoleClass.RemoteSheriff.KillMaxCount > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static void EndMeeting()
        {
            ResetKillCoolDown();
        }
    }
}
