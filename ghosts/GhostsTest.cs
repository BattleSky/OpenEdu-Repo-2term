using System.Collections.Generic;
using NUnit.Framework;

namespace hashes
{
	[TestFixture]
	public class GhostsTest
	{
		[Test]
		public void GhostDocument()
		{
			TestGhost<Document, GhostsTask>();
		}

		[Test]
		public void GhostVector()
		{
			TestGhost<Vector, GhostsTask>();
		}

		[Test]
		public void GhostSegment()
		{
			TestGhost<Segment, GhostsTask>();
		}

		[Test]
		public void GhostCat()
		{
			TestGhost<Cat, GhostsTask>();
		}

		[Test]
		public void GhostRobot()
		{
			TestGhost<Robot, GhostsTask>();
		}
        [Test]
        public void GhostRobot2()
        {
            TestGhost<Robot, GhostsTask>();
        }

        [Test]
        public void GhostRobotFiveInARow()
        {
            TestGhost<Robot, GhostsTask>();
            TestGhost<Robot, GhostsTask>();
            TestGhost<Robot, GhostsTask>();
            TestGhost<Robot, GhostsTask>();
            TestGhost<Robot, GhostsTask>();
		}

		private void TestGhost<TItem, TGhostsTask>() where TGhostsTask : IMagic, IFactory<TItem>, new()
		{
			TGhostsTask task = new TGhostsTask();
			var ghostItem = task.Create();

			var set = new HashSet<TItem> { ghostItem };
			Assert.IsTrue(set.Contains(task.Create()));
			task.DoMagic();
			Assert.IsFalse(set.Contains(ghostItem), "ghost should disappear from HashSet after DoMagic()");
			set.Add(ghostItem);
			Assert.AreEqual(2, set.Count, "HashSet Add and Count should work incorrectly after DoMagic()");
		}
	}
}