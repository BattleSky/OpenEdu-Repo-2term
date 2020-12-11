using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
                /*
                 * Здесь можно отработать условия:
                 * Расстояние от начального положения ракеты до цели должно быть в пределах от 450 до 550.
                 * Угол между направлением на цель и начальным направлением ракеты должен быть не менее PI/4.
                 *
                 * Но это не потребовалось...
                 */
            }
        }


        public static IEnumerable<Level> CreateLevels()
        {
            var rocketAndTarget = new RocketAndTarget();
            var blackhole = (rocketAndTarget.Target + rocketAndTarget.Rocket.Location) * 0.5;

            var levels = new List<Level>()
            {
                new Level("Zero", rocketAndTarget.Rocket, rocketAndTarget.Target,
                    (size, v) => Vector.Zero, standardPhysics),
                new Level("Heavy", rocketAndTarget.Rocket, rocketAndTarget.Target,
                    (size, v) => new Vector(0, 0.9), standardPhysics),
                new Level("Up", rocketAndTarget.Rocket, rocketAndTarget.GenerateRocketAndTarget(targetX: 700, targetY: 500).Target,
                    (size, v) => new Vector(0,  -300 / (size.Height - v.Y + 300.0)), standardPhysics),
                new Level("WhiteHole", rocketAndTarget.Rocket, rocketAndTarget.Target,
                    (size, v) =>
                    {
                        var direction = rocketAndTarget.Target - v;
                        var d = direction.Length;
                        return direction.Normalize() * -140 * d / (d * d + 1);
                    }, standardPhysics),
                new Level("BlackHole", rocketAndTarget.Rocket, rocketAndTarget.Target, (size, v) =>
                    {
                        var direction = blackhole - v;
                        var d = direction.Length;
                        return direction.Normalize() * 300 * d / (d * d + 1);
                    }, standardPhysics),
                new Level("BlackAndWhite", rocketAndTarget.Rocket, rocketAndTarget.Target, (size, v) =>
                {
                    var blackholeD = (blackhole - v).Length;
                    var whiteholeD = (rocketAndTarget.Target - v).Length;
                    var blackGrav = (blackhole - v).Normalize() * 300 * blackholeD / (blackholeD * blackholeD + 1);
                    var whiteGrav = (rocketAndTarget.Target - v).Normalize() * -140 * whiteholeD /
                                    (whiteholeD * whiteholeD + 1);
                    return (blackGrav + whiteGrav) / 2;
                }, standardPhysics)
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