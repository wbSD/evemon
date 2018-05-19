using System;
using System.Collections.Generic;
using System.Linq;
using EVEMon.Common.Constants;
using EVEMon.Common.Extensions;
using EVEMon.Common.Models.Extended;

namespace EVEMon.Common.Models
{
    /// <summary>
    /// Serializable class for an ESI method and its path. Each APIConfiguration maintains a list of APIMethodsEnum.
    /// </summary>
    public class ESIMethod
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="path"></param>
        private ESIMethod(Enum method, string path, string scope)
        {
            Method = method;
            Path = path;
            Scope = scope;
        }

        /// <summary>
        /// Returns the APIMethodsEnum enumeration member for this ESIMethod.
        /// </summary>
        public Enum Method { get; }

        /// <summary>
        /// Returns the defined URL suffix path for this ESIMethod.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Returns the required scope for this ESIMethod, if any.
        /// </summary>
        public string Scope { get; }

        /// <summary>
        /// Creates a set of ESI methods with their default urls.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ESIMethod> CreateDefaultSet() =>
            ESIMethods.Methods.Where(method => method.ToString() != "None").Select(method =>
                new
                {
                    methodName = method,
                    methodPath = method.GetESIMethodPath(),
                    methodScope = method.GetESIMethodScope()
                }).Where(method => method.methodPath != null)
                .Select(method => new ESIMethod(method.methodName, method.methodPath, method.methodScope));
    }
}
