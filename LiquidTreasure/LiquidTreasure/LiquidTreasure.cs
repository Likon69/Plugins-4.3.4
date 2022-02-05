

using Styx.Logic.Pathing;
using Styx.Plugins.PluginClass;

namespace PluginLiquidTreasure3 {

    #region Styx Namespace
        using Styx;
        using Styx.Helpers;
        using Styx.WoWInternals;
        using Styx.WoWInternals.WoWObjects;
    #endregion Styx Namespace

    #region System Namespace
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading;
        using System.Drawing;
        
        #endregion System Namespace

    internal class LiquidTreasure3 : HBPlugin {
        public override string Name { get { return "LiquidTreasure 4.0"; } }
        public override string Author { get { return "LiquidAtoR"; } }
        public override Version Version { get { return new Version(4, 0, 0, 0); } }
        private bool _init;
        private const int MinimumReputationForExalted = 21000;
        private const int MinimumReputationForBestFriends = 42000;
        public override void Initialize() {
            if (_init) {
                return;
            }
            base.Initialize();
           Logging.Write(Color.FromName("Yellow"), "LiquidTreasure 4.0 ready. Fixe for 4.3.4 by Likon69!");
            _init = true;
        }

        public override void Pulse() {
            if (_init) {
                try {
                    if (!StyxWoW.Me.IsActuallyInCombat || !StyxWoW.Me.IsAlive) {
                        NetherwingEgg();
                        PickUpBOETreasure();
                        //PickUpBOPTreasure();
                    }
                }
                catch (ThreadAbortException) {
                }
            }
        }

        #region MoveToLocation
            public static void MoveToLocation(WoWPoint loc) {
                while (loc.Distance(StyxWoW.Me.Location) > 3) {
                    if (!Flightor.MountHelper.Mounted) {
                        Flightor.MountHelper.MountUp();
                    }
                    if (!StyxWoW.Me.IsMoving) {
                        Flightor.MoveTo(loc);
                    }
                }
            }
        #endregion MoveToLocation

        #region NetherwingEgg
            public static void NetherwingEgg() {
                if (StyxWoW.Me.GetReputationWith(1015) > MinimumReputationForExalted) {
                    return;
                }
                ObjectManager.Update();
                var objList = ObjectManager.GetObjectsOfType<WoWGameObject>().Where(netherwingegg => (netherwingegg.Distance2D 
                    <= Styx.Logic.LootTargeting.LootRadius && (netherwingegg.Entry == 185915)))
                    .OrderBy(netherwingegg => netherwingegg.Distance).ToList();
                foreach (var netherwingegg in objList) {
                    if (!netherwingegg.InLineOfSight) {
                        return;
                    }
                    if (StyxWoW.Me.Combat) {
                        return;
                    }
                    WoWMovement.MoveStop();
                    MoveToLocation(WoWMovement.CalculatePointFrom(netherwingegg.Location, 3));
                    if (!StyxWoW.Me.HasAura(40120) && !StyxWoW.Me.HasAura(33943)) {
                        Flightor.MountHelper.Dismount();
                    }
                    Thread.Sleep(1000);
                    netherwingegg.Interact();
                    Thread.Sleep(2000);
                    Logging.Write(Color.FromName("Yellow"), "[LiquidTreasure 4]: Opened a {0} with ID {1}", netherwingegg.Name, netherwingegg.Entry);
                    if (!Flightor.MountHelper.Mounted) {
                        Flightor.MountHelper.MountUp();
                    }
                    return;
                }
            }
        #endregion NetherwingEgg

