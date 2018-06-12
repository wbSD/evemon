using System;

namespace EVEMon.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ESIMethodAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ESIMethodAttribute"/> class.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="scope"></param>
        public ESIMethodAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public string Scope { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }
    }
}
