using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class PaginatedRequest : IPaginated
{
    
    [FromQuery, DefaultValue(0)]
    public int Page { get; set; }
    [FromQuery, DefaultValue(500)]
    public int PageSize { get; set; }
}