using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroFight;

namespace HERO_FIGHTS_TEST
{
    [TestClass]
    public class BattleTest
    {
        [TestMethod]
        public void TestTie()
        {
            var player = new BaseFactory<Orcs>().CreateArcher("Name");
            var battle = new Battle(player);
            battle.Player.HP = 0;
            battle.Enemy.HP = 0;
            battle.BeginBattle();
            battle.isEnded();
            Assert.AreEqual(true, battle.isTie);
        }
        [TestMethod]
        public void TestLose()
        {
            var player = new BaseFactory<Orcs>().CreateArcher("Name");
            var battle = new Battle(player);
            battle.Player.HP = 0;
            battle.Enemy.HP = 100;
            battle.BeginBattle();
            battle.isEnded();
            Assert.AreEqual(true, battle.isLose);
        }
        [TestMethod]
        public void TestWin()
        {
            var player = new BaseFactory<Orcs>().CreateArcher("Name");
            var battle = new Battle(player);
            battle.Player.HP = 100;
            battle.Enemy.HP = 0;
            battle.BeginBattle();
            battle.isEnded();
            Assert.AreEqual(true, battle.isWin);
        }
        [TestMethod]
        public void TestAttack()
        {
            var player = new BaseFactory<Orcs>().CreateWarrior("Name");
            var battle = new Battle(player);

            battle.Enemy.HP = 100;

            battle.BeginBattle();

            battle.Player.Attack(battle.Enemy, false);

            Assert.AreEqual(100, battle.Enemy.HP);
        }
        [TestMethod]
        public void TestMove()
        {
            var player = new BaseFactory<Humans>().CreateWarrior("Name");
            var battle = new Battle(player);

            battle.Player.X = 15;
            battle.Player.Move("Left");

            Assert.AreEqual(3, battle.Player.X);
        }
    }
}
