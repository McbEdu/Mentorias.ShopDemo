namespace McbEdu.Mentorias.ShopDemo.WebApi.Controllers.Payloads;

public class ImportItemPayload
{
    public int Sequence { get; set; }
    public int Quantity { get; set; }
    public decimal UnitaryValue { get; set; }
    public string Description { get; set; }
    public ImportProductPayload Product { get; set; }

    public ImportItemPayload()
    {
        Description = string.Empty;
        Product = new ImportProductPayload();
    }
}
