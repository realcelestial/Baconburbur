using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using hamburbur.GUI;
using hamburbur.Mod_Backend;
using hamburburPluginTemplate.Backend;

namespace hamburburPluginTemplate;

//You need to have hamburbur menu to be able to use custom plugins, do not remove this!
[BepInDependency("org.hamburbur.menu")]
[BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
public class Plugin : BaseUnityPlugin
{
    private IEnumerator Start()
    {
        //Do not mess with anything in here unless you know what you're doing!
        //You don't need to change anything in the class to create the custom plugin

        while (!hamburbur.Plugin.Instance.MenuLoaded)
            yield return null;

        IEnumerable<Type> modTypes = Assembly.GetExecutingAssembly().GetTypes()
                                             .Where(t => typeof(hamburburmod).IsAssignableFrom(t)                 &&
                                                         t.GetCustomAttribute<hamburburmodAttribute>()    != null &&
                                                         t.GetCustomAttribute<hamburburPluginAttribute>() != null);

        foreach (Type type in modTypes)
        {
            hamburburPluginAttribute pluginAttribute   = type.GetCustomAttribute<hamburburPluginAttribute>();
            string                   categoryName = pluginAttribute.Category.ToString(); //Enum name matches the category name

            if (!Buttons.Categories.ContainsKey(categoryName))
                Buttons.Categories[categoryName] = [];

            ButtonHandler.AddButton(categoryName, type);
        }
    }
}