// TicketsController.cs
using EventTicketAPI.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TicketsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("purchase/{productId}")]
    public async Task<ActionResult<Ticket>> PurchaseTicket(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            return NotFound();
        }

        var ticket = new Ticket
        {
            QRCode = GenerateQRCode(productId),
            IsUsed = false,
            ProductId = productId
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
    }

    private object GetTicket()

    {
        throw new NotImplementedException();
    }

    private string GenerateQRCode(int productId)
    {
        // Generate QR Code logic using QRCoder library
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode($"ProductId:{productId};DateTime:{DateTime.Now}", QRCodeGenerator.ECCLevel.Q);
        var qrCode = new QRCode(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);

        using (var stream = new MemoryStream())
        {
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(stream.ToArray());
        }
    }

    [HttpPost("consume/{ticketId}")]
    public async Task<IActionResult> ConsumeTicket(int ticketId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket == null)
        {
            return NotFound();
        }

        if (ticket.IsUsed)
        {
            return BadRequest("Ticket already consumed.");
        }

        ticket.IsUsed = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    public class Ticket
    {
        public string QRCode { get; internal set; }
        public bool IsUsed { get; internal set; }
        public int ProductId { get; internal set; }
        public object Id { get; internal set; }
    }

    // Other ticket-related endpoints
}

public class QRCode
{
    private QRCodeData qrCodeData;

    public QRCode(QRCodeData qrCodeData)
    {
        this.qrCodeData=qrCodeData;
    }

    internal object GetGraphic(int v)
    {
        throw new NotImplementedException();
    }
}
