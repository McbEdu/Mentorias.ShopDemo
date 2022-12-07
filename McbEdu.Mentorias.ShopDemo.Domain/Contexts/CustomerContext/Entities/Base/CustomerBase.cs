using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ENUMs;
using McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.ValueObjects;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace McbEdu.Mentorias.ShopDemo.Domain.Contexts.CustomerContext.Entities.Base;

public abstract class CustomerBase
{
    public Guid Identifier { get; init; }
    public Name Name { get; private set; }
    public Surname Surname { get; private set; }
    public Email Email { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public TypeCustomer TypeCustomer { get; init; }

    protected CustomerBase(Guid identifier, Name name, Surname surname, Email email, BirthDate birthDate, TypeCustomer typeCustomer)
    {
        Identifier = identifier;
        Name = name;
        Surname = surname;
        Email = email;
        BirthDate = birthDate;
        TypeCustomer = typeCustomer;
    }

    protected void ChangeName(Name name)
    {
        Name = name;
    }

    protected void ChangeSurname(Surname surname)
    {
        Surname = surname;
    }

    protected void ChangeEmail(Email email)
    {
        Email = email;
    }

    protected void ChangeBirthDate(BirthDate birthDate)
    {
        BirthDate = birthDate;
    }

    public override bool Equals(object? obj)
    {
        var compareTo = obj as CustomerBase;

        if (ReferenceEquals(this, compareTo)) return true;
        if  (ReferenceEquals(null, compareTo)) return false;

        return Identifier.Equals(compareTo.Identifier);
    }

    public static bool operator ==(CustomerBase customerBase, CustomerBase customerBaseComparer)
    {
        if (ReferenceEquals(customerBase, null) || ReferenceEquals(customerBaseComparer, null)) return false;

        if (ReferenceEquals(customerBase, null) && ReferenceEquals(customerBaseComparer, null)) return true;

        return true;
    }

    public static bool operator !=(CustomerBase customerBase, CustomerBase customerBaseComparer)
    {
        return !(customerBase == customerBaseComparer);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
