namespace RegisterToDoctor.WebSell.Interfaces
{
    public interface ICreateDoctor
    {
        Guid Id { get; }

        string FirstName { get; }

        string LastName { get; }

        string? MiddleName { get; }

        Guid OfficeId { get; }

        Guid SpecializationId { get; }

        Guid PlotId { get; }

        DateTime? UpdatedAt { get; }
    }
}
