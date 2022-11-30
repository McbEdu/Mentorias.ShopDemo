namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

public class ImportCustomerPayload
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public DateTime birthDate { get; set; }

    public ImportCustomerPayload()
    {
        Name = Surname = Email = string.Empty;
    }
}
