using Data.Interfaces;

namespace Data.Models
{
    public abstract class BaseModel : IEduLinkModel
    {
        public long Id { get; set; }
    }
}
