using Exceptions;

namespace Domain
{
    public class Order : BaseEntity
    {
        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new ScenarioException("Order Id cannot be empty.");
        }
    }
}
