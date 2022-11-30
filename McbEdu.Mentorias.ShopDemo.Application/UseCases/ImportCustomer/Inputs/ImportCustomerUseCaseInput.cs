namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportCustomer.Inputs;

public class ImportCustomerUseCaseInput
{
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }

	private DateTime birthDate;

	public DateTime BirthDate
	{
		get { return birthDate; }
		set { birthDate = DateTime.SpecifyKind(value, DateTimeKind.Utc); }
	}

	public ImportCustomerUseCaseInput(string name, string surname, string email, DateTime birthDate)
	{
		Name = name;
		Surname = surname;
		Email = email;
		BirthDate = birthDate;
	}

}
