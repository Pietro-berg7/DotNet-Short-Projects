﻿namespace XtraWork.Responses;

public class EmployeeResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string TitleDescription { get; set; } = string.Empty;
    public Guid TitleId { get; set; }
}
