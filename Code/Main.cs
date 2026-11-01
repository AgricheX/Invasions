using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using ReflectionUtility;
using System.Reflection;

namespace Invasions{
    [ModEntry]
    class Main : MonoBehaviour{
        internal const string id = "agriche.mods.worldbox.invasions";
        void Awake(){
        InvasionsPower.init();
        ActorAsset demon = AssetManager.actor_library.get("demon");
        ActorAsset walker = AssetManager.actor_library.get("walker");
        demon.defaultWeapons = List.Of<string>(new string[]{"flame_sword", "evil_staff"});
        walker.use_items = true;
        walker.take_items = false;
        walker.defaultWeapons = List.Of<string>(new string[]{"IceSword", "IceStaff"});
        walker.defaultWeaponsMaterial = List.Of<string>(new string[] { "adamantine" });
        }
    }
}