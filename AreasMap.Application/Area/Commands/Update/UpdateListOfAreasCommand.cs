using AreasMap.Repository.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace AreasMap.Application.Area.Commands.Update
{
    public class UpdateListOfAreasCommand : IRequest<bool>
    {
        public IList<AreaDto> Areas { get; set; }
    }
}