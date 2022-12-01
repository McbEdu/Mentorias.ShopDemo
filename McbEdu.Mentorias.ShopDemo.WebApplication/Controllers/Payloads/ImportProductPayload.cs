namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

public class ImportProductPayload
{
    public string Code { get; set; }
    public string Description { get; set; }

    public ImportProductPayload()
    {
        Code = Description = string.Empty;
    }
}
