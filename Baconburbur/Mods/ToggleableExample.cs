using hamburbur.Components;
using hamburbur.GUI;
using hamburbur.Managers;
using hamburbur.Mod_Backend;
using hamburburPluginTemplate.Backend;
using UnityEngine;

namespace hamburburPluginTemplate.Mods;

//This attribute states what category the mod should appear into
[hamburburPlugin(PluginCategory.Main)]

//This attribute defines some info about the mod, such as the name, description, and what type of button it is
[hamburburmod("Baconburbur", "More content of the Beautiful mod Hamburbur!",
        ButtonType.Category, AccessSetting.Public, EnabledType.Disabled, 0)]
public class ToggleableExample : hamburburmod //Ensure it inherits from hamburburmod like it does here
{
    protected override void Pressed() //When you enable the mod
    {
        Singleton<ButtonHandler>.Instance.SetCategory("Bacon", true);
    }
   

        //Below are some examples on what else you can do

        protected override void Start() { } //Runs once when the menu loads, and never again

        protected override void Update() { } //Called once every frame

        protected override void LateUpdate() { } //Called once every frame after everything in update that frame was done

        protected override void FixedUpdate() { } //Called at a constant time interval rather than frame based

        protected override void OnGUI() { } //Called multiple times per frame, used for rendering ui elements
    }
