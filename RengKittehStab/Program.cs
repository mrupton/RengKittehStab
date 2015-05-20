#region

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

#endregion

 namespace RustysKitteh
 {
     internal class Rengar
     { 
    private static Obj_AI_Hero Player { get { return ObjectManager.Player; } }
    private static Orbwalking.Orbwalker Orbwalker;
    private static Spell Q, W, E, R;
    private static Menu Menu;
    private static Menu Config;
    private static int _leapRange = 775;
   

    static void Main(string[] args)
   {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

    private static void Game_OnGameLoad(EventArgs args)
    {
    
        if (ObjectManager.Player.BaseSkinName != "Rengar")
       
            return;
        
        Q = new Spell(SpellSlot.Q, 0); 
        W = new Spell(SpellSlot.W, 500); 
        E = new Spell(SpellSlot.E, 1000);
        Q.SetTargetted(0.5f, 10000);
        W.SetTargetted(0.5f, 10000);
        E.SetSkillshot(0.5f, 70, 1500, true, SkillshotType.SkillshotLine);

  
        Menu = new Menu(Player.ChampionName, Player.ChampionName, true);

    
        Menu orbwalkerMenu = Menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));

  
        Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);

   
        Menu ts = Menu.AddSubMenu(new Menu("Target Selector", "Target Selector")); ;

  
        TargetSelector.AddToMenu(ts);

     
        Config.AddSubMenu(new Menu("Combo", "Combo"));
        {
       
            Config.SubMenu("Combo").AddItem(new MenuItem("UseQ", "Use Q").SetValue(true));
            Config.SubMenu("Combo").AddItem(new MenuItem("UseW", "Use W").SetValue(true));
            Config.SubMenu("Combo").AddItem(new MenuItem("UseE", "Use E").SetValue(true));
            Config.SubMenu("Combo").AddItem(new MenuItem("Q1", "Q if AA Able.").SetValue(true));
            Config.SubMenu("Combo").AddItem(new MenuItem("StackPriority", "5 Stack Priority").SetValue(new StringList(new[]  {"Q", "W", "E"}, 0)));
            Config.SubMenu("Combo").AddItem(new MenuItem("tripleQ", "Triple Q!").SetValue(new KeyBind("M".ToCharArray()[0], KeyBindType.Press)));
            
            }
      
        Game.OnUpdate += Game_OnUpdate;


        Notifications.AddNotification("Welcome to Rengo Kitteh by Chadworth", 5000);
    }

public static void AddItem(MenuItem menuItem)
{
 	throw new NotImplementedException();
}

  
    public static void Game_OnUpdate(EventArgs args)
    {
        
        if (Player.IsDead)
            return;

    
           if (Orbwalker.ActiveMode != Orbwalking.OrbwalkingMode.Combo || Orbwalker.ActiveMode != Orbwalking.OrbwalkingMode.Mixed)
                return;

        }

      
        }
 }

     public void combo(bool is3Q)
    {
            var useQ = Config.Item("UseQCombo").GetValue<bool>();
            var useW = Config.Item("UseWCombo").GetValue<bool>();
            var useE = Config.Item("UseECombo").GetValue<bool>();
            var stackPrior = Config.Item("stackPriority").GetValue<StringList>().SelectedIndex;
            var eTarget = TargetSelector.GetTarget(E.Range, TargetSelector.DamageType.Physical);
            var aaTarget = TargetSelector.GetTarget(Orbwalking.GetRealAutoAttackRange(Player) + 175, TargetSelector.DamageType.Phy

    if (eTarget != null)
            {
                if (is3Q)
                {
                    Player.IssueOrder(GameObjectOrder.AttackUnit, aaTarget);
                }
 if (smartMode && Player.Mana == 5 && !is3Q)
                {
                    if (smartW && Player.Health / Player.MaxHealth * 100 < smartHP)
                    {
                        W.CastOnUnit(Player, pCast);;
                    }
                    else if (smartQ && Player.Distance(eTarget) <= 300)
                    {
                        Q.CastOnUnit(Player, pCast);;
                    }
                    else if (smartE && Player.Distance(eTarget) > Orbwalking.GetRealAutoAttackRange(Player))
                    {
                        E.Cast(eTarget, true);
                    }
                }
                var useQ = Config.Item("UseQCombo").GetValue<bool>();
                if (Q.IsReady())
                {
                    if (eTarget.IsValidTarget(Orbwalking.GetRealAutoAttackRange(Player)))
                    {
                        if (Q.IsReady() && Player.Mana < 5 && useQ || Q.IsReady() && stackPrior == 0 && useQ && !smartMode || Q.IsReady() && is3Q)
                        {
                            Q.CastOnUnit(Player, pCast);;
                        }
                    }
                }
                if (E.IsReady())
                {
                    if (eTarget.IsValidTarget(E.Range) && E.IsReady() && useE && Player.Mana < 5 || eTarget.IsValidTarget(E.Range) && E.IsReady() && useE && stackPrior == 2 && !smartMode && !is3Q)
                    {
                        E.Cast(eTarget, true);
                    }
                }
                if (W.IsReady())
                {
                    if (eTarget.IsValidTarget(W.Range) && W.IsReady() && useW && Player.Mana < 5 || Player.Distance(eTarget) < W.Range && W.IsReady() && useW && stackPrior == 1 && !smartMode && !is3Q)
                    {
                        W.CastOnUnit(Player, pCast);
                    }
                }
            }

        }