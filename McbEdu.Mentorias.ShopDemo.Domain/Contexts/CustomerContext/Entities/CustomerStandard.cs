using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities;

public class CustomerStandard : CustomerBase
{
    public CustomerStandard(Guid identifier, Name name, Surname surname, Email email, BirthDate birthDate) 
        : base(identifier, name, surname, email, birthDate, TypeCustomer.Standard)
    {
    }
}
