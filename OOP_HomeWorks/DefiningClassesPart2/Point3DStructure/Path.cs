// Problem 4. Path
// Create a class Path to hold a sequence of points in the 3D space.
// Create a static class PathStorage with static methods to save and load paths from a text file.
// Use a file format of your choice.

namespace Point3DStructure
{
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        private IList<Point3D> points;

        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public IList<Point3D> Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                this.points = value;
            }
        }

        public int PointsCount
        {
            get
            {
                return this.Points.Count;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                return this.Points[index];
            }
        }

        public void AddPointToPath(Point3D point)
        {
            this.Points.Add(point);
        }

        public void RemovePointFromPath(Point3D point)
        {
            this.Points.Remove(point);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Point3D point in this.Points)
            {
                sb.AppendFormat("{0} ", point.ToString());
            }

            return sb.ToString();
        }
    }
}
