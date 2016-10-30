namespace Point3DStructure
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void ExportPath(Path pathToExport, string filePath, string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath + "\\" + fileName);
                using (writer)
                {
                    for (int i = 0; i < pathToExport.PointsCount; i++)
                    {
                        writer.WriteLine(pathToExport[i]);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Export location not accessible!");
            }
        }

        public static Path ImportPath(string fullFilePath)
        {
            try
            {
                Path tempPath = new Path();
                StreamReader reader = new StreamReader(fullFilePath);
                using (reader)
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] coords = line.Split(new char[] { ',', ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        tempPath.AddPointToPath(
                            new Point3D(
                                double.Parse(coords[0]),
                                double.Parse(coords[1]),
                                double.Parse(coords[2])));
                    }
                }

                return tempPath;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File missing!");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Directory missing!");
            }
            catch (UnauthorizedAccessException)
            {
                throw new FileNotFoundException("File access denied!");
            }
        }
    }
}
