namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

public class ImportOrderPayload
{
    public string Code { get; set; }
    public DateTime OrderTime { get; set; }
    public ImportCustomerPayload Customer { get; set; }
    public List<ImportItemPayload> Items { get; set; }
    
    public ImportOrderPayload()
    {
        Code = string.Empty;
        Customer = new ImportCustomerPayload();
        Items = new List<ImportItemPayload>();
    }
}
