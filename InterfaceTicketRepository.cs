// Interfaces/ITicketRepository.cs
using System.Threading.Tasks;
using static TicketsController;

public interface ITicketRepository
{
    Task<Ticket> GetTicketByIdAsync(int ticketId);
    Task AddTicketAsync(Ticket ticket);
    Task<bool> IsTicketConsumedAsync(int ticketId);
    Task ConsumeTicketAsync(int ticketId);
}