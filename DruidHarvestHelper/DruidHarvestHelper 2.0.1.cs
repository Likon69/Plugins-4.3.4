/*
 * Druid Harvest Helper
 *      Will lock HB if we are within 10 yards of herb,
 *      in Flight Form and under fire (in combat) and
 *      attempt to harvest herb itself.
 *      
 *      As GB2's harvesting is not accessible from outside
 *      i had to write my own harvesting, 
 *      here are "implications":
 *      - GB2 might add those nodes to blacklist even if DHH
 *        successfully harvest them,
 *      - every 2 minutes DHH will verify GB2 blacklist
 *        removing those actually harvested by DHH,
 *        
 * thanks to bobby53 that i even started writing this :)
 *        
 * Author:  strix
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Styx;
using Styx.Combat.CombatRoutine;
using Styx.Helpers;
using Styx.Logic.BehaviorTree;
using Styx.Logic.Combat;
using Styx.Logic.Pathing;
using Styx.Plugins.PluginClass;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using CommonBehaviors;
using TreeSharp;
using Action = TreeSharp.Action;

namespace nsDruidHarvestHelper
{
    public class DruidHarvestHelper : HBPlugin
    {
        public override string Name { get { return "Druid's Harvest Helper"; } }
        public override string Author { get { return "strix"; } }
        public override Version Version { get { return new Version(2, 0, 1); } }
        public override bool WantButton { get { return false; } }

        public LocalPlayer Me { get { return ObjectManager.Me; } }

        static bool isHarvesting = false;
        static bool haveInitialized = false;

        private HashSet<Styx.Logic.Pathing.WoWPoint> latestHarvests = new HashSet<Styx.Logic.Pathing.WoWPoint>();
        private WoWGameObject currentHerb = null;

        private WaitTimer wtVerifyGB2Blacklist = new WaitTimer(new TimeSpan(0, 2, 0));
        private WaitTimer wtHelper = new WaitTimer(new TimeSpan(0, 0, 3));
        private WaitTimer wtInteractHelper = StyxWoW.Me.Race == WoWRace.Tauren ? new WaitTimer(new TimeSpan(0, 0, 0, 1, 300)) : new WaitTimer(new TimeSpan(0, 0, 0, 2, 0));
        private Stopwatch swHelper = new Stopwatch();
        private bool interactedFlag = false;
        private bool interactedFlag2 = false;
        private bool flagHelper = false;
        private bool shouldAbandonHerb = false;
        private int failCount = 0;

        public override void Pulse()
        {
            if (!haveInitialized)
            {
                isHarvesting = TreeRoot.Current != null && "GATHERBUDDY2" == Left(TreeRoot.Current.Name, 12).ToUpper() && Me.Class == WoWClass.Druid;
                if (isHarvesting)
                {
                    slog("Druid using Gatherbuddy 2 detected... locking HB and launching Druid Harvest Helper harvest if following conditions are met:");
                    slog(" - we are in Flight Form,");
                    slog(" - we are under fire,");
                    slog(" - there is herb withing 10 yards range,");
                }
                haveInitialized = true;
            }

            if (isHarvesting &&
                    (interactedFlag || HerbWithinTen2DRange != null) &&
                    (Me.Shapeshift == ShapeshiftForm.FlightForm || Me.Shapeshift == ShapeshiftForm.EpicFlightForm))
                HarvestHerb();
            if (interactedFlag)
                interactedFlag = false;
            if (currentHerb != null)
                currentHerb = null;
            if (failCount > 0)
                failCount = 0;
            if (shouldAbandonHerb)
                shouldAbandonHerb = false;
            if (interactedFlag2)
                interactedFlag2 = false;

            if (!Me.Combat && wtVerifyGB2Blacklist.IsFinished)
                VerifyGB2BlacklistAndClearLatestHarvests();
        }

        private static string Left(string s, int c)
        {
            return String.IsNullOrEmpty(s) ? s : s.Substring(0, Math.Min(c, s.Length));
        }

        private void slog(string format, params object[] args)
        {
            Logging.Write(Color.Olive, "[Harvest Helper] " + format, args);
        }

        private void elog(string format, params object[] args)
        {
            Logging.Write(Color.Red, "[Harvest Helper] " + format, args);
        }

        private void dlog(string format, params object[] args)
        {
            Logging.WriteDebug(Color.Olive, "<Harvest Helper> " + format, args);
        }

        public static WoWGameObject HerbWithinInteractRange
        {
            get
            {
                ObjectManager.Update();
                var tars = (from o in ObjectManager.GetObjectsOfType<WoWGameObject>(false, false)
                            where o.IsHerb && o.WithinInteractRange && o.RequiredSkill <= StyxWoW.Me.GetSkill("Herbalism").CurrentValue
                            orderby o.DistanceSqr ascending
                            select o);
                return tars.Count() > 0 ? tars.First() : null;
            }
        }

        public static WoWGameObject HerbWithinTen2DRange
        {
            get
            {
                ObjectManager.Update();
                var tars = (from o in ObjectManager.GetObjectsOfType<WoWGameObject>(false, false)
                            where o.IsHerb && o.Distance2D < 10 && o.RequiredSkill <= StyxWoW.Me.GetSkill("Herbalism").CurrentValue
                            orderby o.DistanceSqr ascending
                            select o);
                return tars.Count() > 0 ? tars.First() : null;
            }
        }

        public static WoWGameObject Herb
        {
            get
            {
                ObjectManager.Update();
                var tars = (from o in ObjectManager.GetObjectsOfType<WoWGameObject>(false, false)
                            where o.IsHerb && o.RequiredSkill <= StyxWoW.Me.GetSkill("Herbalism").CurrentValue
                            orderby o.DistanceSqr ascending
                            select o);
                return tars.Count() > 0 ? tars.First() : null;
            }
        }

        public void VerifyGB2BlacklistAndClearLatestHarvests()
        {
            slog("Verifying GB2 blacklist.");
            foreach (WoWPoint point in latestHarvests)
            {
                Bots.Gatherbuddy.GatherbuddyBot.BlacklistNodes.RemoveWhere(p => p == point);
            }
            latestHarvests.Clear();
            wtVerifyGB2Blacklist.Reset();
        }

        public void HarvestHerb()
        {
            
            if (!interactedFlag && Me.Combat)
            {
                slog("Starting harvesting...");
                dlog("HarvestHerb(): starting...");
                if (currentHerb == null)
                {
                    dlog("HarvestHerb(): Assigning currentHerb...");
                    currentHerb = Herb;
                }

                if (currentHerb.Distance2D > 5)
                {
                    WoWMovement.ClickToMove(WoWMathHelper.CalculatePointFrom(Me.Location, Herb.Location, 1));
                    dlog("HarvestHerb(): Getting within interaction range of herb...");
                    wtHelper.Reset();
                    while (currentHerb.Distance2D > 5)
                    {
                        if (wtHelper.IsFinished)
                        {
                            dlog("HarvestHerb(): currentHerb.Distance2d < 5 timed out...");
                            break;
                        }
                    }
                }
                if (Me.IsFlying)
                {
                    dlog("HarvestHerb(): Getting on the ground...");
                    ActuallyStopMoving();
                    Navigator.PlayerMover.Move(WoWMovement.MovementDirection.Descend);
                    wtHelper.Reset();
                    while (Me.IsFlying && !wtHelper.IsFinished) ;
                }
                dlog("HarvestHerb(): Interacting with currentHerb started..");
                int i = 0;
                while (currentHerb.IsValid && !currentHerb.IsDisabled && currentHerb.CanUseNow())
                {
                    ObjectManager.Update();
                    currentHerb.Interact();
                    wtInteractHelper.Reset();
                    if (i > 5)
                    {
                        dlog("HarvestHerb(): Harvesting herb failed for " + i + " times, abandoning it...");
                        shouldAbandonHerb = true;
                        break;
                    }
                    while (!Me.IsCasting)
                    {
                        Styx.BotEvents.PulseEvents();
                        if (wtInteractHelper.IsFinished)
                        {
                            i++;
                            dlog("HarvestHerb(): failed for " + i + " time...");
                            break;
                        }
                    }
                }
                if (!shouldAbandonHerb)
                    dlog("HarvestHerb(): Interacting with currentHerb finished..");
                interactedFlag = true;
            }
            if (interactedFlag)
            {
                if (!Me.IsFlying)
                {
                    dlog("HarvestHerb(): JumpAscend to exit combat...");
                    wtHelper.Reset();
                    while (Me.Combat && !wtHelper.IsFinished)
                    {
                        //Navigator.PlayerMover.Move(
                        //    WoWMovement.MovementDirection.JumpAscend);
                        if (!Me.IsMoving) WoWMovement.Move(WoWMovement.MovementDirection.JumpAscend, TimeSpan.FromMilliseconds(200)); System.Threading.Thread.Sleep(200);
                    }
                    //while (Me.Combat && !wtHelper.IsFinished) ;
                    ActuallyStopMoving();
                }
                if (shouldAbandonHerb)
                    currentHerb = null;
                if (currentHerb != null)
                {
                    if (latestHarvests.Add(currentHerb.Location))
                        dlog("Added currentHerb to latestHarvests");
                    currentHerb = null;
                    interactedFlag = false;
                }
                dlog("HarvestHerb() finished.");
                slog("Harvesting finished.");
                return;
            }
        }
        public void ActuallyStopMoving()
        {
            WaitTimer timeout = new WaitTimer(new TimeSpan(0, 0, 3));
            timeout.Reset();
            dlog("Stopping movement...");
            while (Me.IsMoving) Navigator.PlayerMover.MoveStop();
        }

        private bool gatheringEventStarted = false;
        private bool gatheringEventFailed = false;
        private bool gatheringEventSucceeded = false;
        private bool gatheringEventLootOpened = false;

        public override void Initialize()
        {
            base.Initialize();
            Lua.Events.AttachEvent("UNIT_SPELLCAST_CHANNEL_START", HandleSpellcastStartEvent);
            Lua.Events.AttachEvent("UNIT_SPELLCAST_START", HandleSpellcastStartEvent);
            Lua.Events.AttachEvent("UNIT_SPELLCAST_FAILED", HandleSpellcastFailedEvent);
            Lua.Events.AttachEvent("UNIT_SPELLCAST_FAILED_QUIET", HandleSpellcastFailedEvent);
            Lua.Events.AttachEvent("UNIT_SPELLCAST_SUCCEEDED", HandleSpellcastSucceededEvent);
            Lua.Events.AttachEvent("LOOT_OPENED", HandleLootOpenedEvent);
        }

        public override void Dispose()
        {
            base.Dispose();
            Lua.Events.DetachEvent("UNIT_SPELLCAST_CHANNEL_START", HandleSpellcastStartEvent);
            Lua.Events.DetachEvent("UNIT_SPELLCAST_START", HandleSpellcastStartEvent);
            Lua.Events.DetachEvent("UNIT_SPELLCAST_FAILED", HandleSpellcastFailedEvent);
            Lua.Events.DetachEvent("UNIT_SPELLCAST_FAILED_QUIET", HandleSpellcastFailedEvent);
            Lua.Events.DetachEvent("UNIT_SPELLCAST_SUCCEEDED", HandleSpellcastSucceededEvent);
            Lua.Events.DetachEvent("LOOT_OPENED", HandleLootOpenedEvent);
        }

        private void HandleSpellcastStartEvent(object sender, LuaEventArgs args)
        {
            if (args.Args[0].ToString() == "player")
            {
                if (args.Args[1].ToString().ToUpper() == "HERB GATHERING")
                {
                    gatheringEventStarted = true;
                    dlog("UNIT_SPELLCAST_START fired!");
                }
            }
        }

        private void HandleSpellcastFailedEvent(object sender, LuaEventArgs args)
        {
            if (args.Args[0].ToString() == "player")
            {
                if (args.Args[1].ToString().ToUpper() == "HERB GATHERING")
                {
                    gatheringEventFailed = true;
                    dlog("UNIT_SPELLCAST_FAILED fired!");
                }
            }
        }

        private void HandleSpellcastSucceededEvent(object sender, LuaEventArgs args)
        {
            if (args.Args[0].ToString() == "player")
            {
                if (args.Args[1].ToString().ToUpper() == "HERB GATHERING")
                {
                    gatheringEventSucceeded = true;
                    dlog("UNIT_SPELLCAST_SUCCEEDED fired!");
                }
            }
        }

        private void HandleLootOpenedEvent(object sender, LuaEventArgs args)
        {
            if (args.Args[0].ToString().ToLower() == "true")
            {
                gatheringEventLootOpened = true;
                dlog("LOOT_OPENED fired!");
            }
        }

        private void ResetEvents()
        {
            dlog("Before ResetEvents():");
            dlog("gatheringEventStarted: " + gatheringEventStarted);
            dlog("gatheringEventFailed: " + gatheringEventFailed);
            dlog("gatheringEventSucceeded: " + gatheringEventSucceeded);
            dlog("gatheringEventLootOpened: " + gatheringEventStarted);
            gatheringEventFailed = false;
            gatheringEventSucceeded = false;
            gatheringEventStarted = false;
            gatheringEventLootOpened = false;
        }
    }
}

