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
        public static readonly ModSettingBool Use2DDisplay = true;
        public static readonly ModSettingBool baseEeveeNerfRange = false;
        public static readonly ModSettingBool baseEeveeNerfPierce = false;
        public static readonly ModSettingBool baseEeveeNerfCost = true;
        public static readonly ModSettingBool AltStrongEevee = false;
        //public static readonly ModSettingBool flareonNerf = false;
    }
    public class Eevee : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string Name => "Eevee";
        public override string BaseTower => TowerType.Druid;
        public override int Cost => 400;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "A Pokemon-tower with several Evolutions";

        public override string DisplayName => "Eevee";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            if (!Main.baseEeveeNerfRange)
            {
                towerModel.range += 10;
                attackModel.range += 10;
            }
            if (!Main.baseEeveeNerfPierce)
            {
                var projectile = attackModel.weapons[0].projectile;
                projectile.pierce += 2;
            }
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
            }
        }
    }
}