        #region PickUpBOETreasure
            public static void PickUpBOETreasure() {
                ObjectManager.Update();
                List<WoWGameObject> objList = ObjectManager.GetObjectsOfType<WoWGameObject>()
                .Where(boe => (boe.Distance2D <= Styx.Logic.LootTargeting.LootRadius &&
                (boe.Entry == 2843) || //(boe.Name == Battered Chest)         
                (boe.Entry == 176944) || // Old Treasure Chest (Scholomance Instance)
                (boe.Entry == 179697) || // Arena Treasure Chest (STV Arena)
                (boe.Entry == 203090) || // Sunken Treaure Chest
                (boe.Entry == 207472) || // Silverbound Treasure Chest (Zone 1)
                (boe.Entry == 207473) || // Silverbound Treasure Chest (Zone 2)
                (boe.Entry == 207474) || // Silverbound Treasure Chest (Zone 3)
                (boe.Entry == 207475) || // Silverbound Treasure Chest (Zone 4)
                (boe.Entry == 207476) || // Silverbound Treasure Chest (Zone 5)
                (boe.Entry == 207477) || // Silverbound Treasure Chest (Zone 6)
                (boe.Entry == 207478) || // Silverbound Treasure Chest (Zone 7)
                (boe.Entry == 207479) || // Silverbound Treasure Chest (Zone 8)
                (boe.Entry == 207480) || // Silverbound Treasure Chest (Zone 9)
                (boe.Entry == 207484) || // Sturdy Treasure Chest (Zone 1)
                (boe.Entry == 207485) || // Sturdy Treasure Chest (Zone 2)
                (boe.Entry == 207486) || // Sturdy Treasure Chest (Zone 3)
                (boe.Entry == 207487) || // Sturdy Treasure Chest (Zone 4)
                (boe.Entry == 207488) || // Sturdy Treasure Chest (Zone 5)
                (boe.Entry == 207489) || // Sturdy Treasure Chest (Zone 6)
                (boe.Entry == 207492) || // Sturdy Treasure Chest (Zone 7)
                (boe.Entry == 207493) || // Sturdy Treasure Chest (Zone 8)
                (boe.Entry == 207494) || // Sturdy Treasure Chest (Zone 9)
                (boe.Entry == 207495) || // Sturdy Treasure Chest (Zone 10)
                (boe.Entry == 207496) || // Dark Iron Treasure Chest (Zone 1)
                (boe.Entry == 207497) || // Dark Iron Treasure Chest (Zone 2)
                (boe.Entry == 207498) || // Dark Iron Treasure Chest (Zone 3)
                (boe.Entry == 207500) || // Dark Iron Treasure Chest (Zone 4)
                (boe.Entry == 207507) || // Dark Iron Treasure Chest (Zone 5)
                (boe.Entry == 207512) || // Silken Treasure Chest (Zone 1)
                (boe.Entry == 207513) || // Silken Treasure Chest (Zone 2)
                (boe.Entry == 207517) || // Silken Treasure Chest (Zone 3)
                (boe.Entry == 207518) || // Silken Treasure Chest (Zone 4)
                (boe.Entry == 207519) || // Silken Treasure Chest (Zone 5)
                (boe.Entry == 207520) || // Maplewood Treasure Chest (Zone 1)
                (boe.Entry == 207521) || // Maplewood Treasure Chest (Zone 2)
                (boe.Entry == 207522) || // Maplewood Treasure Chest (Zone 3)
                (boe.Entry == 207523) || // Maplewood Treasure Chest (Zone 4)
                (boe.Entry == 207524) || // Maplewood Treasure Chest (Zone 5)
                (boe.Entry == 207528) || // Maplewood Treasure Chest (Zone 6)
                (boe.Entry == 207529) || // Maplewood Treasure Chest (Zone 7)
                (boe.Entry == 207533) || // Runestone Treasure Chest (Zone 1)
                (boe.Entry == 207534) || // Runestone Treasure Chest (Zone 2)
                (boe.Entry == 207535) || // Runestone Treasure Chest (Zone 3)
                (boe.Entry == 207540) || // Runestone Treasure Chest (Zone 4)
                (boe.Entry == 207542) || // Runestone Treasure Chest (Zone 5)
                (boe.Entry == 213362) || // Ship's Locker (Contains ~ 96G)
                (boe.Entry == 213650) || // Virmen Treasure Cache (Contains ~ 100G)
                (boe.Entry == 213769) || // Hozen Treasure Cache (Contains ~ 100G)
                (boe.Entry == 213770) || // Stolen Sprite Treasure (Contains ~ 105G)
                (boe.Entry == 213774) || // Lost Adventurer's Belongings (Contains ~ 100G)
                (boe.Entry == 213961) || // Abandoned Crate of Goods (Contains ~ 100G)
                (boe.Entry == 214325) || // Forgotten Lockbox (Contains ~ 10G)
                (boe.Entry == 214407) || // Mo-Mo's Treasure Chest (Contains ~ 9G)
                (boe.Entry == 214337) || // Stash of Gems (few green uncut MoP gems and ~ 7G)
                (boe.Entry == 214337)))  // Offering of Rememberance (Contains ~ 30G and debuff turns you grey)
                .OrderBy(boe => boe.Distance).ToList();
                foreach (WoWGameObject boe in objList) {
                    if (!boe.InLineOfSight) {
                        return;
                    }
                    if (StyxWoW.Me.Combat) {
                        return;
                    }
                    WoWMovement.MoveStop();
                    MoveToLocation(WoWMovement.CalculatePointFrom(boe.Location, 3));
                    if (!StyxWoW.Me.HasAura(40120) && !StyxWoW.Me.HasAura(33943)) {
                        Flightor.MountHelper.Dismount();
                    }
                    Thread.Sleep(1000);
                    boe.Interact();
                    Thread.Sleep(3000);
                    Logging.Write(Color.FromName("Yellow"), "[LiquidTreasure 4]: Opened a {0} with ID {1}", boe.Name, boe.Entry);
                    if (!Flightor.MountHelper.Mounted) {
                        Flightor.MountHelper.MountUp();
                    }
                    return;
                }
            }
        #endregion PickUpBOETreasure

