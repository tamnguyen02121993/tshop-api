using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Repositories.Contacts;

public interface IContactRepository
{
    Task<Contact> CreateContact(Contact contact);
    Task<Contact> UpdateContact(Contact contact);
    Task DeleteContact(Contact contact);

    Task<Contact?> GetContactById(Guid id);
    IQueryable<Contact> GetAllContacts();
    Task<Pagination<Contact>> GetAllContacts(int pageIndex, int pageSize, string? search);
    IQueryable<Contact> GetAvailableContacts();
    Task<Pagination<Contact>> GetAvailableContacts(int pageIndex, int pageSize, string? search);
}