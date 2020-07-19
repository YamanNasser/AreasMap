using AreasMap.Repository.Core.Models;
using System.Collections.Generic;

namespace AreasMap.Application.Area.ViewModel
{
    public class AreaListView
    {
        public List<MainAreaDto> Areas { get; set; }
        public int Count => Areas.Count;
    }
}