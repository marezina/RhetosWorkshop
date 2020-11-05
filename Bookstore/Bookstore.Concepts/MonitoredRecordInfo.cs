using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using Rhetos.Utilities;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;

namespace Bookstore.Concepts
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("MonitoredRecord")]
    public class MonitoredRecordInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }
    }

    [Export(typeof(IConceptMacro))]
    public class MonitoredRecordMacro : IConceptMacro<MonitoredRecordInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(MonitoredRecordInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            var dateTimePropertyInfo = new DateTimePropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "CreatedAt"
            };

            var creationTime = new CreationTimeInfo { Property = dateTimePropertyInfo };
            var denyUserEdit = new DenyUserEditPropertyInfo { Property = dateTimePropertyInfo };

            var entityLogging = new EntityLoggingInfo { Entity = conceptInfo.Entity };

            var logging = new AllPropertiesLoggingInfo 
            {
                EntityLogging = entityLogging
            };

            newConcepts.Add(dateTimePropertyInfo);
            newConcepts.Add(creationTime);
            newConcepts.Add(denyUserEdit);
            newConcepts.Add(entityLogging);
            newConcepts.Add(logging);

            return newConcepts;
        }
    }
}
