using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace func_rocket
{
    public class LevelsTask
    {
        static readonly Physics standardPhysics = new Physics();

        public class RocketAndTarget
        {
            public RocketAndTarget()
            {
                Rocket = new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI);
                Target = new Vector(600, 200);
            }
            public Rocket Rocket { get; set; }
            public Vector Target { get; set; }

            public RocketAndTarget GenerateRocketAndTarget(int rocketX = 200, int rocketY = 500, Vector rocketVelocity = null,
                double rocketDirection = -0.5 * Math.PI, int targetX = 600, int targetY = 200)
            {
                if (rocketVelocity == null)
                    rocketVelocity = Vector.Zero;
                var pair = new RocketAndTarget() { Rocket = new Rocket(new Vector(rocketX, rocketY), rocketVelocity, rocketDirection),
                    Target = new Vector(targetX, targetY) };
                return pair;

                // TODO: ���������� �������������� �������:
                /*
                 * ���������� �� ���������� ��������� ������ �� ���� ������ ���� � �������� �� 450 �� 550.
                 * ���� ����� ������������ �� ���� � ��������� ������������ ������ ������ ���� �� ����� PI/4.
                 */
            }
        }


        public static IEnumerable<Level> CreateLevels()
        {
            var levels = new List<Level>()
            {
                new Level("Zero", new RocketAndTarget().Rocket, new RocketAndTarget().Target,
                    (size, v) => Vector.Zero, standardPhysics),
                new Level("Heavy", new RocketAndTarget().Rocket, new RocketAndTarget().Target,
                    (size, v) => new Vector(0, 0.9), standardPhysics),
                new Level("Up", new RocketAndTarget().Rocket, new RocketAndTarget().GenerateRocketAndTarget(targetX: 700, targetY: 500).Target,
                    ((size, v) => new Vector(0, 300 / ( + 300.0)), standardPhysics)
                    )
            };

            foreach (var lvl in levels)
            {
                yield return lvl;
            }
        }
    }
}



//public static Rocket GenerateRocket(int x = 200, int y = 500, Vector velocity = null,
//    double direction = -0.5 * Math.PI)
//{
//    if (velocity == null)
//        velocity = Vector.Zero;
//    return new Rocket(new Vector(x, y), velocity, direction);
//}

//public static Vector GenerateTarget(int x = 600, int y = 200)
//{
//    return new Vector(x, y);
//}