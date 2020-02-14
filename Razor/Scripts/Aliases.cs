﻿using Assistant.Scripts.Engine;

namespace Assistant.Scripts
{
    public static class Aliases
    {
        public static void Register()
        {
            Interpreter.RegisterAliasHandler("backpack", Backpack);
            Interpreter.RegisterAliasHandler("last", Last);
            Interpreter.RegisterAliasHandler("lasttarget", Last);
            Interpreter.RegisterAliasHandler("lastobject", LastObject);
            Interpreter.RegisterAliasHandler("self", Self);
            Interpreter.RegisterAliasHandler("mount", Mounted);
            Interpreter.RegisterAliasHandler("righthand", RHandEmpty);
            Interpreter.RegisterAliasHandler("lefthand", LHandEmpty);
        }
        
        private static uint Mounted(string alias)
        {
            return World.Player != null && World.Player.GetItemOnLayer(Layer.Mount) != null
                ? (uint) 1
                : (uint) 0;
        }

        private static uint RHandEmpty(string alias)
        {
            return World.Player != null && World.Player.GetItemOnLayer(Layer.RightHand) != null
                ? (uint)1
                : (uint)0;
        }

        private static uint LHandEmpty(string alias)
        {
            return World.Player != null && World.Player.GetItemOnLayer(Layer.LeftHand) != null
                ? (uint)1
                : (uint)0;
        }

        private static uint Backpack(string alias)
        {
            if (World.Player == null || World.Player.Backpack == null)
                return 0;

            return World.Player.Backpack.Serial;
        }
        
        private static uint Last(string alias)
        {
            if (!Targeting.DoLastTarget())
                Targeting.ResendTarget();

            return 0;
        }

        private static uint LastObject(string alias)
        {
            if (World.Player.LastObject != null)
                return World.Player.LastObject;

            return 0;
        }

        private static uint Self(string alias)
        {
            if (World.Player == null)
                return 0;

            return World.Player.Serial;
        }
    }
}