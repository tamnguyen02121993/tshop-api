using TShop.Api.Models;

namespace TShop.Api.Repositories.Contacts;

public interface IContactRepository
{
    Task<Contact> CreateContact(Contact contact);
    Task<Contact> UpdateContact(Contact contact);
    Task DeleteContact(Contact contact);

    Task<Contact?> GetContactById(Guid id);
    IQueryable<Contact> GetAllContacts();
    IQueryable<Contact> GetAvailableContacts();
}