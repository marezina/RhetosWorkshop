using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Bookstore.Concepts
{
    /// <summary>
    /// Automatically enters modified time when the records was updated.
    /// </summary>
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("LastModifiedTime")]
    public class LastModifiedTimeInfo : IConceptInfo
    {
        [ConceptKey]
        public DateTimePropertyInfo Property { get; set; }
    }
}