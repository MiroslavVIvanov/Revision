namespace Point3DStructure
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Point3D firstPoint = new Point3D(7d, 4d, 3d);
            Point3D secondPoint = new Point3D(17d, 6d, 2d);

            Path p = new Path();
            p.AddPointToPath(firstPoint);
            p.AddPointToPath(secondPoint);

            Console.WriteLine(p.ToString());

            PathStorage.ExportPath(p, "D:\\", "exported.txt");
            Path importedPath = PathStorage.ImportPath("D:\\fileToImport.txt");

            Console.WriteLine(importedPath.ToString());
        }
    }
}