        /*#region PickUpBOPTreasure
            public static void PickUpBOPTreasure() {
                ObjectManager.Update();
                List<WoWGameObject> objList = ObjectManager.GetObjectsOfType<WoWGameObject>()
                .Where(bop => (bop.Distance2D <= Styx.Logic.LootTargeting.LootRadius &&
                (bop.Entry == 213363) || // Wodin's Mantid Shanker
                (bop.Entry == 213364) || // Ancient Pandaren Mining Pick
                (bop.Entry == 213366) || // Ancient Pandaren Tea Pot (Grey trash worth 100G)
                (bop.Entry == 213368) || // Lucky Pandaren Coin (Grey trash worth 95G)
                (bop.Entry == 213649) || // Cache of Pilfered Goods
                (bop.Entry == 213653) || // Pandaren Fishing Spear
                (bop.Entry == 213741) || // Ancient Jinyu Staff
                (bop.Entry == 213742) || // Hammer of Ten Thunders
                (bop.Entry == 213748) || // Pandaren Ritual Stone (Grey trash worth 105G)
                (bop.Entry == 213749) || // Staff of the Hidden Master
                (bop.Entry == 213750) || // Saurok Stone Tablet (Grey trash worth 100G)
                (bop.Entry == 213751) || // Sprite's Cloth Chest
                (bop.Entry == 213765) || // Tablet of Ren Yun (Cooking Recipy)
                (bop.Entry == 213768) || // Hozen Warrior Spear
                (bop.Entry == 213771) || // Statue of Xuen (Grey trash worth 100G)
                (bop.Entry == 213782) || // Terracotta Head (Grey trash worth 100G)
                (bop.Entry == 213793) || // Riktik's Tiny Chest (Grey trash worth 105G)
                (bop.Entry == 213842) || // Stash of Yaungol Weapons
                (bop.Entry == 213844) || // Amber Encased Moth (Grey trash worth 105G)
                (bop.Entry == 213845) || // The Hammer of Folly (Grey trash worth 100G)
                (bop.Entry == 213956) || // Fragment of Dread (Grey trash worth 90G)
                (bop.Entry == 213959) || // Hardened Sap of Kri'vess (Grey trash worth 110G)
                (bop.Entry == 213960) || // Yaungol Fire Carrier
                (bop.Entry == 213962) || // Wind-Reaver's Dagger of Quick Strikes
                (bop.Entry == 213964) || // Malik's Stalwart Spear
                (bop.Entry == 213966) || // Amber Encased Necklace
                (bop.Entry == 213967) || // Blade of the Prime
                (bop.Entry == 213968) || // Swarming Cleaver of Ka'roz
                (bop.Entry == 213969) || // Dissector's Staff of Mutilation
                (bop.Entry == 213970) || // Bloodsoaked Chitin Fragment
                (bop.Entry == 213972) || // Blade of the Poisoned Mind
                (bop.Entry == 214340) || // Boat-Building Instructions (Grey trash worth 10G)
                (bop.Entry == 214438) || // Ancient Mogu Tablet (Grey trash worth 95G)
                (bop.Entry == 214439) || // Barrel of Banana Infused Rum (Cooking Recipy and Rum)
				(bop.Entry == 218593)))  // Trove of the Thunder King (IoTK chest containing a BoP item)
                .OrderBy(bop => bop.Distance).ToList();
                foreach (WoWGameObject bop in objList) {
                    if (!bop.InLineOfSight) {
                        return;
                    }
                    if (StyxWoW.Me.Combat) {
                        return;
                    }
                    WoWMovement.MoveStop();
                    MoveToLocation(WoWMovement.CalculatePointFrom(bop.Location, 3));
                    if (!StyxWoW.Me.HasAura(40120) && !StyxWoW.Me.HasAura(33943)) {
                        Flightor.MountHelper.Dismount();
                    }
                    Thread.Sleep(1000);
                    bop.Interact();
                    Thread.Sleep(3000);
                    Lua.DoString("RunMacroText(\"/click StaticPopup1Button1\");");
                    Logging.Write( "[LiquidTreasure 2]: Opened a {0} with ID {1}", bop.Name, bop.Entry);
                    if (!Flightor.MountHelper.Mounted) {
                        Flightor.MountHelper.MountUp();
                    }
                    return;
                }
            }
        #endregion PickUpBOPTreasure*/
    }
}