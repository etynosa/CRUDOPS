namespace CRUDOPS.Interfaces.Data
{
    public interface IEntityCreateTrackable
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
    }
}
