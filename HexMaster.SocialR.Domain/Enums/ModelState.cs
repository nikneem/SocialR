namespace HexMaster.SocialR.Domain.Enums
{
    public enum ModelState: byte
    {
        Pristine = 0,
        Created = 1,
        Modified = 2,
        Deleted = 3,
        Touched = 4
    }
}