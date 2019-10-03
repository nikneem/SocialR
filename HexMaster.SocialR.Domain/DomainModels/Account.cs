using System;
using HexMaster.SocialR.Domain.Base;
using HexMaster.SocialR.Domain.Enums;

namespace HexMaster.SocialR.Domain.DomainModels
{
    public sealed class Account : DomainModelBase<Guid>
    {

        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public DateTimeOffset ModifiedOn { get; private set; }

        public void SetName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value), "The name of an account cannot be null or empty");
            }
            SetModelState(ModelState.Touched);
            if (!Equals(value, Name))
            {
                Name = value;
                SetModelState(ModelState.Modified);
            }
        }
        public void Delete()
        {
            if (!Equals(IsDeleted, true))
            {
                IsDeleted = true;
                SetModelState(ModelState.Modified);
            }
        }

        public Account() : base(Guid.NewGuid(), ModelState.Created)
        {
            CreatedOn = DateTimeOffset.UtcNow;
        }

    }
}
