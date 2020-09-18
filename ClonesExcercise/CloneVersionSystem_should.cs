using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Clones
{
	[TestFixture]
	public class CloneVersionSystem_should
	{
		[Test]
		public void Learn()
		{
			var clone1 = Execute("learn 1 45", "check 1").Single();
			Assert.AreEqual("45", clone1);
		}

		[Test]
		public void RollbackToBasic()
		{
			var clone1 = Execute("learn 1 45", "rollback 1", "check 1").Single();
			Assert.AreEqual("basic", clone1);
		}

		[Test]
		public void RollbackToPreviousProgram()
		{
			var clone1 = Execute("learn 1 45", "learn 1 100500", "rollback 1", "check 1").Single();
			Assert.AreEqual("45", clone1);
		}

        [Test]
        public void RelearnAfterDoubleRollbacksAtSecondClone()
        {
            var clone1 = Execute("learn 1 10", "learn 1 20 ", "learn 1 30", "clone 1", "rollback 2", "rollback 2", "relearn 2", "check 2").Single();
			Assert.AreEqual("20", clone1);
        }

        [Test]
		public void RelearnAfterRollback()
		{
			var clone1 = Execute("learn 1 45", "rollback 1", "relearn 1", "check 1").Single();
			Assert.AreEqual("45", clone1);
		}

        [Test]
		public void CloneBasic()
		{
			var clone2 = Execute("clone 1", "check 2").Single();
			Assert.AreEqual("basic", clone2);
		}

		[Test]
		public void CloneLearned()
		{
			var clone2 = Execute("learn 1 42", "clone 1", "check 2").Single();
			Assert.AreEqual("42", clone2);
		}

		[Test]
		public void LearnClone_DontChangeOriginal()
		{
			List<string> res = Execute("learn 1 42", "clone 1", "learn 2 100500", "check 1", "check 2");
			Assert.AreEqual(new []{ "42", "100500"}, res);
		}

		[Test]
		public void RollbackClone_DontChangeOriginal()
		{
			var res = Execute("learn 1 42", "clone 1", "rollback 2", "check 1", "check 2");
			Assert.AreEqual(new[] { "42", "basic" }, res);
		}

		[Test]
		public void ExecuteSample()
		{
			var res = Execute("learn 1 5",
				"learn 1 7",
				"rollback 1",
				"check 1",
				"clone 1",
				"relearn 2",
				"check 2",
				"rollback 1",
				"check 1");
			Assert.AreEqual(new[] { "5", "7", "basic" }, res);
		}

        [Test]
        public void ThreeClonesTest()
        {
			var res = Execute("learn 1 10", "clone 1", "learn 2 20", "clone 1", "learn 3 20", "learn 3 30", "rollback 3", "rollback 3", "learn 3 30", "check 1", "check 2", "check 3" );
			Assert.AreEqual(new[] {"10", "20", "30"}, res);
        }
        [Test]
        public void TenClonesTest()
        {
            var res = Execute(
                "learn 1 10", "clone 1", //2
                "learn 2 20", "clone 1", //3
                "learn 3 20", "learn 3 30",
                "rollback 3", "rollback 3",
                "learn 3 30",
                "clone 3", "clone 3", //4,5
                "learn 5 50",
                "rollback 5", "relearn 5",
                "clone 5", "clone 5", // 6,7
                "learn 5 60", "clone 5", //8
                "rollback 8", "learn 6 60", "learn 7 70", "learn 8 80",
                "clone 8", "clone 8", "rollback 10", "rollback 9", "relearn 10",// 9,10
                "check 1", "check 2", "check 3", "check 4", "check 5", "check 6", "check 7", "check 8", "check 9", "check 10"); 
            Assert.AreEqual(new[] { "10", "20", "30", "30", "60", "60", "70", "80", "50", "80"}, res);
        }//									1	  2     3     4     5	  6	    7      8     9     10

        [Test]
        public void RollbackTest()
        {
            var res = Execute("learn 1 10", "clone 1", "rollback 2");
            Assert.AreEqual("" , res);
        }

        [Test]
        public void LearnStackTest()
        {
            var res = Execute("learn 1 10", "learn 1 20", "learn 1 30", "clone 1", "clone 2",
                "rollback 1", "rollback 2", "rollback 2", "rollback 3", "rollback 3", "rollback 3", "check 1", "check 2", "check 3");
				Assert.AreEqual(new[] {"20", "10", "basic"}, res);
        }

        [Test]
        public void LearnTwiceRollbackTwice()
        {
            var res = Execute("learn 1 45", "learn 1 45", "check 1", "rollback 1", "rollback 1", "check 1");
			Assert.AreEqual(new[]{"45", "basic"}, res);
        }

		private List<string> Execute(params string[] queries)
		{
			var cvs = Factory.CreateCVS();
			var results = new List<string>();
			foreach (var command in queries)
			{
				var result = cvs.Execute(command);
				if (result != null) results.Add(result);
			}
			return results;
		}
	}
}