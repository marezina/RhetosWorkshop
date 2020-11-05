using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using Rhetos.Utilities;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;

namespace Bookstore.Concepts
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("CodeTable")]
    public class CodeTableInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }
    }

    [Export(typeof(IConceptMacro))]
    public class CodeTableMacro : IConceptMacro<CodeTableInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(CodeTableInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            var codePropertyInfo = new ShortStringPropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "Code"
            };

            var autocode = new AutoCodePropertyInfo { Property = codePropertyInfo };

            var namePropertyInfo = new ShortStringPropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "Name"
            };

            var systemRequired = new SystemRequiredInfo { Property = namePropertyInfo };

            newConcepts.Add(codePropertyInfo);
            newConcepts.Add(autocode);
            newConcepts.Add(namePropertyInfo);
            newConcepts.Add(systemRequired);

            return newConcepts;
        }
    }
}
