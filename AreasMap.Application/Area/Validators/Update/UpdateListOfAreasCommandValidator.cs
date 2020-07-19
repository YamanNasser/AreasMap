using AreasMap.Application.Area.Commands.Update;
using AreasMap.Domain.Entities;
using FluentValidation;
using System;
using System.Linq;

namespace AreasMap.Application.Area.Validators.Create
{
    //In case we need to do some validation on update
    public class UpdateListOfAreasCommandValidator : AbstractValidator<UpdateListOfAreasCommand>
    {
        public UpdateListOfAreasCommandValidator()
        {
            RuleFor(f => f.Areas).Must(urls => urls.All(s => !String.IsNullOrEmpty(s.Name))).WithMessage("Some Area Name is empty.");

            RuleFor(f => f.Areas).Must(urls => urls.All(s => ShapeType.TypeList.Contains(s.Shape.Type)))
                .WithMessage("Some Area Type is not exist.");
        }
    }
}