using Exceptions;

namespace Domain
{
    public class Patient : BaseEntity
    {
        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new ScenarioException("Id cannot be empty.");
        }
    }
}
