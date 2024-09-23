namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface ICreateDoctor
    {
        Guid Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string? MiddleName { get; set; }

        Guid OfficeId { get; set; }

        Guid SpecializationId { get; set; }

        Guid PlotId { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}
