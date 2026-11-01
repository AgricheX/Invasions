using System;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using NCMS.Utils;

namespace Invasions
{
    class InvasionsPower
    {
        public static void init()
        {
          //Weapons

          ItemAsset IceSword = AssetManager.items.clone("IceSword", "sword");
          IceSword.id = "IceSword";
          IceSword.materials = List.Of<string>(new string[]{"adamantine"});
          IceSword.base_stats[S.damage] = 33f;
          IceSword.base_stats[S.attack_speed] = 120f;
          IceSword.base_stats[S.targets] = 2f;
          IceSword.base_stats[S.critical_damage_multiplier] = 0.1f;
          IceSword.equipment_value = 50;
          IceSword.equipmentType = EquipmentType.Weapon;
          IceSword.path_slash_animation = "effects/slashes/slash_base";
          IceSword.name_class = "item_class_weapon";
          IceSword.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "sword_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
          IceSword.action_attack_target = new AttackAction(GeloAttack);
          AssetManager.items.list.AddItem(IceSword);
          Localization.addLocalization("item_IceSword", "IceSword");
          addWeaponsSprite(IceSword.id, IceSword.materials[0]);

          ItemAsset IceStaff = AssetManager.items.clone("IceStaff", "_range");
          IceStaff.id = "IceStaff";
          IceStaff.materials = List.Of<string>(new string[]{"adamantine"});
          IceStaff.base_stats[S.attack_speed] = 20f;
		  IceStaff.base_stats[S.range] = 22f;
		  IceStaff.base_stats[S.critical_chance] = 10f;
		  IceStaff.base_stats[S.targets] = 1;
          IceStaff.base_stats[S.critical_damage_multiplier] = 0.5f;
		  IceStaff.base_stats[S.damage] = 35;
          IceStaff.equipment_value = 50;
          IceStaff.equipmentType = EquipmentType.Weapon;
          IceStaff.path_slash_animation = "effects/slashes/punch";
          IceStaff.projectile = "freeze_orb";
          IceStaff.name_class = "item_class_weapon";
          IceStaff.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "sword_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
          IceStaff.action_attack_target = new AttackAction(GeloAttack);
          AssetManager.items.list.AddItem(IceStaff);
          Localization.addLocalization("item_IceStaff", "IceStaff");
          addWeaponsSprite(IceStaff.id, IceStaff.materials[0]);
            
            //Demons

            DisasterAsset demonsinvasionv1 = new DisasterAsset();
            demonsinvasionv1.id = "demonsv1";
            demonsinvasionv1.rate = 9;
            demonsinvasionv1.chance = 0.9f;
            demonsinvasionv1.min_world_cities = 1;
            demonsinvasionv1.max_existing_units = 1;
            demonsinvasionv1.world_log = "An army of level 1 Demons has invaded the world!";
            demonsinvasionv1.world_log_icon = "iconDemon";
            demonsinvasionv1.min_world_population = 200;
            demonsinvasionv1.spawn_asset_building = "flame_tower";
            demonsinvasionv1.spawn_asset_unit = "demon";
            demonsinvasionv1.units_min = 10;
            demonsinvasionv1.units_max = 20;
            demonsinvasionv1.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv1);

            DisasterAsset demonsinvasionv2 = new DisasterAsset();
            demonsinvasionv2.id = "demonsv2";
            demonsinvasionv2.rate = 8;
            demonsinvasionv2.chance = 0.8f;
            demonsinvasionv2.min_world_cities = 1;
            demonsinvasionv2.max_existing_units = 20;
            demonsinvasionv2.world_log = "An army of level 2 Demons has invaded the world!";
            demonsinvasionv2.world_log_icon = "iconDemon";
            demonsinvasionv2.min_world_population = 700;
            demonsinvasionv2.spawn_asset_building = "flame_tower";
            demonsinvasionv2.spawn_asset_unit = "demon";
            demonsinvasionv2.units_min = 20;
            demonsinvasionv2.units_max = 50;
            demonsinvasionv2.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv2);

