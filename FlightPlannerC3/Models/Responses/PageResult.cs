using System.Collections.Generic;
using FlightPlannerC3.Core.Models;

namespace FlightPlannerC3.Models.Responses
{
    public class PageResult
    {
        public PageResult(List<Flight> items)
        {
            Page = 0;
            TotalItems = items.Count;
            Items = items;
        }
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Flight> Items  {get; set;}
    }
}