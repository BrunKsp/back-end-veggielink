using data.domain.Collections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace data.domain.Mappings;

public class ProductMapping : DocumentMapping<ProductCollection>
{
  public override void Map(BsonClassMap<ProductCollection> cm)
  {
    cm.MapIdField(x => x.Id)
          .SetIdGenerator(StringObjectIdGenerator.Instance);

    cm.MapField(x => x.Status)
      .SetElementName("status")
      .SetDefaultValue(1);

    cm.MapField(x => x.Name)
      .SetElementName("name");

    cm.MapField(x => x.Description)
      .SetElementName("description");

    cm.MapProperty(x => x.PlantingDate)
        .SetElementName("planting_date");

    cm.MapField(x => x.HarverstDate)
      .SetElementName("harvest_date");
  }
}