            DisasterAsset demonsinvasionv3 = new DisasterAsset();
            demonsinvasionv3.id = "demonsv3";
            demonsinvasionv3.rate = 7;
            demonsinvasionv3.chance = 0.7f;
            demonsinvasionv3.min_world_cities = 1;
            demonsinvasionv3.max_existing_units = 50;
            demonsinvasionv3.world_log = "An army of level 3 Demons has invaded the world!";
            demonsinvasionv3.world_log_icon = "iconDemon";
            demonsinvasionv3.min_world_population = 1500;
            demonsinvasionv3.spawn_asset_building = "flame_tower";
            demonsinvasionv3.spawn_asset_unit = "demon";
            demonsinvasionv3.units_min = 50;
            demonsinvasionv3.units_max = 100;
            demonsinvasionv3.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv3);

            DisasterAsset demonsinvasionv4 = new DisasterAsset();
            demonsinvasionv4.id = "demonsv4";
            demonsinvasionv4.rate = 6;
            demonsinvasionv4.chance = 0.6f;
            demonsinvasionv4.min_world_cities = 1;
            demonsinvasionv4.max_existing_units = 100;
            demonsinvasionv4.world_log = "An army of level 4 Demons has invaded the world!";
            demonsinvasionv4.world_log_icon = "iconDemon";
            demonsinvasionv4.min_world_population = 3000;
            demonsinvasionv4.spawn_asset_building = "flame_tower";
            demonsinvasionv4.spawn_asset_unit = "demon";
            demonsinvasionv4.units_min = 100;
            demonsinvasionv4.units_max = 200;
            demonsinvasionv4.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv4);

            DisasterAsset demonsinvasionv5 = new DisasterAsset();
            demonsinvasionv5.id = "demonsv5";
            demonsinvasionv5.rate = 5;
            demonsinvasionv5.chance = 0.5f;
            demonsinvasionv5.min_world_cities = 1;
            demonsinvasionv5.max_existing_units = 200;
            demonsinvasionv5.world_log = "An army of level 5 Demons has invaded the world!";
            demonsinvasionv5.world_log_icon = "iconDemon";
            demonsinvasionv5.min_world_population = 6000;
            demonsinvasionv5.spawn_asset_building = "flame_tower";
            demonsinvasionv5.spawn_asset_unit = "demon";
            demonsinvasionv5.units_min = 200;
            demonsinvasionv5.units_max = 500;
            demonsinvasionv5.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv5);

            DisasterAsset demonsinvasionv6 = new DisasterAsset();
            demonsinvasionv6.id = "demonsv6";
            demonsinvasionv6.rate = 4;
            demonsinvasionv6.chance = 0.4f;
            demonsinvasionv6.min_world_cities = 1;
            demonsinvasionv6.max_existing_units = 500;
            demonsinvasionv6.world_log = "An army of level 6 Demons has invaded the world!";
            demonsinvasionv6.world_log_icon = "iconDemon";
            demonsinvasionv6.min_world_population = 10000;
            demonsinvasionv6.spawn_asset_building = "flame_tower";
            demonsinvasionv6.spawn_asset_unit = "demon";
            demonsinvasionv6.units_min = 500;
            demonsinvasionv6.units_max = 2000;
            demonsinvasionv6.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv6);

            DisasterAsset demonsinvasionv7 = new DisasterAsset();
            demonsinvasionv7.id = "demonsv7";
            demonsinvasionv7.rate = 3;
            demonsinvasionv7.chance = 0.3f;
            demonsinvasionv7.min_world_cities = 1;
            demonsinvasionv7.max_existing_units = 2000;
            demonsinvasionv7.world_log = "An army of level 7 Demons has invaded the world!";
            demonsinvasionv7.world_log_icon = "iconDemon";
            demonsinvasionv7.min_world_population = 15000;
            demonsinvasionv7.spawn_asset_building = "flame_tower";
            demonsinvasionv7.spawn_asset_unit = "demon";
            demonsinvasionv7.units_min = 2000;
            demonsinvasionv7.units_max = 5000;
            demonsinvasionv7.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv7);

            DisasterAsset demonsinvasionv8 = new DisasterAsset();
            demonsinvasionv8.id = "demonsv8";
            demonsinvasionv8.rate = 2;
            demonsinvasionv8.chance = 0.2f;
            demonsinvasionv8.min_world_cities = 1;
            demonsinvasionv8.max_existing_units = 5000;
            demonsinvasionv8.world_log = "An army of level 8 Demons has invaded the world!";
            demonsinvasionv8.world_log_icon = "iconDemon";
            demonsinvasionv8.min_world_population = 20000;
            demonsinvasionv8.spawn_asset_building = "flame_tower";
            demonsinvasionv8.spawn_asset_unit = "demon";
            demonsinvasionv8.units_min = 5000;
            demonsinvasionv8.units_max = 7000;
            demonsinvasionv8.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv8);

            DisasterAsset demonsinvasionv9 = new DisasterAsset();
            demonsinvasionv9.id = "demonsv9";
            demonsinvasionv9.rate = 1;
            demonsinvasionv9.chance = 0.1f;
            demonsinvasionv9.min_world_cities = 1;
            demonsinvasionv9.max_existing_units = 7000;
            demonsinvasionv9.world_log = "An army of level 9Demons has invaded the world!";
            demonsinvasionv9.world_log_icon = "iconDemon";
            demonsinvasionv9.min_world_population = 30000;
            demonsinvasionv9.spawn_asset_building = "flame_tower";
            demonsinvasionv9.spawn_asset_unit = "demon";
            demonsinvasionv9.units_min = 7000;
            demonsinvasionv9.units_max = 10000;
            demonsinvasionv9.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(demonsinvasionv9);

            //Walkers

            DisasterAsset walkerinvasionv1 = new DisasterAsset();
            walkerinvasionv1.id = "walkersv1";
            walkerinvasionv1.rate = 9;
            walkerinvasionv1.chance = 0.9f;
            walkerinvasionv1.min_world_cities = 1;
            walkerinvasionv1.max_existing_units = 1;
            walkerinvasionv1.world_log = "An army of level 1 Walkers has invaded the world!";
            walkerinvasionv1.world_log_icon = "iconWalker";
            walkerinvasionv1.min_world_population = 200;
            walkerinvasionv1.spawn_asset_building = "ice_tower";
            walkerinvasionv1.spawn_asset_unit = "walker";
            walkerinvasionv1.units_min = 10;
            walkerinvasionv1.units_max = 20;
            walkerinvasionv1.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv1);

            DisasterAsset walkerinvasionv2 = new DisasterAsset();
            walkerinvasionv2.id = "walkersv2";
            walkerinvasionv2.rate = 8;
            walkerinvasionv2.chance = 0.8f;
            walkerinvasionv2.min_world_cities = 1;
            walkerinvasionv2.max_existing_units = 20;
            walkerinvasionv2.world_log = "An army of level 2 Walkers has invaded the world!";
            walkerinvasionv2.world_log_icon = "iconWalker";
            walkerinvasionv2.min_world_population = 700;
            walkerinvasionv2.spawn_asset_building = "ice_tower";
            walkerinvasionv2.spawn_asset_unit = "walker";
            walkerinvasionv2.units_min = 20;
            walkerinvasionv2.units_max = 50;
            walkerinvasionv2.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv2);

            DisasterAsset walkerinvasionv3 = new DisasterAsset();
            walkerinvasionv3.id = "walkersv3";
            walkerinvasionv3.rate = 7;
            walkerinvasionv3.chance = 0.7f;
            walkerinvasionv3.min_world_cities = 1;
            walkerinvasionv3.max_existing_units = 50;
            walkerinvasionv3.world_log = "An army of level 3 Walkers has invaded the world!";
            walkerinvasionv3.world_log_icon = "iconWalker";
            walkerinvasionv3.min_world_population = 1500;
            walkerinvasionv3.spawn_asset_building = "ice_tower";
            walkerinvasionv3.spawn_asset_unit = "walker";
            walkerinvasionv3.units_min = 50;
            walkerinvasionv3.units_max = 100;
            walkerinvasionv3.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv3);

            DisasterAsset walkerinvasionv4 = new DisasterAsset();
            walkerinvasionv4.id = "walkersv4";
            walkerinvasionv4.rate = 6;
            walkerinvasionv4.chance = 0.6f;
            walkerinvasionv4.min_world_cities = 1;
            walkerinvasionv4.max_existing_units = 100;
            walkerinvasionv4.world_log = "An army of level 4 Walkers has invaded the world!";
            walkerinvasionv4.world_log_icon = "iconWalker";
            walkerinvasionv4.min_world_population = 3000;
            walkerinvasionv4.spawn_asset_building = "ice_tower";
            walkerinvasionv4.spawn_asset_unit = "walker";
            walkerinvasionv4.units_min = 100;
            walkerinvasionv4.units_max = 200;
            walkerinvasionv4.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv4);

            DisasterAsset walkerinvasionv5 = new DisasterAsset();
            walkerinvasionv5.id = "walkersv5";
            walkerinvasionv5.rate = 5;
            walkerinvasionv5.chance = 0.5f;
            walkerinvasionv5.min_world_cities = 1;
            walkerinvasionv5.max_existing_units = 200;
            walkerinvasionv5.world_log = "An army of level 5 Walkers has invaded the world!";
            walkerinvasionv5.world_log_icon = "iconWalker";
            walkerinvasionv5.min_world_population = 6000;
            walkerinvasionv5.spawn_asset_building = "ice_tower";
            walkerinvasionv5.spawn_asset_unit = "walker";
            walkerinvasionv5.units_min = 200;
            walkerinvasionv5.units_max = 500;
            walkerinvasionv5.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv5);

            DisasterAsset walkerinvasionv6 = new DisasterAsset();
            walkerinvasionv6.id = "walkersv6";
            walkerinvasionv6.rate = 4;
            walkerinvasionv6.chance = 0.4f;
            walkerinvasionv6.min_world_cities = 1;
            walkerinvasionv6.max_existing_units = 500;
            walkerinvasionv6.world_log = "An army of level 6 Walkers has invaded the world!";
            walkerinvasionv6.world_log_icon = "iconWalker";
            walkerinvasionv6.min_world_population = 10000;
            walkerinvasionv6.spawn_asset_building = "ice_tower";
            walkerinvasionv6.spawn_asset_unit = "walker";
            walkerinvasionv6.units_min = 500;
            walkerinvasionv6.units_max = 2000;
            walkerinvasionv6.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv6);

            DisasterAsset walkerinvasionv7 = new DisasterAsset();
            walkerinvasionv7.id = "walkersv7";
            walkerinvasionv7.rate = 3;
            walkerinvasionv7.chance = 0.3f;
            walkerinvasionv7.min_world_cities = 1;
            walkerinvasionv7.max_existing_units = 2000;
            walkerinvasionv7.world_log = "An army of level 7 Walkers has invaded the world!";
            walkerinvasionv7.world_log_icon = "iconWalker";
            walkerinvasionv7.min_world_population = 15000;
            walkerinvasionv7.spawn_asset_building = "ice_tower";
            walkerinvasionv7.spawn_asset_unit = "walker";
            walkerinvasionv7.units_min = 2000;
            walkerinvasionv7.units_max = 5000;
            walkerinvasionv7.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv7);

            DisasterAsset walkerinvasionv8 = new DisasterAsset();
            walkerinvasionv8.id = "walkersv8";
            walkerinvasionv8.rate = 2;
            walkerinvasionv8.chance = 0.2f;
            walkerinvasionv8.min_world_cities = 1;
            walkerinvasionv8.max_existing_units = 5000;
            walkerinvasionv8.world_log = "An army of level 8 Walkers has invaded the world!";
            walkerinvasionv8.world_log_icon = "iconWalker";
            walkerinvasionv8.min_world_population = 20000;
            walkerinvasionv8.spawn_asset_building = "ice_tower";
            walkerinvasionv8.spawn_asset_unit = "walker";
            walkerinvasionv8.units_min = 5000;
            walkerinvasionv8.units_max = 7000;
            walkerinvasionv8.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv8);

            DisasterAsset walkerinvasionv9 = new DisasterAsset();
            walkerinvasionv9.id = "walkersv9";
            walkerinvasionv9.rate = 1;
            walkerinvasionv9.chance = 0.1f;
            walkerinvasionv9.min_world_cities = 1;
            walkerinvasionv9.max_existing_units = 7000;
            walkerinvasionv9.world_log = "An army of level 9 Walkers has invaded the world!";
            walkerinvasionv9.world_log_icon = "iconWalker";
            walkerinvasionv9.min_world_population = 30000;
            walkerinvasionv9.spawn_asset_building = "ice_tower";
            walkerinvasionv9.spawn_asset_unit = "walker";
            walkerinvasionv9.units_min = 7000;
            walkerinvasionv9.units_max = 10000;
            walkerinvasionv9.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(walkerinvasionv9);

            //Assimilator

            DisasterAsset assimilatorinvasionv1 = new DisasterAsset();
            assimilatorinvasionv1.id = "assimilatorsv1";
            assimilatorinvasionv1.rate = 9;
            assimilatorinvasionv1.chance = 0.9f;
            assimilatorinvasionv1.min_world_cities = 1;
            assimilatorinvasionv1.max_existing_units = 1;
            assimilatorinvasionv1.world_log = "An army of level 1 Assimilators has invaded the world!";
            assimilatorinvasionv1.world_log_icon = "iconHumans";
            assimilatorinvasionv1.min_world_population = 500;
            assimilatorinvasionv1.spawn_asset_building = "cybercore";
            assimilatorinvasionv1.spawn_asset_unit = "assimilator";
            assimilatorinvasionv1.units_min = 10;
            assimilatorinvasionv1.units_max = 20;
            assimilatorinvasionv1.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv1);

            DisasterAsset assimilatorinvasionv2 = new DisasterAsset();
            assimilatorinvasionv2.id = "assimilatorsv2";
            assimilatorinvasionv2.rate = 8;
            assimilatorinvasionv2.chance = 0.8f;
            assimilatorinvasionv2.min_world_cities = 1;
            assimilatorinvasionv2.max_existing_units = 20;
            assimilatorinvasionv2.world_log = "An army of level 2 Assimilators has invaded the world!";
            assimilatorinvasionv2.world_log_icon = "iconHumans";
            assimilatorinvasionv2.min_world_population = 1500;
            assimilatorinvasionv2.spawn_asset_building = "cybercore";
            assimilatorinvasionv2.spawn_asset_unit = "assimilator";
            assimilatorinvasionv2.units_min = 20;
            assimilatorinvasionv2.units_max = 50;
            assimilatorinvasionv2.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv2);

            DisasterAsset assimilatorinvasionv3 = new DisasterAsset();
            assimilatorinvasionv3.id = "assimilatorsv3";
            assimilatorinvasionv3.rate = 7;
            assimilatorinvasionv3.chance = 0.7f;
            assimilatorinvasionv3.min_world_cities = 1;
            assimilatorinvasionv3.max_existing_units = 50;
            assimilatorinvasionv3.world_log = "An army of level 3 Assimilators has invaded the world!";
            assimilatorinvasionv3.world_log_icon = "iconHumans";
            assimilatorinvasionv3.min_world_population = 3000;
            assimilatorinvasionv3.spawn_asset_building = "cybercore";
            assimilatorinvasionv3.spawn_asset_unit = "assimilator";
            assimilatorinvasionv3.units_min = 50;
            assimilatorinvasionv3.units_max = 100;
            assimilatorinvasionv3.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv3);

            DisasterAsset assimilatorinvasionv4 = new DisasterAsset();
            assimilatorinvasionv4.id = "assimilatorsv4";
            assimilatorinvasionv4.rate = 6;
            assimilatorinvasionv4.chance = 0.6f;
            assimilatorinvasionv4.min_world_cities = 1;
            assimilatorinvasionv4.max_existing_units = 100;
            assimilatorinvasionv4.world_log = "An army of level 4 Assimilators has invaded the world!";
            assimilatorinvasionv4.world_log_icon = "iconHumans";
            assimilatorinvasionv4.min_world_population = 5000;
            assimilatorinvasionv4.spawn_asset_building = "cybercore";
            assimilatorinvasionv4.spawn_asset_unit = "assimilator";
            assimilatorinvasionv4.units_min = 100;
            assimilatorinvasionv4.units_max = 200;
            assimilatorinvasionv4.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv4);

            DisasterAsset assimilatorinvasionv5 = new DisasterAsset();
            assimilatorinvasionv5.id = "assimilatorsv5";
            assimilatorinvasionv5.rate = 5;
            assimilatorinvasionv5.chance = 0.5f;
            assimilatorinvasionv5.min_world_cities = 1;
            assimilatorinvasionv5.max_existing_units = 200;
            assimilatorinvasionv5.world_log = "An army of level 5 Assimilators has invaded the world!";
            assimilatorinvasionv5.world_log_icon = "iconHumans";
            assimilatorinvasionv5.min_world_population = 6500;
            assimilatorinvasionv5.spawn_asset_building = "cybercore";
            assimilatorinvasionv5.spawn_asset_unit = "assimilator";
            assimilatorinvasionv5.units_min = 200;
            assimilatorinvasionv5.units_max = 500;
            assimilatorinvasionv5.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv5);

            DisasterAsset assimilatorinvasionv6 = new DisasterAsset();
            assimilatorinvasionv6.id = "assimilatorsv6";
            assimilatorinvasionv6.rate = 4;
            assimilatorinvasionv6.chance = 0.4f;
            assimilatorinvasionv6.min_world_cities = 1;
            assimilatorinvasionv6.max_existing_units = 500;
            assimilatorinvasionv6.world_log = "An army of level 6 Assimilators has invaded the world!";
            assimilatorinvasionv6.world_log_icon = "iconHumans";
            assimilatorinvasionv6.min_world_population = 11000;
            assimilatorinvasionv6.spawn_asset_building = "cybercore";
            assimilatorinvasionv6.spawn_asset_unit = "assimilator";
            assimilatorinvasionv6.units_min = 500;
            assimilatorinvasionv6.units_max = 2000;
            assimilatorinvasionv6.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv6);

            DisasterAsset assimilatorinvasionv7 = new DisasterAsset();
            assimilatorinvasionv7.id = "assimilatorsv7";
            assimilatorinvasionv7.rate = 3;
            assimilatorinvasionv7.chance = 0.3f;
            assimilatorinvasionv7.min_world_cities = 1;
            assimilatorinvasionv7.max_existing_units = 2000;
            assimilatorinvasionv7.world_log = "An army of level 7 Assimilators has invaded the world!";
            assimilatorinvasionv7.world_log_icon = "iconHumans";
            assimilatorinvasionv7.min_world_population = 20000;
            assimilatorinvasionv7.spawn_asset_building = "cybercore";
            assimilatorinvasionv7.spawn_asset_unit = "assimilator";
            assimilatorinvasionv7.units_min = 2000;
            assimilatorinvasionv7.units_max = 5000;
            assimilatorinvasionv7.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv7);

            DisasterAsset assimilatorinvasionv8 = new DisasterAsset();
            assimilatorinvasionv8.id = "assimilatorsv8";
            assimilatorinvasionv8.rate = 2;
            assimilatorinvasionv8.chance = 0.2f;
            assimilatorinvasionv8.min_world_cities = 1;
            assimilatorinvasionv8.max_existing_units = 5000;
            assimilatorinvasionv8.world_log = "An army of level 8 Assimilators has invaded the world!";
            assimilatorinvasionv8.world_log_icon = "iconHumans";
            assimilatorinvasionv8.min_world_population = 30000;
            assimilatorinvasionv8.spawn_asset_building = "cybercore";
            assimilatorinvasionv8.spawn_asset_unit = "assimilator";
            assimilatorinvasionv8.units_min = 5000;
            assimilatorinvasionv8.units_max = 7000;
            assimilatorinvasionv8.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv8);

            DisasterAsset assimilatorinvasionv9 = new DisasterAsset();
            assimilatorinvasionv9.id = "assimilatorsv9";
            assimilatorinvasionv9.rate = 1;
            assimilatorinvasionv9.chance = 0.1f;
            assimilatorinvasionv9.min_world_cities = 1;
            assimilatorinvasionv9.max_existing_units = 7000;
            assimilatorinvasionv9.world_log = "An army of level 9 Assimilators has invaded the world!";
            assimilatorinvasionv9.world_log_icon = "iconHumans";
            assimilatorinvasionv9.min_world_population = 40000;
            assimilatorinvasionv9.spawn_asset_building = "cybercore";
            assimilatorinvasionv9.spawn_asset_unit = "assimilator";
            assimilatorinvasionv9.units_min = 7000;
            assimilatorinvasionv9.units_max = 10000;
            assimilatorinvasionv9.action = new DisasterAction(AssetManager.disasters.spawnBiomass);
			AssetManager.disasters.add(assimilatorinvasionv9);

            //Dragon

            DisasterAsset dragoninvasionv1 = new DisasterAsset();
            dragoninvasionv1.id = "dragonsv1";
            dragoninvasionv1.rate = 5;
            dragoninvasionv1.chance = 0.6f;
            dragoninvasionv1.min_world_cities = 1;
            dragoninvasionv1.max_existing_units = 10;
            dragoninvasionv1.world_log = "An army of Dragons has invaded the world!";
            dragoninvasionv1.world_log_icon = "iconDragon";
            dragoninvasionv1.min_world_population = 2000;
            dragoninvasionv1.spawn_asset_unit = "dragon";
            dragoninvasionv1.units_min = 10;
            dragoninvasionv1.units_max = 20;
            dragoninvasionv1.action = new DisasterAction(AssetManager.disasters.spawnDragon);
			AssetManager.disasters.add(dragoninvasionv1);

            //Ufo

            DisasterAsset UFOinvasionv1 = new DisasterAsset();
            UFOinvasionv1.id = "UFOsv1";
            UFOinvasionv1.rate = 5;
            UFOinvasionv1.chance = 0.3f;
            UFOinvasionv1.min_world_cities = 1;
            UFOinvasionv1.max_existing_units = 10;
            UFOinvasionv1.world_log = "An army of UFOs has invaded the world!";
            UFOinvasionv1.world_log_icon = "iconUfo";
            UFOinvasionv1.min_world_population = 6000;
            UFOinvasionv1.spawn_asset_unit = "UFO";
            UFOinvasionv1.units_min = 10;
            UFOinvasionv1.units_max = 20;
            UFOinvasionv1.action = new DisasterAction(AssetManager.disasters.startAlienInvasion);
			AssetManager.disasters.add(UFOinvasionv1);

            //Effects
        }
        public static bool GeloAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
        if(pTarget != null){
        Actor a = Reflection.GetField(pTarget.GetType(), pTarget, "a") as Actor;
        pTarget.CallMethod("addStatusEffect", "frozen", 15f);
        }
        return false;

        }
        static void addWeaponsSprite(string id, string material)
         {
          var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
          var sprite = Resources.Load<Sprite>("Weapons/w_" + id + "_" + material);
          dictItems.Add(sprite.name, sprite);
         }
    }
}