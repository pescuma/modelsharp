// Guids.cs
// MUST match guids.h
using System;

namespace org.pescuma.ModelSharp.VSPlugin
{
    static class GuidList
    {
        public const string guidModelSharp_VSPluginPkgString = "787d0748-976a-4ffc-a92a-4921ba755911";
        public const string guidModelSharp_VSPluginCmdSetString = "19eed9bd-3dde-460f-a49a-6c4d2b0cceba";

        public static readonly Guid guidModelSharp_VSPluginCmdSet = new Guid(guidModelSharp_VSPluginCmdSetString);
    };
}