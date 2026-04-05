using System;

namespace hamburburPluginTemplate.Backend;

public enum PluginCategory
{
    Main,
    Fun,
    Misc,
    Movement,
    Multiplayer,
    OP,
    Rig,
    Settings,
    Visual,
    Bacon,

}

[AttributeUsage(AttributeTargets.Class)]
public class hamburburPluginAttribute(PluginCategory category) : Attribute
{
    public PluginCategory Category { get; } = category;
}