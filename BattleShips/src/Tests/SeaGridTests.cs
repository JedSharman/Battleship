using NUnit.Framework;
using System;

namespace Application
{
	[TestFixture ()]
	public class SeaGridTests
	{
		[TestFixtureSetUp()]
		public void init(){
			SeaGrid testGrid = new SeaGrid (new System.Collections.Generic.Dictionary<ShipName, Ship>{});
		}

		[Test ()]
		public void TestHitEmptyTile ()
		{
			//Arrange
			SeaGrid testGrid = new SeaGrid (new System.Collections.Generic.Dictionary<ShipName, Ship>{});
			AttackResult expected = new AttackResult (ResultOfAttack.Miss, "missed", 0, 0);
			//Act
			AttackResult Actual = testGrid.HitTile (0, 0);
			//Result
			Assert.AreEqual (expected.Text, Actual.Text);
		}

		[Test()]
		public void TestHitHitTile(){
			//Arrange
			SeaGrid testGrid = new SeaGrid (new System.Collections.Generic.Dictionary<ShipName, Ship>{});
			testGrid.HitTile (0, 0);
			AttackResult expected = new AttackResult (ResultOfAttack.ShotAlready, "have already attacked [0,0]!", 0, 0);
			//Act
			AttackResult Actual = testGrid.HitTile (0, 0);
			//Result
			Assert.AreEqual (expected.Text, Actual.Text);
		}

		[Test()]
		public void TestHitShipTile(){
			//Arrange
			SeaGrid testGrid = new SeaGrid (new System.Collections.Generic.Dictionary<ShipName, Ship>{});
			testGrid.AddShip (1, 1, Direction.UpDown, new Ship (ShipName.Submarine));
			AttackResult expected = new AttackResult (ResultOfAttack.Hit, "hit something!", 1, 1);
			//Act
			AttackResult Actual = testGrid.HitTile (1, 1);
			//Result
			Assert.AreEqual (expected.Text, Actual.Text);
		}

		[Test()]
		public void TestHitShipAndSinkTile(){
			//Arrange
			SeaGrid testGrid = new SeaGrid (new System.Collections.Generic.Dictionary<ShipName, Ship>{});
			testGrid.AddShip (1, 1, Direction.UpDown, new Ship (ShipName.Tug));
			AttackResult expected = new AttackResult (ResultOfAttack.Destroyed, new Ship(ShipName.Tug), "destroyed the enemy's", 1, 1);
			//Act
			AttackResult Actual = testGrid.HitTile (1, 1);
			//Result
			Assert.AreEqual (expected.Text, Actual.Text);
		}
	}
}

