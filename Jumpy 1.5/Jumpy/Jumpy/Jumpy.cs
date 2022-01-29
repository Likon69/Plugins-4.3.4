namespace Jumpy
{
    using Styx.Logic;
    using System;
    using Styx.Helpers;
    using Styx.Logic.Pathing;
    using System.Threading;
    using System.Diagnostics;
    using Styx.WoWInternals;
    using Styx.WoWInternals.WoWObjects;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Xml.Linq;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using System.Drawing;
    using Styx.Plugins.PluginClass;
    using Styx;

	public class Jumpy : HBPlugin
	{
		Random rand = new Random();
		public override string Author { get { return "verythaiguy"; } }
		public override string Name { get { return "Jumpy"; } }
		public override Version Version { get { return new System.Version(1, 5); } }
		public override bool WantButton { get { return true; } }
		public override string ButtonText { get { return "Settings"; } }
		public Thread WorkerThread;
		public override void OnButtonPress()
		{
			Window.Show();
		}


		public enum State { Combat, Mounted, Walking };
		JumpyWindow Window = new JumpyWindow();

		Dictionary<State, List<Routine>> Routines
		{
			get
			{
				Dictionary<State, List<Routine>> routines = new Dictionary<State, List<Routine>>();
				routines[State.Combat] = Window.CombatRoutines.Values.Aggregate(new List<Routine>(), (result, next) => { result.AddRange(next); return result; });
				routines[State.Walking] = Window.WalkingRoutines.Values.Aggregate(new List<Routine>(), (result, next) => { result.AddRange(next); return result; });
				routines[State.Mounted] = Window.MountedRoutines.Values.Aggregate(new List<Routine>(), (result, next) => { result.AddRange(next); return result; });
				return routines;
			}
		}

		LocalPlayer Me { get { return ObjectManager.Me; } }

		State CurrentState
		{
			get
			{
				if (Me.Combat)
					return State.Combat;
				else if (Me.Mounted)
					return State.Mounted;
				else
					return State.Walking;
			}
		}

		//public Jumpy()
		//{
		//    Application.EnableVisualStyles();
		//    Styx.BotEvents.OnBotStopped += new BotEvents.OnBotStopDelegate(OnBotStopped);
		//}

		void OnBotStopped(EventArgs args)
		{
			WorkerThread.Abort();
		}



		public override void Pulse()
		{
			if (WorkerThread == null || !WorkerThread.IsAlive)
			{
				WorkerThread = new Thread(new ThreadStart(Loop));
				WorkerThread.IsBackground = true;
				WorkerThread.Start();
			}
		}

		bool SafeToJump
		{
			get
			{
				try { return !Styx.Logic.BehaviorTree.TreeRoot.StatusText.Contains("Looting") && !Styx.Logic.BehaviorTree.TreeRoot.StatusText.Contains("Resting") && !Me.IsCasting && (Me.IsMoving || Window.StandJumpInCombat && CurrentState == State.Combat || Window.StandJumpOutCombat && CurrentState != State.Combat) && (!Window.UsePlayerRange || ObjectManager.GetObjectsOfType<WoWPlayer>().Any(player => player.Distance <= Window.PlayerRange)); }
				catch { return false; }
			}
		}

		Stopwatch sw = new Stopwatch();
		void WaitNextJump()
		{
			if (CurrentState == State.Combat || CurrentState == State.Walking)
				Thread.Sleep(Window.BaseWalkJumpSpan + rand.Next(Window.RandWalkJumpSpan));
			else
				Thread.Sleep(Window.BaseMountJumpSpan + rand.Next(Window.RandMountJumpSpan));
		}

		void Loop()
		{
			var combat = Routines[State.Combat];
			var mounted = Routines[State.Mounted];
			var walking = Routines[State.Walking];
			var all = combat.Union(mounted).Union(walking).ToList();

			while (true)
			{
				try
				{

					if (!SafeToJump)
					{
						//Settings.Log("Reason: " + (!Me.IsAlive ? "Died" : Me.IsCasting ? "Casting" : Me.Looting ? "Looting" : !Me.IsMoving ? "Motionless" : "None") + "\r\n");
						all.PauseAll();
						Thread.Sleep(50);
						continue;
					}

					WaitNextJump();
					if (!SafeToJump)
						continue;

					if (CurrentState == State.Combat)
					{
						all.Except(combat).ToList().PauseAll();
						combat.ResumeAll();
						Routine routine = Routines[State.Combat].ManageRoutine();
						if (routine == null)
							continue; // Didn't find suitable routine.
						routine.Do();
					}

					else if (CurrentState == State.Mounted)
					{
						all.Except(mounted).ToList().PauseAll();
						mounted.ResumeAll();
						Routine routine = Routines[State.Mounted].ManageRoutine();
						if (routine == null)
							continue; // Didn't find suitable routine.
						routine.Do();
					}

					else if (CurrentState == State.Walking)
					{
						all.Except(walking).ToList().PauseAll();
						walking.ResumeAll();
						Routine routine = Routines[State.Walking].ManageRoutine();
						if (routine == null)
							continue; // Didn't find suitable routine.
						routine.Do();
					}
				}
				catch { }
			}

		}

	}

		



}
