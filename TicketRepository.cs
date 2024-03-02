// Repositories/TicketRepository.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static TicketsController;

public class TicketRepository : ITicketRepository
{
    private readonly EventTicketAPI.Core.ApplicationDbContext _context;

    public TicketRepository(EventTicketAPI.Core.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Ticket> GetTicketByIdAsync(int ticketId)
    {
        return await _context.Tickets.FindAsync(ticketId);
    }

    public async Task AddTicketAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsTicketConsumedAsync(int ticketId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        return ticket?.IsUsed ?? false;
    }

    public async Task ConsumeTicketAsync(int ticketId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket != null)
        {
            ticket.IsUsed = true;
            await _context.SaveChangesAsync();
        }
    }
}