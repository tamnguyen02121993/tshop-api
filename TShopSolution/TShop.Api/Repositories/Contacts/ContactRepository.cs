using Microsoft.EntityFrameworkCore;
using TShop.Api.EF;
using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly TShopDbContext _context;
    public ContactRepository(TShopDbContext context)
    {
        _context = context;
    }
    public async Task<Contact> CreateContact(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task DeleteContact(Contact contact)
    {
        _context.Remove(contact);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Contact> GetAllContacts()
    {
        return _context.Contacts.AsNoTracking();
    }

    public async Task<Pagination<Contact>> GetAllContacts(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Contacts.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Email.ToLower().Contains(search.ToLower()));
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Contacts.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Contact>
        {
            Data = data,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalRows = totalRows,
            TotalPages = totalPages,
            HasNext = pageIndex + 1 < totalPages,
            HasPrevious = pageIndex > 0
        };
    }

    public IQueryable<Contact> GetAvailableContacts()
    {
        return _context.Contacts.Where(x => x.Status != ContactStatus.RESOLVED).AsNoTracking();
    }

    public async Task<Pagination<Contact>> GetAvailableContacts(int pageIndex, int pageSize, string? search)
    {
        var query = _context.Contacts.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x => x.Status != ContactStatus.RESOLVED && x.Email.ToLower().Contains(search.ToLower()));
        }
        else
        {
            query = query.Where(x => x.Status != ContactStatus.RESOLVED);
        }

        var data = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        var totalRows = await _context.Contacts.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);

        return new Pagination<Contact>
        {
            Data = data,
            PageIndex = pageIndex,
            PageSize = pageSize,
            TotalRows = totalRows,
            TotalPages = totalPages,
            HasNext = pageIndex + 1 < totalPages,
            HasPrevious = pageIndex > 0
        };
    }

    public async Task<Contact?> GetContactById(Guid id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<Contact> UpdateContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
        return contact;
    }
}