using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Object = UnityEngine.Object;

namespace hamburburPluginTemplate.Mods
{
    internal class SimulateGun //my shitty gunlib. Sorry :(
    {
        public static GameObject renda;
        public static RaycastHit hitstart = default;
        public static VRRig locked;
        public static bool isnowlocking = false;
        public static LineRenderer liner;
        public static bool isinpos = true;
        public static bool isinpos2 = true;
        public static GameObject pointer;
        public static bool shooting = false;
        public static Shader espshaders = Shader.Find("GUI/Text Shader");
        internal class Libs
        {
            public static bool RT()
            {
                return ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
            }
            public static bool LT()
            {
                return ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
            }

            public static bool RG()
            {
                return ControllerInputPoller.instance.rightControllerGripFloat == 1f;
            }

            public static bool LG()
            {
                return ControllerInputPoller.instance.leftControllerGripFloat == 1f;
            }

            public static bool X()
            {
                return ControllerInputPoller.instance.leftControllerPrimaryButton;
            }
            public static bool Y()
            {
                return ControllerInputPoller.instance.leftControllerSecondaryButton;
            }
            public static bool B()
            {
                return ControllerInputPoller.instance.rightControllerSecondaryButton;
            }
            public static bool A()
            {
                return ControllerInputPoller.instance.rightControllerPrimaryButton;
            }
        }
        public static void ShowGun()
        {
            if (XRSettings.isDeviceActive)
            {
                vrgun();
            }
            else
            {
                pcgun();
            }
        }
        public static void vrgun()
        {
            if (Libs.RG())
            {
                if (renda == null)
                {
                    renda = new GameObject("guon");
                    liner = renda.AddComponent<LineRenderer>();
                    liner.startColor = Color.gray;
                    liner.endColor = Color.black;
                    liner.startWidth = 0.05f;
                    liner.endWidth = 0.03f;
                    liner.useWorldSpace = true;
                    liner.material.shader = espshaders;
                }

                Vector3 start = GorillaTagger.Instance.rightHandTransform.position;
                Vector3 dir = GorillaTagger.Instance.rightHandTransform.forward;
                if (isnowlocking && locked != null)
                {
                    liner.SetPosition(0, start);
                    liner.SetPosition(1, locked.transform.position);

                    if (!Libs.RT())
                    {
                        locked = null;
                        isnowlocking = false;
                        isinpos = true;
                        isinpos2 = true;
                    }

                    return;
                }

                if (Physics.Raycast(start, dir, out hitstart, 7234578f))
                {
                    liner.SetPosition(0, start);
                    if (isinpos2)
                        liner.SetPosition(1, hitstart.point);
                    var where = hitstart.collider.GetComponentInParent<VRRig>();
                    if (Libs.RT() && where != null && !isnowlocking)
                    {
                        isinpos2 = false;
                        isinpos = false;
                        locked = where;
                        isnowlocking = true;
                    }
                }
                else
                {
                    liner.SetPosition(0, start);
                    liner.SetPosition(1, start + dir * 100f);
                }
            }
            else
            {
                if (renda != null)
                {
                    Object.Destroy(renda);
                    renda = null;
                    liner = null;
                    locked = null;
                    isnowlocking = false;
                    isinpos = true;
                    isinpos2 = true;
                }
            }
        }
        public static void pcgun()
        {
            if (Mouse.current.rightButton.isPressed)
            {
                if (renda == null)
                {
                    renda = new GameObject("guon");
                    liner = renda.AddComponent<LineRenderer>();
                    liner.startColor = Color.gray;
                    liner.endColor = Color.black;
                    liner.startWidth = 0.05f;
                    liner.endWidth = 0.03f;
                    liner.useWorldSpace = true;
                    liner.material.shader = espshaders;
                }

                if (isnowlocking && locked != null)
                {
                    liner.SetPosition(0, Camera.main.transform.position);
                    liner.SetPosition(1, locked.transform.position);

                    if (!Mouse.current.leftButton.isPressed)
                    {
                        locked = null;
                        isnowlocking = false;
                        isinpos = true;
                        isinpos2 = true;
                    }

                    return;
                }

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitstart, 7234578f))
                {
                    liner.SetPosition(0, Camera.main.transform.position);
                    if (isinpos2)
                    {
                        liner.SetPosition(1, hitstart.point);
                    }
                    var where = hitstart.collider.GetComponentInParent<VRRig>();
                    if (Mouse.current.leftButton.wasPressedThisFrame && where != null && !isnowlocking)
                    {
                        isinpos2 = false;
                        isinpos = false;
                        locked = where;
                        isnowlocking = true;
                    }
                }
                else
                {
                    liner.SetPosition(0, Camera.main.transform.position);
                    liner.SetPosition(1, Camera.main.transform.position + Camera.main.transform.forward * 100f);
                }
            }
            else
            {
                if (renda != null)
                {
                    Object.Destroy(renda);
                    renda = null;
                    liner = null;
                    locked = null;
                    isnowlocking = false;
                    isinpos = true;
                    isinpos2 = true;
                }
            }
        }
    }
}
