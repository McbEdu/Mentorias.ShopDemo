namespace McbEdu.Mentorias.ShopDemo.Services.Customers.Inputs;

public class GetCustomerServiceFilteredByRangeBirthDateInput 
{
    public int Page { get; set; }
    public int Offset { get; set; }
	
	private DateTime _startIn;
	public DateTime StartIn
	{
		get { return _startIn; }
		set { _startIn = DateTime.SpecifyKind(value.Date, DateTimeKind.Utc); }
	}

    private DateTime _finishIn;

    public GetCustomerServiceFilteredByRangeBirthDateInput(int page, int offset, DateTime startIn, DateTime finishIn)
    {
        Page = page;
        Offset = offset;
        StartIn = startIn;
        FinishIn = finishIn;
    }

    public DateTime FinishIn
    {
        get { return _finishIn; }
        set { _finishIn = DateTime.SpecifyKind(value.Date, DateTimeKind.Utc); }
    }
}
