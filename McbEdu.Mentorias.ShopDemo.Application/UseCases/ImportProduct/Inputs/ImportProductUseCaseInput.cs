﻿namespace McbEdu.Mentorias.ShopDemo.Application.UseCases.ImportProduct.Inputs;

public class ImportProductUseCaseInput
{
    public string Code { get; }
    public string Description { get; }

    public ImportProductUseCaseInput(string code, string description)
    {
        Code = code;
        Description = description;
    }
}
