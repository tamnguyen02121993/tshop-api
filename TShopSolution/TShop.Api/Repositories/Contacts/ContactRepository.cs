using TShop.Api.EF;
using TShop.Api.Models;
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
        return _context.Contacts;
    }

    public IQueryable<Contact> GetAvailableContacts()
    {
        return _context.Contacts.Where(x => x.Status != ContactStatus.RESOLVED);
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