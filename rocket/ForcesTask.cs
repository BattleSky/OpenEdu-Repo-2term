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
               // var rocket = r.Location;
                var forceVector = new Vector(forceValue, 0);
				return forceVector.Rotate(r.Direction);
            };
        }

		/// <summary>
		/// Преобразует делегат силы гравитации, в делегат силы, действующей на ракету
		/// </summary>
		public static RocketForce ConvertGravityToForce(Gravity gravity, Size spaceSize)
        {
            return r => gravity(spaceSize, r.Location);
        }

		/// <summary>
		/// Суммирует все переданные силы, действующие на ракету, и возвращает суммарную силу.
		/// </summary>
		public static RocketForce Sum(params RocketForce[] forces)
        {
            return rocket => forces.Select(force => force(rocket))
                             .DefaultIfEmpty(Vector.Zero)
                             .Aggregate((vector1, vector2) => vector1 + vector2); 

            /*
            * Представляется результат агрегации суммирования векторов каждого выбранного
             * делегата внутри массива forces
            * В качестве условия агрегации используется выражение (x,y)=> x + y,
            * то есть вначале к первому элементу прибавляется второй,
            * потом к получившемуся значению добавляется третий и так далее.
            */
        }
    }
}