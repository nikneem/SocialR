using HexMaster.SocialR.Domain.Enums;

namespace HexMaster.SocialR.Domain.Base
{
    public abstract class DomainModelBase<T>
    {

        public  T Id { get; }
        public ModelState ModelState { get; private set; }

        protected void SetModelState(ModelState state)
        {
            switch (state)
            {
                case ModelState.Deleted:
                    if (ModelState == ModelState.Modified
                        || ModelState == ModelState.Pristine
                        || ModelState == ModelState.Touched)
                    {
                        ModelState = state;
                    }
                    break;
                case ModelState.Modified:
                    if (ModelState == ModelState.Pristine
                        || ModelState == ModelState.Touched)
                    {
                        ModelState = state;
                    }
                    break;
                case ModelState.Touched:
                    if (ModelState == ModelState.Pristine)
                    {
                        ModelState = state;
                    }
                    break;
            }
        }

        protected DomainModelBase(T id, ModelState state = ModelState.Pristine)
        {
            Id = id;
            ModelState = state;
        }

    }

    
}
