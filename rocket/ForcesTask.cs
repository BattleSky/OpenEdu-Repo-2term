using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace func_rocket
{
	public class ForcesTask
	{
		/// <summary>
		/// Создает делегат, возвращающий по ракете вектор силы тяги двигателей этой ракеты.
		/// Сила тяги направлена вдоль ракеты и равна по модулю forceValue.
		/// </summary>
		public static RocketForce GetThrustForce(double forceValue)
		{
			return r =>
            {
                var rocket = new Vector(r.Location.X, r.Location.Y);
                //var rocket = new Vector(1, 1);
				return rocket.Rotate(r.Direction) * forceValue;
            };
        }

		/// <summary>
		/// Преобразует делегат силы гравитации, в делегат силы, действующей на ракету
		/// </summary>
		public static RocketForce ConvertGravityToForce(Gravity gravity, Size spaceSize)
        {
            return r => gravity(spaceSize, new Vector(r.Location.X, r.Location.Y));
        }

		/// <summary>
		/// Суммирует все переданные силы, действующие на ракету, и возвращает суммарную силу.
		/// </summary>
		public static RocketForce Sum(params RocketForce[] forces)
		{
			return force =>
            {
                /*
                 * Переменная sum будет представлять результат агрегации массива.
                 * В качестве условия агрегации используется выражение (x,y)=> x + y,
                 * то есть вначале к первому элементу прибавляется второй,
                 * потом к получившемуся значению добавляется третий и так далее.
                 */
				var sum = forces.Aggregate((x, y) => x + y);
                return sum(force);
            };
            
        }
	}
}