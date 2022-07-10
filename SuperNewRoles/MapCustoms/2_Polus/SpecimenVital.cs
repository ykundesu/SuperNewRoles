using UnityEngine;
using SuperNewRoles.Mode;

namespace SuperNewRoles.MapCustoms
{
    public class SpecimenVital
    {
        public static Vector3 pos = new(35.39f, -22.10f, 1.0f);
        public static bool flag = false;
        public static void ClearAndReload()
        {
            flag = false;
        }

        public static void moveVital()
        {
            if (SpecimenVital.flag) return;
            if (MapCustomHandler.isMapCustom(MapCustomHandler.MapCustomId.Polus) && MapCustoms.MapCustom.SpecimenVital.getBool())
            {
                var panel = GameObject.Find("panel_vitals");
                if (panel != null)
                {
                    var transform = panel.GetComponent<Transform>();
                    transform.SetPositionAndRotation(SpecimenVital.pos, transform.rotation);
                    SpecimenVital.flag = true;
                }
            }
        }
    }
}
