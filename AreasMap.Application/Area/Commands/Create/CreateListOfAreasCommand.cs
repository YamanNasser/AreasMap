using AreasMap.Repository.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace AreasMap.Application.Area.Commands.Create
{
    public class CreateListOfAreasCommand : IRequest<bool>
    {
        public IList<MainAreaDto> Areas { get; set; }
    }
}