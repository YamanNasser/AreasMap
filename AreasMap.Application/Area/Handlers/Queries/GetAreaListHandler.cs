using AreasMap.Application.Area.Queries;
using AreasMap.Application.Area.ViewModel;
using AreasMap.Repository.Core.Common;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AreasMap.Application.Area.Handlers.Queries
{
    public class GetAreaListHandler : IRequestHandler<GeAreaListQuery, AreaListView>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAreaListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AreaListView> Handle(GeAreaListQuery request, CancellationToken cancellationToken)
        {
            var areaList = await _unitOfWork.AreaRepository.GetAllAreasAsync();

            var areaListView = new AreaListView
            {
                Areas = areaList
            };

            return areaListView;
        }
    }
}