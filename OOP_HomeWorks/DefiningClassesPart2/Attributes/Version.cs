namespace Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class Version : Attribute
    {
        public Version(string version = "1.0")
        {
            var splittedVersion = version.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            this.MajorVersion = int.Parse(splittedVersion[0]);
            this.MinorVersion = int.Parse(splittedVersion[1]);
        }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }
    }
}
