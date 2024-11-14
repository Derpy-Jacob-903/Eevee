using MelonLoader;
using BTD_Mod_Helper;
using Eevee;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Display;
using NodeLoader;
using BTD_Mod_Helper.Api.ModOptions;
using System;

[assembly: MelonInfo(typeof(Eevee.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Eevee
{
    public class Main : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Eevee loaded!");
        }

        public static readonly ModSettingBool Use2DDisplay = new ModSettingBool(true)
        {
            button = false,
            description = "Use 2D displays instead of the 3D displays." + Environment.NewLine + "Added when v38 broke the 3D displays."
        };
        public static readonly ModSettingInt baseEeveeCostNerf = new ModSettingInt(200)
        {
            description = "Nerf Eevee's Cost." + Environment.NewLine + "Default value matches the difference between the Dart Monkey and Card Monkey."
        };

        public static readonly ModSettingBool JolteonRework = new ModSettingBool(false)
        {
            button = false,
            description = "Jolteon's lighting attack is affected by pierce buffs.. BUT it doesn't fork." + Environment.NewLine + "False => 5x2 damage to 31 Bloons" + Environment.NewLine + "True => 5x2 damage to 21(+pierce buffs) Bloons"
        };

        public static readonly ModSettingBool JolteonFlareonDamageTypeRework = new ModSettingBool(false)
        {
            button = false,
            description = "" + Environment.NewLine + "False => 5x2 damage to 31 Bloons" + Environment.NewLine + "True => 5x2 damage to 21(+pierce buffs) Bloons"
        };
        public static readonly ModSettingBool StrongEeveeRework = new ModSettingBool(false)
        {
            button = false,
            description = "Shift some of \"Strong Eevee\" upgrade's damage to a Ceramic/Fortified damage bonus." + Environment.NewLine + "True ==> Plus one damage, plus one more damage to Ceramic or Fortified Bloons." + Environment.NewLine + "False ==> Plus two damage"
        };
        public static readonly ModSettingBool GlaceonFix = new ModSettingBool(false)
        {
            button = false,
            description = "Fix Glaceon not damaging MOAB-class Bloons." + Environment.NewLine + "(Glaceon copies Cyro Cannon, which can't damage MOAB-class)"
        };

        //public static readonly ModSettingBool flareonNerf = false;
    }
    public class Eevee : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string Name => "Eevee";
        public override string BaseTower => TowerType.Druid;
        public override int Cost => 400 + Main.baseEeveeCostNerf;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "A Pokemon-tower with several Evolutions";

        public override string DisplayName => "Eevee";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            towerModel.range += 10;
            attackModel.range += 10;
            var projectile = attackModel.weapons[0].projectile;
            towerModel.ApplyDisplay<EeveeDisplay>();
        }
        
    }
    public class EeveeDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override float Scale => 1f;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            if (Main.Use2DDisplay)
            {
                Set2DTexture(node, "EeveeBaseDisplay");
                node.transform.GetChild(0).transform.localScale = 0.2f * Vector3.one;
            }
            else
            {
                NodeLoader.NodeLoader.LoadNode(node, "Eevee", mod);
                foreach (SkinnedMeshRenderer s in node.GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    s.SetOutlineColor(new Color(26.7f, 14.1f, 8.6f));
                }
            }
        }
    }
}

